public class DirectoryModel : IModel
{
  private readonly ILogger _logger;

  public DirectoryModel(ILogger logger)
  {
    _logger = logger;
  }

  public List<string> CompareDirectories(string sourcePath, string targetPath)
  {
    var changes = new List<string>();

    if (!Directory.Exists(sourcePath)) 
    {
      return changes;
    }

    if (!Directory.Exists(targetPath)) 
    {
      Directory.CreateDirectory(targetPath);
    }

    CompareFiles(sourcePath, targetPath, changes, true);
    CompareFiles(targetPath, sourcePath, changes, false);

    return changes;
  }

  private void CompareFiles(string dirA, string dirB, List<string> changes, bool isSourceToTarget)
  {
    var filesInA = Directory.GetFiles(dirA, "*", SearchOption.AllDirectories);

    foreach (var filePath in filesInA)
    {
      var relativePath = filePath.Substring(dirA.Length).TrimStart(Path.DirectorySeparatorChar);
      var counterpartPath = Path.Combine(dirB, relativePath);

      if (!File.Exists(counterpartPath))
      {
        changes.Add(isSourceToTarget
          ? $"Файл\t\"{relativePath}\" создан"
          : $"Файл\t\"{relativePath}\" удален");
      }
      else if (File.GetLastWriteTime(filePath) != File.GetLastWriteTime(counterpartPath))
      {
        changes.Add($"Файл\t\"{relativePath}\" изменен");
      }
    }
  }

  public void SynchronizeDirectories(string sourcePath, string targetPath)
  {
    if (!Directory.Exists(sourcePath)) 
    {
      return;
    }

    if (!Directory.Exists(targetPath)) 
    {
      Directory.CreateDirectory(targetPath);
    }

    var changes = CompareDirectories(sourcePath, targetPath);
    _logger.LogChanges(changes);

    SyncDirectory(sourcePath, targetPath);
    SyncDirectory(targetPath, sourcePath);
  }

  private void SyncDirectory(string sourceDir, string targetDir)
  {
    foreach (var filePath in Directory.GetFiles(sourceDir))
    {
      var fileName = Path.GetFileName(filePath);
      var destPath = Path.Combine(targetDir, fileName);

      if (!File.Exists(destPath) || File.GetLastWriteTime(filePath) > File.GetLastWriteTime(destPath))
      {
        File.Copy(filePath, destPath, true);
      }
    }

    foreach (var filePath in Directory.GetFiles(targetDir))
    {
      var fileName = Path.GetFileName(filePath);
      var sourcePath = Path.Combine(sourceDir, fileName);

      if (!File.Exists(sourcePath))
      {
        File.Delete(filePath);
      }
    }

    foreach (var subDir in Directory.GetDirectories(sourceDir))
    {
      var dirName = Path.GetFileName(subDir);
      var destSubDir = Path.Combine(targetDir, dirName);
      SyncDirectory(subDir, destSubDir);
    }

    foreach (var subDir in Directory.GetDirectories(targetDir))
    {
      var dirName = Path.GetFileName(subDir);
      var sourceSubDir = Path.Combine(sourceDir, dirName);

      if (!Directory.Exists(sourceSubDir))
      {
        Directory.Delete(subDir, true);
      }
    }
  }
}