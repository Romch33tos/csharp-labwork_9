using System.Text.Json;
using System.IO;
using System.Collections.Generic;

public class JsonLogger : ILogger
{
  private const string LogFileName = "sync_log.json";

  public void LogChanges(List<string> changes)
  {
    var json = JsonSerializer.Serialize(changes);
    File.WriteAllText(LogFileName, json);
  }

  public List<string> GetLastChanges()
  {
    if (!File.Exists(LogFileName)) return new List<string>();

    var json = File.ReadAllText(LogFileName);
    return JsonSerializer.Deserialize<List<string>>(json);
  }
}