using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Directories
{
    class FileManager
    {
        public DirectoryInfo DirectoryI {  get; private set; }
        public string PathDirectory { get; private set; }
        public FileManager()
        {
            DirectoryI = new DirectoryInfo(Environment.CurrentDirectory);
            PathDirectory = Environment.CurrentDirectory;
        }
        public void ChangeDIrecotry()
        {
            
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("\n" + DirectoryI.FullName + @"\");
            string next = Console.ReadLine();
            Console.ResetColor();
            PathDirectory = Path.Combine(DirectoryI.FullName, next);
            DirectoryI = new DirectoryInfo(PathDirectory);
        }
        public void AddDirectory()
        {
            int choosePath;
            string path,name;
            Console.WriteLine("\nCreate in\n1.this directory\n2.another directory");
            choosePath = int.Parse(Console.ReadLine());
            if (choosePath == 1)
                path = PathDirectory;
            else
            {
                Console.WriteLine("\nEnter path:");
                path = Console.ReadLine();
            }
            Console.WriteLine("Enter name for directory: ");
            name = Console.ReadLine();
            path += "\\" + name;
            if (!new DirectoryInfo(path).Exists)
            {
                Console.Clear();
                Directory.CreateDirectory(path);
                Console.WriteLine("Directory create.");
                Console.ReadKey();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Directory already exist.");
                Console.ReadKey();
            }
        }
        public void DeleteDirectory()
        {
            int choosePath;
            string path;
            Console.WriteLine("Delete\n1.this directory\n2.another directory");
            choosePath = int.Parse(Console.ReadLine());
            if (choosePath == 1)
                path = PathDirectory;
            else
            {

                Console.WriteLine("\nEnter path:");
                path = Console.ReadLine();
            }
            if (!new DirectoryInfo(path).Exists)
            {
                Console.Clear();
                Console.WriteLine("Directory didnt exist.");
                Console.ReadKey();
            }
            else
            {
                Directory.Delete(path, true);
            }
        }

         public void ShowDirectories()
        {

            Console.WriteLine("\n" + new string('-', 53) + "Directories" + new string('-', 53) + "\n");

            foreach (var d in DirectoryI.GetDirectories())
            {
                Console.WriteLine("Directory: {0,-35}\tTime: {1}\t\tAtr: {2}", d.Name, d.CreationTime, d.Attributes);
            }
        }
        public void DeleteFile()
        {
            int choosePath;
            string path,name;
            Console.WriteLine("Delete\n1.this directory\n2.another directory");
            choosePath = int.Parse(Console.ReadLine());
            if (choosePath == 1)
            {
                path = PathDirectory;
            }
            else
            {
                Console.WriteLine("\nEnter directy path:");
                path = Console.ReadLine();
            }        
            Console.WriteLine("Enter name of file:");
            name = Console.ReadLine();
            path += "\\" + name;
            if (!new FileInfo(path).Exists)
            {
                Console.Clear();
                Console.WriteLine("File didnt exist.");
                Console.ReadKey();
            }
            else
            {
                File.Delete(path);
            }
        }
        public void ShowFileInfo()
        {
            int choosePath;
            string path, name;
            Console.WriteLine("Show file in\n1.this directory\n2.another directory");
            choosePath = int.Parse(Console.ReadLine());
            if (choosePath == 1)
            {
                path = PathDirectory;
            }
            else
            {
                Console.WriteLine("\nEnter path:");
                path = Console.ReadLine();
            }
            Console.WriteLine("Enter name of file:");
            name = Console.ReadLine();
            path += "\\" + name;
            if (!new FileInfo(path).Exists)
            {
                Console.Clear();
                Console.WriteLine("File didnt exist.");
                Console.ReadKey();
            }
            else
            {
                Console.Clear();
                ShowFileInfo(new FileInfo(path));
                Console.ReadLine();
            }
        }
        public void MoveFile()
        {
            string pathOld, pathNew;
            Console.WriteLine("Enter path to file:");
            pathOld = Console.ReadLine();
            Console.WriteLine("Enter new path for file:");
            pathNew = Console.ReadLine();
            if (!new FileInfo(pathOld).Exists)
            {
                Console.Clear();
                Console.WriteLine("File didnt exist.");
                Console.ReadKey();
            }
            else
                File.Move(pathOld, pathNew);
        }
         public void ShowFiles()
        {

            Console.WriteLine("\n" + new string('-', 56) + "Files" + new string('-', 56) + "\n");

            foreach (var file in DirectoryI.GetFiles())
            {
                Console.WriteLine("File: {0,-40}\tTime: {1}\t\tAtr: {2}", file.Name, file.CreationTime, file.Attributes);
            }
        }
         public void ShowFileInfo(FileInfo file)
        {
            if (file.Exists)
            {
                Console.WriteLine("FileName   : {0}", file.Name);
                Console.WriteLine("Ext        : {0}", file.Extension);
                Console.WriteLine("Path       : {0}", file.FullName);
                Console.WriteLine("Dir        : {0}", file.Directory);
                Console.WriteLine("Size(MB)   : {0}", ((file.Length) / 1024f) / 1024f);
                Console.WriteLine("Last Access: {0}", file.LastAccessTime);
            }
        }

         public void InfoDirecty()
        {
            if (DirectoryI.Exists)
            {
                Console.WriteLine("Directory        : {0}", DirectoryI.FullName);
                Console.WriteLine("CreationTime     : {0}", DirectoryI.CreationTime);
                Console.WriteLine("Extension        : {0}", DirectoryI.Extension);
                Console.WriteLine("LastAccessTime   : {0}", DirectoryI.LastAccessTime);
                Console.WriteLine("LastWriteTime    : {0}", DirectoryI.LastWriteTime);
                Console.WriteLine("Name             : {0}", DirectoryI.Name);
            }
        }
    }
    class Program
    {

       
        static void Main(string[] args)
        {
            int action;
            string mainPath = Environment.CurrentDirectory;
            FileManager fileManager = new FileManager();
            do
            {
                Console.Clear();
                Console.WriteLine("Directory: {0}", fileManager.PathDirectory + "\n");
                Console.WriteLine("Choose action:" +
                    "\n1.Change directory" +
                    "\n2.Directory info" +
                    "\n3.Show directories" +
                    "\n4.Show directories and files" +
                    "\n5.Add directory" +
                    "\n6.Delete directory and files in it" +
                    "\n7.Delete file" +
                    "\n8.Show info about file" +
                    "\n9.Move file" +
                    "\n0.Exit");
                action = int.Parse(Console.ReadLine());
                switch (action)
                {
                    case 1:
                        fileManager.ChangeDIrecotry();
                        break;

                    case 2:
                        Console.Clear();
                        fileManager.InfoDirecty();
                        Console.ReadKey();
                        break;
                    case 3:
                        Console.Clear();
                        fileManager.ShowDirectories();
                        Console.ReadKey();
                        break;
                    case 4:
                        Console.Clear();
                        fileManager.ShowDirectories();
                        fileManager.ShowFiles();
                        Console.ReadKey();
                        break;
                    case 5:
                        Console.Clear();
                        fileManager.AddDirectory();
                        break;
                    case 6:
                        Console.Clear();
                        fileManager.DeleteDirectory();
                        break;
                    case 7:
                        Console.Clear();
                        fileManager.DeleteFile();
                        break;
                    case 8:
                        Console.Clear();
                        fileManager.ShowFileInfo();
                        break;
                    case 9:
                        Console.Clear();
                        fileManager.MoveFile();
                        break;
                    case 0:
                        break;
                }
            } while (action != 0);
        }
    }
}
