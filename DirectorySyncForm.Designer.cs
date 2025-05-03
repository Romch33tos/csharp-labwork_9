partial class DirectorySyncForm
{
  private System.ComponentModel.IContainer components = null;

  protected override void Dispose(bool disposing)
  {
    if (disposing && (components != null))
    {
      components.Dispose();
    }
    base.Dispose(disposing);
  }

  private void InitializeComponent()
  {
    this.sourceLabel = new System.Windows.Forms.Label();
    this.targetLabel = new System.Windows.Forms.Label();
    this.sourceTextBox = new System.Windows.Forms.TextBox();
    this.targetTextBox = new System.Windows.Forms.TextBox();
    this.sourceBrowseButton = new System.Windows.Forms.Button();
    this.targetBrowseButton = new System.Windows.Forms.Button();
    this.syncButton = new System.Windows.Forms.Button();
    this.SuspendLayout();

    this.sourceLabel.Location = new System.Drawing.Point(12, 15);
    this.sourceLabel.Name = "sourceLabel";
    this.sourceLabel.Size = new System.Drawing.Size(100, 20);
    this.sourceLabel.Text = "Исходная папка:";

    this.targetLabel.Location = new System.Drawing.Point(12, 45);
    this.targetLabel.Name = "targetLabel";
    this.targetLabel.Size = new System.Drawing.Size(100, 20);
    this.targetLabel.Text = "Целевая папка:";

    this.sourceTextBox.Location = new System.Drawing.Point(118, 12);
    this.sourceTextBox.Name = "sourceTextBox";
    this.sourceTextBox.Size = new System.Drawing.Size(250, 20);

    this.targetTextBox.Location = new System.Drawing.Point(118, 42);
    this.targetTextBox.Name = "targetTextBox";
    this.targetTextBox.Size = new System.Drawing.Size(250, 20);

    this.sourceBrowseButton.Location = new System.Drawing.Point(374, 10);
    this.sourceBrowseButton.Name = "sourceBrowseButton";
    this.sourceBrowseButton.Size = new System.Drawing.Size(75, 23);
    this.sourceBrowseButton.Text = "Обзор...";
    this.sourceBrowseButton.UseVisualStyleBackColor = true;

    this.targetBrowseButton.Location = new System.Drawing.Point(374, 40);
    this.targetBrowseButton.Name = "targetBrowseButton";
    this.targetBrowseButton.Size = new System.Drawing.Size(75, 23);
    this.targetBrowseButton.Text = "Обзор...";
    this.targetBrowseButton.UseVisualStyleBackColor = true;

    this.syncButton.Location = new System.Drawing.Point(118, 80);
    this.syncButton.Name = "syncButton";
    this.syncButton.Size = new System.Drawing.Size(250, 30);
    this.syncButton.Text = "Синхронизировать";
    this.syncButton.UseVisualStyleBackColor = true;

    this.ClientSize = new System.Drawing.Size(461, 121);
    this.Controls.Add(this.sourceLabel);
    this.Controls.Add(this.targetLabel);
    this.Controls.Add(this.sourceTextBox);
    this.Controls.Add(this.targetTextBox);
    this.Controls.Add(this.sourceBrowseButton);
    this.Controls.Add(this.targetBrowseButton);
    this.Controls.Add(this.syncButton);
    
    this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
    
  	this.MaximizeBox = false;
  	this.MinimizeBox = false;
  	this.Name = "DirectorySyncForm";
  	this.Text = "Приложение для синхронизации";
  	this.ResumeLayout(false);
  	this.PerformLayout();
  }

  private System.Windows.Forms.Label sourceLabel;
  private System.Windows.Forms.Label targetLabel;
  private System.Windows.Forms.TextBox sourceTextBox;
  private System.Windows.Forms.TextBox targetTextBox;
  private System.Windows.Forms.Button sourceBrowseButton;
  private System.Windows.Forms.Button targetBrowseButton;
  private System.Windows.Forms.Button syncButton;
}