Console.WriteLine("Enter folder path:");
string path = Console.ReadLine();
DirectoryInfo dirInfo = new DirectoryInfo(path);
if (dirInfo.Exists)
{
    long size = 0;
    GetFolderSize(dirInfo, ref size);
    Console.WriteLine(size.ToString());
}
else
{
    Console.WriteLine("This folder does not exist!");
}

void GetFolderSize(DirectoryInfo path, ref long size)
{
    try
    {
        FileInfo[] fis = path.GetFiles();
        foreach (FileInfo fi in fis)
        {
            size += fi.Length;
            //для тестов в директории проекта есть папка FolderForTest
            //Console.WriteLine($"file:{fi.FullName}, size:{fi.Length}");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex);
    }

    foreach (var directory in path.GetDirectories())
    {
        GetFolderSize(directory, ref size);
    }
}