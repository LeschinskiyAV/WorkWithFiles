public class Program2
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Enter folder path:");
        string path = Console.ReadLine();
        DirectoryInfo dirInfo = new DirectoryInfo(path);
        if (dirInfo.Exists)
        {
            long size = 0;
            GetNestedFoldersLength(dirInfo, ref size);
            Console.WriteLine(size);
        }
        else
        {
            Console.WriteLine("This folder does not exist!");
        }
    }
    public static void GetNestedFoldersLength(DirectoryInfo directoryInfo, ref long total)
    {
        try
        {
            foreach (DirectoryInfo dir in directoryInfo.GetDirectories())
            {
                GetNestedFoldersLength(dir, ref total);
            }
            long foldersize = 0;
            FileInfo[] filesInfo = directoryInfo.GetFiles();
            foreach (FileInfo fileInfo in filesInfo)
            {
                foldersize += fileInfo.Length;
            }
            total += foldersize;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }
}