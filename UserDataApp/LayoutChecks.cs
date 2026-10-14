using System.Text;

namespace UserDataApp;

// Run on Windows: UserDataApp.exe --test-layout
// Uses the actual WinForms controls, including a real maximize/restore cycle.
internal static class LayoutChecks
{
    internal static async Task RunAsync(Form1 form)
    {
        var report = new StringBuilder();
        report.AppendLine($"Windows layout checks — {DateTimeOffset.Now:O}; DPI={form.DeviceDpi}");
        int failures = 0;
        try
        {
            foreach (Size size in new[] { new Size(800, 500), new Size(1000, 600), new Size(1200, 700) })
            {
                form.Size = size;
                await Task.Delay(200);
                Check(form, $"Requested window {size.Width} × {size.Height}; actual {form.Width} × {form.Height}", report);
            }
            form.WindowState = FormWindowState.Maximized;
            await Task.Delay(300);
            if (form.WindowState != FormWindowState.Maximized)
                throw new InvalidOperationException("Window did not maximize.");
            Check(form, $"Maximized {form.Width} × {form.Height}", report);
            form.WindowState = FormWindowState.Normal;
            await Task.Delay(200);
            Check(form, "Restored", report);
            form.Size = new Size(400, 300);
            await Task.Delay(200);
            if (form.Width < form.MinimumSize.Width || form.Height < form.MinimumSize.Height)
                throw new InvalidOperationException("MinimumSize was not enforced.");
            Check(form, "MinimumSize enforced", report);
        }
        catch (Exception ex)
        {
            failures++;
            report.AppendLine($"FAIL: {ex.Message}");
        }
        report.AppendLine(failures == 0 ? "PASS: all layout checks." : "FAIL: layout checks.");
        try
        {
            string path = Path.Combine(AppContext.BaseDirectory, "layout-test-results.txt");
            File.WriteAllText(path, report.ToString());
        }
        catch (Exception ex) when (ex is IOException or UnauthorizedAccessException)
        {
            failures++;
            MessageBox.Show(report.ToString(), "Layout test results (report could not be written)");
        }
        Environment.ExitCode = failures == 0 ? 0 : 1;
        form.Close();
    }

    private static void Check(Form1 form, string scenario, StringBuilder report)
    {
        form.PerformLayout();
        var bounds = form.LayoutControls.Select(c =>
        {
            if (!c.Visible || c.Width <= 0 || c.Height <= 0)
                throw new InvalidOperationException($"{scenario}: hidden or empty control {c.Text}.");
            var screen = c.RectangleToScreen(c.ClientRectangle);
            if (!form.RectangleToScreen(form.ClientRectangle).Contains(screen))
                throw new InvalidOperationException($"{scenario}: control outside client area: {c.Text}.");
            for (Control? parent = c.Parent; parent != null && parent != form; parent = parent.Parent)
                if (!parent.RectangleToScreen(parent.ClientRectangle).Contains(screen))
                    throw new InvalidOperationException($"{scenario}: clipped control: {c.Text}.");
            return screen;
        }).ToArray();
        for (int i = 0; i < bounds.Length; i++)
            for (int j = i + 1; j < bounds.Length; j++)
                if (bounds[i].IntersectsWith(bounds[j]))
                    throw new InvalidOperationException($"{scenario}: overlapping controls.");
        report.AppendLine($"PASS: {scenario}; controls visible, unclipped, no overlaps.");
    }
}
