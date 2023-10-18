namespace ClassWork_55_00;

public class FileFinder
{
    public IEnumerable<string> FindFile(string path, string searchData)
    {
        var files = new List<string>();

        foreach (var file in Directory.GetFiles(path).Where(dir => dir.Contains(searchData)))
        {
            files.Add(file);
        }

        foreach (var subDir in Directory.EnumerateDirectories(path))
        {
            try
            {
                files.AddRange(FindFile(subDir, searchData));
            }
            catch (Exception e)
            {
                Console.WriteLine("File not found: ");
            }
        }
        
        return files;
    }
}