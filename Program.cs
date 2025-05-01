using System;
using System.Windows.Forms;

static class Program
{
  [STAThread]
  static void Main()
  {
    Application.EnableVisualStyles();
    Application.SetCompatibleTextRenderingDefault(false);
    
    var view = new DirectorySyncForm();
    ILogger logger = view.SelectedLogFormat == LogFormat.XML 
      ? new XmlLogger() 
      : new JsonLogger();
    var model = new DirectoryModel(logger);
    var presenter = new DirectorySyncPresenter(view, model, logger);
    
    Application.Run(view);
  }
}