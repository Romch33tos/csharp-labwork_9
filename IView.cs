public interface IView
{
  string SourceDirectory { get; set; }
  string TargetDirectory { get; set; }
  event EventHandler SyncRequested;
  void ShowMessage(string message);
}