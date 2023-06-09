
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
        
        try
        {
            foreach (var file in directory.GetFiles())
            {
                if (DateTime.Now - file.LastAccessTime > TimeSpan.FromMinutes(1))
                {
                    {
                        file.Delete();
                    }
                }
            }

            foreach (var dir in directory.GetDirectories())
            {
                if (DateTime.Now - dir.LastAccessTime > TimeSpan.FromMinutes(1))
                {
                    {
                        dir.Delete(true);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
    }
}