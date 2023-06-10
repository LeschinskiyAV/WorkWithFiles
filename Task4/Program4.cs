using System.Runtime.Serialization.Formatters.Binary;

namespace FinalTask
{
    [Serializable]
    class Student
    {
        public string Name { get; set; }
        public string Group { get; set; }
        public DateTime DateOfBirth { get; set; }

        public Student(string name, string group, DateTime dateOfBirth)
        {
            Name = name;
            Group = group;
            DateOfBirth = dateOfBirth;
        }
    }

    class Program4
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Enter path to folder that contains 'Students.dat'");
            string filePath = Console.ReadLine() + "\\Students.dat";
            if (File.Exists(filePath))
            {
                DirectoryInfo directoryInfo = Directory.CreateDirectory($"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\\Students");
                string pth = directoryInfo.FullName;
                if (Directory.Exists(pth))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    var fs = new FileStream(filePath, FileMode.Open);
                    using (fs)
                    {

#pragma warning disable SYSLIB0011 // Тип или член устарел
                        var StudentsArr = (Student[])formatter.Deserialize(fs);
#pragma warning restore SYSLIB0011 // Тип или член 

                        foreach (var std in StudentsArr)
                        {
                            File.AppendAllText($"{pth}\\{std.Group}.txt", $"{std.Name}, {std.DateOfBirth}{Environment.NewLine}");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Cant create 'Students' on Desktop");
                }
            }
        }
    }
}