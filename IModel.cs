public interface IModel
{
  List<string> CompareDirectories(string sourcePath, string targetPath);
  void SynchronizeDirectories(string sourcePath, string targetPath);
}