Console.WriteLine("Enter folder path:");
string path = Console.ReadLine();
DirectoryInfo dirInfo = new DirectoryInfo(path);
if (dirInfo.Exists)
{
    DisposeUnusedFiles(dirInfo);
}
else
{
    Console.WriteLine("This folder does not exist!");
}

void DisposeUnusedFiles(DirectoryInfo path)
{

    foreach (var directory in path.GetDirectories())
    {
        DisposeUnusedFiles(directory);
    }
    try
    {
        foreach (var file in path.GetFiles())
        {
            if (DateTime.Now - file.LastAccessTime > TimeSpan.FromMinutes(1))
            {
                {
                    file.Delete();
                }
            }
        }

        if (DateTime.Now - path.LastAccessTime > TimeSpan.FromMinutes(1))
        {
            {
                path.Delete(true);
            }
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex);
    }
}