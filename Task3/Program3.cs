class Program3
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Enter folder path:");
        string path = Console.ReadLine();
        DirectoryInfo dirInfo = new DirectoryInfo(path);
        if (dirInfo.Exists)
        {
            long size_before = 0;
            Program2.GetNestedFoldersLength(dirInfo, ref size_before);
            Console.WriteLine($"Исходный размер папки: {size_before}");
            Program1.DeleteUnusedFilesAndFolders(dirInfo, true);
            long size_after = 0;
            Program2.GetNestedFoldersLength(dirInfo, ref size_after);
            Console.WriteLine($"Освобождено: {size_before - size_after}");
            Console.WriteLine($"Текущий размер папки: {size_after}");
        }
        else
        {
            Console.WriteLine("This folder does not exist!");
        }
    }
}