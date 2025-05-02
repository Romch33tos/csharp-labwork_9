using System.Xml.Serialization;
using System.IO;
using System.Collections.Generic;

public class XmlLogger : ILogger
{
  private const string LogFileName = "sync_log.xml";

  public void LogChanges(List<string> changes)
  {
    var serializer = new XmlSerializer(typeof(List<string>));
    using (var writer = new StreamWriter(LogFileName))
    {
      serializer.Serialize(writer, changes);
    }
  }

  public List<string> GetLastChanges()
  {
    if (!File.Exists(LogFileName)) return new List<string>();

    var serializer = new XmlSerializer(typeof(List<string>));
    using (var reader = new StreamReader(LogFileName))
    {
      return (List<string>)serializer.Deserialize(reader);
    }
  }
}