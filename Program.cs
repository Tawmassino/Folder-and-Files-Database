using System.IO;

namespace Database_11_16
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using var dbContext = new FilesDbContext();


            Console.WriteLine("Input the directory of a Folder");
            string userInputDir = Console.ReadLine();
            string[] filePaths = Directory.GetFiles(userInputDir);//string[] filePaths = Directory.GetFiles(Console.ReadLine());

            //Console.WriteLine(userInputDir);




            Console.WriteLine($"=========== Folder Name: {GetFolderName(userInputDir)} =========== ");

            foreach (string filePath in filePaths)
            {
                Console.WriteLine($"File Name: {GetFileName(filePath)}");
                Console.WriteLine($"File Type: {GetFileType(filePath)}");
                Console.WriteLine($"Size of the File: {GetSizeOfFile(filePath)} bytes");
                Console.WriteLine($"Full directory of the File: {GetFileFullDir(filePath)} bytes");
                Console.WriteLine();
            }



            //-----------------------------------------------------

            var folder = new Folder()
            {
                Name = GetFolderName(userInputDir),
                Files = new List<File>()
            };

            foreach (string filePath in filePaths)
            {
                var file = new File()
                {
                    Name = GetFileName(filePath),
                    Size = GetSizeOfFile(filePath),
                    FullDirectory = GetFileFullDir(filePath)
                };
                folder.Files.Add(file);

                Console.WriteLine($"File Name: {file.Name}");
                Console.WriteLine($"File Type: {GetFileType(filePath)}");
                Console.WriteLine($"Size of the File: {file.Size} bytes");
                Console.WriteLine($"Full directory of the File: {file.FullDirectory}");
                Console.WriteLine();
            }



            // put into DB
            dbContext.Folders.Add(folder);//push folder

            //OPTIONAL.
            //EFramework jau automatiskai padaro sita foreacha
            //foreach (var file in folder.Files)//push files
            //{
            //    dbContext.Files.Add(file);
            //}

            dbContext.SaveChanges();
        }

        // ===================== METHODS =====================

        public static string GetFolderName(string userInputDir)
        {
            int folderDirNumMin = userInputDir.LastIndexOf('\\');
            int folderDirNameMax = userInputDir.Length;
            string folderName = userInputDir.Substring(folderDirNumMin, (folderDirNameMax - folderDirNumMin)).TrimStart('\\');

            //Console.WriteLine($"{userInputDir.LastIndexOf('\\') - 1}, {userInputDir.Length}");
            //Console.WriteLine($"{folderName}");

            return folderName;
        }

        public static string GetFileName(string filePath)
        {
            int fileDirNumMin = filePath.LastIndexOf('\\');
            int fileDirNameMax = filePath.LastIndexOf('.');
            string fileName = filePath.Substring(fileDirNumMin + 1, (fileDirNameMax - fileDirNumMin - 1));

            return fileName;
        }

        public static string GetFileType(string filePath)
        {
            int fileDirNumMin = filePath.LastIndexOf('.');
            int fileDirNameMax = filePath.Length;
            string fileType = filePath.Substring(fileDirNumMin + 1, (fileDirNameMax - fileDirNumMin - 1));

            return fileType;
        }

        public static int GetSizeOfFile(string filePath)
        {
            FileInfo fileInfo = new FileInfo(filePath);
            return (int)fileInfo.Length;
        }

        public static string GetFileFullDir(string filePath)
        {
            FileInfo fileInfo = new FileInfo(filePath);
            return fileInfo.FullName;

        }

    }
}