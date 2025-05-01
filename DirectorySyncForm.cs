public partial class DirectorySyncForm : Form, IView
{
  public event EventHandler SyncRequested;

  public string SourceDirectory
  {
    get { return sourceTextBox.Text; }
    set { sourceTextBox.Text = value; }
  }

  public string TargetDirectory
  {
    get { return targetTextBox.Text; }
    set { targetTextBox.Text = value; }
  }

  public LogFormat SelectedLogFormat { get; private set; }

  public DirectorySyncForm()
  {
    InitializeComponent();
    this.FormBorderStyle = FormBorderStyle.FixedSingle;
    this.MaximizeBox = false;
    this.MinimizeBox = false;

    syncButton.Click += (sender, e) => SyncRequested?.Invoke(this, EventArgs.Empty);
    sourceBrowseButton.Click += (sender, e) => BrowseFolder(sourceTextBox);
    targetBrowseButton.Click += (sender, e) => BrowseFolder(targetTextBox);

    // Добавляем RadioButton для выбора формата лога
    var xmlRadio = new RadioButton { Text = "XML", Location = new Point(12, 80), Checked = true };
    var jsonRadio = new RadioButton { Text = "JSON", Location = new Point(12, 105) };

    xmlRadio.CheckedChanged += (s, e) => { if (xmlRadio.Checked) SelectedLogFormat = LogFormat.XML; };
    jsonRadio.CheckedChanged += (s, e) => { if (jsonRadio.Checked) SelectedLogFormat = LogFormat.JSON; };

    this.Controls.Add(xmlRadio);
    this.Controls.Add(jsonRadio);

    // Увеличиваем высоту формы
    this.Height = 180;
    syncButton.Location = new Point(118, 120);
  }

  private void BrowseFolder(TextBox textBox)
  {
    using (var dialog = new FolderBrowserDialog())
    {
      if (dialog.ShowDialog() == DialogResult.OK)
      {
        textBox.Text = dialog.SelectedPath;
      }
    }
  }

  public void ShowMessage(string message)
  {
    MessageBox.Show(message, "Результат синхронизации", MessageBoxButtons.OK, MessageBoxIcon.Information);
  }
}