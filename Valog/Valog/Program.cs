using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Valog
{
    class Program
    {
        public static string Local = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        public static int DeletedFilesCount = 0;

        static void Main(string[] args)
        {
            Console.Title = "VALOG";
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(Environment.NewLine + "  [VALOG - LOG CLEAR (coded by Lufzys)]");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            DeleteFilesAndFoldersRecursively(Local + @"\Riot Games");
            Console.WriteLine("  Riot Games, deleted!");
            DeleteFilesAndFoldersRecursively(Local + @"\VALORANT");
            Console.WriteLine("  Valorant Logs, deleted!");
            DeleteAllFilesOnDirectory(@"C:\Program Files\Riot Vanguard\Logs");
            DeleteAllFilesOnDirectory(@"C:\ProgramData\Riot Games\Metadata\valorant.live");

            if (DeletedFilesCount != 0)
            {
                Console.WriteLine(Environment.NewLine + "  " + DeletedFilesCount + ", Files deleted!");
            }
            else
            {
                Console.WriteLine("  " + DeletedFilesCount + ", Files deleted!");
            }
            Thread.Sleep(5000);
            Environment.Exit(0);
        }

        public static void DeleteFilesAndFoldersRecursively(string target_dir)
        {
           try
            {
                foreach (string file in Directory.GetFiles(target_dir))
                {
                    File.Delete(file);
                }

                foreach (string subDir in Directory.GetDirectories(target_dir))
                {
                    DeleteFilesAndFoldersRecursively(subDir);
                }

                Thread.Sleep(1); // This makes the difference between whether it works or not. Sleep(0) is not enough.
                Directory.Delete(target_dir);
            } catch { }
        }

        public static void DeleteAllFilesOnDirectory(string path)
        {
            try
            {
                if (Directory.Exists(path))
                {
                    System.IO.DirectoryInfo di = new DirectoryInfo(path);
                    foreach (FileInfo file in di.GetFiles())
                    {
                        DeletedFilesCount++;
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("  " + file.Name + " | DELETED");
                        file.Delete();
                    }
                }
            } catch { }
        }
    }
}
