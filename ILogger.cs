public interface ILogger
{
  void LogChanges(List<string> changes);
  List<string> GetLastChanges();
}

public enum LogFormat
{
  XML,
  JSON
}