namespace UserDataApp;

static class Program
{
    [STAThread]
    static void Main(string[] args)
    {
        ApplicationConfiguration.Initialize();
        var form = new Form1();
        if (args.Contains("--test-layout"))
            form.Shown += async (_, _) => await LayoutChecks.RunAsync(form);
        Application.Run(form);
    }
}
