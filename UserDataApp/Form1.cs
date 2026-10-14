using System.Net.Mail;
using System.Text.Json;

namespace UserDataApp;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private void SaveButton_Click(object? sender, EventArgs e)
    {
        TextBox[] fields = [nameTextBox, firstNameTextBox, emailTextBox, phoneTextBox];
        foreach (TextBox field in fields)
        {
            if (string.IsNullOrWhiteSpace(field.Text))
            {
                MessageBox.Show(this, "Completați toate câmpurile.", "Date incomplete",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                field.Focus();
                return;
            }
        }
        string email = emailTextBox.Text.Trim();
        if (!MailAddress.TryCreate(email, out var address) || address.Address != email)
        {
            MessageBox.Show(this, "Introduceți o adresă de email validă.", "Email invalid",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            emailTextBox.Focus();
            return;
        }

        using var dialog = new SaveFileDialog
        {
            Title = "Salvează datele utilizatorului",
            Filter = "Fișier JSON (*.json)|*.json",
            FileName = "date-utilizator.json",
            DefaultExt = "json",
            AddExtension = true
        };
        if (dialog.ShowDialog(this) != DialogResult.OK) return;
        try
        {
            var data = new
            {
                Nume = nameTextBox.Text.Trim(),
                Prenume = firstNameTextBox.Text.Trim(),
                Email = email,
                Telefon = phoneTextBox.Text.Trim()
            };
            File.WriteAllText(dialog.FileName, JsonSerializer.Serialize(data,
                new JsonSerializerOptions { WriteIndented = true }));
            MessageBox.Show(this, "Datele au fost salvate.", "Salvare",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex) when (ex is IOException or UnauthorizedAccessException)
        {
            MessageBox.Show(this, "Fișierul nu a putut fi salvat. Alegeți altă locație.",
                "Eroare la salvare", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void CancelButton_Click(object? sender, EventArgs e)
    {
        nameTextBox.Clear();
        firstNameTextBox.Clear();
        emailTextBox.Clear();
        phoneTextBox.Clear();
        nameTextBox.Focus();
    }

    internal IReadOnlyList<Control> LayoutControls =>
        [titleLabel, nameLabel, firstNameLabel, emailLabel, phoneLabel,
         nameTextBox, firstNameTextBox, emailTextBox, phoneTextBox, saveButton, cancelButton];
}
