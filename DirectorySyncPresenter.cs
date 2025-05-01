public class DirectorySyncPresenter : IPresenter
{
  private readonly IView _view;
  private readonly IModel _model;
  private readonly ILogger _logger;

  public DirectorySyncPresenter(IView view, IModel model, ILogger logger)
  {
    _view = view;
    _model = model;
    _logger = logger;
    _view.SyncRequested += OnSyncRequested;
  }

  private void OnSyncRequested(object sender, EventArgs e)
  {
    SyncDirectories();
  }

  public void SyncDirectories()
  {
    try
    {
      var changes = _model.CompareDirectories(_view.SourceDirectory, _view.TargetDirectory);
      var lastChanges = _logger.GetLastChanges();

      if (changes.SequenceEqual(lastChanges))
      {
        _view.ShowMessage("Изменений не обнаружено. Синхронизация не требуется.");
        return;
      }

      _model.SynchronizeDirectories(_view.SourceDirectory, _view.TargetDirectory);

      if (changes.Count == 0)
      {
        _view.ShowMessage("Папки уже синхронизированы.");
      }
      else
      {
        _view.ShowMessage(string.Join(Environment.NewLine, changes));
      }
    }
    catch (Exception ex)
    {
      _view.ShowMessage($"Ошибка при синхронизации: {ex.Message}");
    }
  }
}