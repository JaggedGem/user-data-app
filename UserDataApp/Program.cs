namespace UserDataApp;

static class Program
{
    [STAThread]
    static void Main(string[] args)
    {
        ApplicationConfiguration.Initialize();
        var form = new Form1();
        if (!TryApplyWindowSize(args, form))
        {
            form.Dispose();
            return;
        }

        if (args.Contains("--test-layout"))
            form.Shown += async (_, _) => await LayoutChecks.RunAsync(form);
        Application.Run(form);
    }

    private static bool TryApplyWindowSize(string[] args, Form form)
    {
        for (int i = 0; i < args.Length; i++)
        {
            if (args[i] is not ("--size" or "--window-size"))
                continue;

            if (i + 2 >= args.Length ||
                !int.TryParse(args[i + 1], out int width) ||
                !int.TryParse(args[i + 2], out int height) ||
                width < form.MinimumSize.Width ||
                height < form.MinimumSize.Height)
            {
                MessageBox.Show(
                    $"Usage: {Application.ProductName}.exe --size <width> <height>\n" +
                    $"Width must be at least {form.MinimumSize.Width} and height at least {form.MinimumSize.Height}.",
                    "Invalid window size",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            form.Size = new Size(width, height);
            return true;
        }

        return true;
    }
}
