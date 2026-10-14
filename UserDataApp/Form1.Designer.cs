#nullable enable
namespace UserDataApp;

partial class Form1
{
    private System.ComponentModel.IContainer? components;
    private TableLayoutPanel layout = null!;
    private Label titleLabel = null!;
    private Label nameLabel = null!;
    private Label firstNameLabel = null!;
    private Label emailLabel = null!;
    private Label phoneLabel = null!;
    private TextBox nameTextBox = null!;
    private TextBox firstNameTextBox = null!;
    private TextBox emailTextBox = null!;
    private TextBox phoneTextBox = null!;
    private FlowLayoutPanel actionsPanel = null!;
    private Button saveButton = null!;
    private Button cancelButton = null!;

    protected override void Dispose(bool disposing)
    {
        if (disposing) components?.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        layout = new TableLayoutPanel();
        titleLabel = new Label();
        nameLabel = new Label();
        firstNameLabel = new Label();
        emailLabel = new Label();
        phoneLabel = new Label();
        nameTextBox = new TextBox();
        firstNameTextBox = new TextBox();
        emailTextBox = new TextBox();
        phoneTextBox = new TextBox();
        actionsPanel = new FlowLayoutPanel();
        saveButton = new Button();
        cancelButton = new Button();
        SuspendLayout();
        layout.SuspendLayout();
        actionsPanel.SuspendLayout();

        // Dock fills the available client area; the second column takes spare width.
        layout.Dock = DockStyle.Fill;
        layout.Padding = new Padding(24);
        layout.ColumnCount = 2;
        layout.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
        layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layout.RowCount = 7;
        for (int i = 0; i < 5; i++)
            layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));

        titleLabel.Text = "Date utilizator";
        titleLabel.AutoSize = true;
        titleLabel.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
        titleLabel.Margin = new Padding(0, 0, 0, 24);
        layout.Controls.Add(titleLabel, 0, 0);
        layout.SetColumnSpan(titleLabel, 2);

        nameLabel.Text = "Nume:";
        firstNameLabel.Text = "Prenume:";
        emailLabel.Text = "Email:";
        phoneLabel.Text = "Telefon:";
        Label[] labels = [nameLabel, firstNameLabel, emailLabel, phoneLabel];
        TextBox[] inputs = [nameTextBox, firstNameTextBox, emailTextBox, phoneTextBox];
        for (int i = 0; i < labels.Length; i++)
        {
            labels[i].AutoSize = true;
            labels[i].Anchor = AnchorStyles.Left;
            labels[i].Margin = new Padding(0, 8, 20, 16);
            labels[i].TabIndex = i * 2;
            inputs[i].Name = new[] { "nameTextBox", "firstNameTextBox", "emailTextBox", "phoneTextBox" }[i];
            // Anchor lets fields stretch horizontally when the window is resized.
            inputs[i].Anchor = AnchorStyles.Left | AnchorStyles.Right;
            inputs[i].Margin = new Padding(0, 4, 0, 12);
            inputs[i].TabIndex = i * 2 + 1;
            inputs[i].MaxLength = 200;
            layout.Controls.Add(labels[i], 0, i + 1);
            layout.Controls.Add(inputs[i], 1, i + 1);
        }

        actionsPanel.Dock = DockStyle.Fill;
        actionsPanel.AutoSize = true;
        actionsPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        actionsPanel.FlowDirection = FlowDirection.RightToLeft;
        actionsPanel.WrapContents = true;
        actionsPanel.Margin = new Padding(0, 16, 0, 0);
        actionsPanel.TabIndex = 9;
        saveButton.Text = "Salvează";
        saveButton.AutoSize = true;
        saveButton.MinimumSize = new Size(112, 36);
        saveButton.Margin = new Padding(8, 0, 0, 0);
        saveButton.TabIndex = 0;
        saveButton.Click += SaveButton_Click;
        cancelButton.Text = "Anulează";
        cancelButton.AutoSize = true;
        cancelButton.MinimumSize = new Size(112, 36);
        cancelButton.Margin = new Padding(8, 0, 0, 0);
        cancelButton.TabIndex = 1;
        cancelButton.Click += CancelButton_Click;
        actionsPanel.Controls.Add(cancelButton);
        actionsPanel.Controls.Add(saveButton);
        layout.Controls.Add(actionsPanel, 0, 6);
        layout.SetColumnSpan(actionsPanel, 2);

        AutoScaleDimensions = new SizeF(96F, 96F);
        AutoScaleMode = AutoScaleMode.Dpi;
        Font = new Font("Segoe UI", 10F);
        ClientSize = new Size(800, 500);
        MinimumSize = new Size(800, 500);
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Date utilizator";
        AcceptButton = saveButton;
        CancelButton = cancelButton;
        Controls.Add(layout);
        actionsPanel.ResumeLayout(false);
        actionsPanel.PerformLayout();
        layout.ResumeLayout(false);
        layout.PerformLayout();
        ResumeLayout(false);
    }
}
