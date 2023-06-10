public class Program1
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Enter folder path:");
        string path = Console.ReadLine();
        DirectoryInfo dirInfo = new DirectoryInfo(path);
        if (dirInfo.Exists)
        {
            DeleteUnusedFilesAndFolders(dirInfo, true);
        }
        else
        {
            Console.WriteLine("This folder does not exist!");
        }
    }
    public static void DeleteUnusedFilesAndFolders(DirectoryInfo directoryInfo, bool itisFirstDir)
    {
        try
        {
            foreach (var directory in directoryInfo.GetDirectories())
            {
                DeleteUnusedFilesAndFolders(directory, false);
            }
            foreach (var fileInfo in directoryInfo.GetFiles())
            {
                if (DateTime.Now - fileInfo.LastAccessTime > TimeSpan.FromMinutes(0.5))
                {
                    {
                        fileInfo.Delete();
                    }
                }
            }
            if (!directoryInfo.GetFiles().Any() && !itisFirstDir)
            {
                directoryInfo.Delete();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
    }
}