using System;
using System.IO;

namespace BingLockScreenImageSaver
{
    class Program
    {
        static void Main(string[] args)
        {
            StartCopy();
        }

        public static string GetUserName()
        {
            string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            string symbol = @"\";
            int indexOfSymbol = userName.IndexOf(symbol);
            userName = userName.Substring(indexOfSymbol + 1);
            return userName;
        }

        public static void CopyFiles(string targetPath)
        {
            string fileName = string.Empty;
            string destFile = string.Empty;
            string userName = GetUserName();
            string sourcePath = @"C:\Users\" + userName + @"\AppData\Local\Packages\Microsoft.Windows.ContentDeliveryManager_cw5n1h2txyewy\LocalState\Assets";
            if (Directory.Exists(sourcePath))
            {
                var i = 1;
                string[] files = Directory.GetFiles(sourcePath);
                Console.WriteLine("Copying...");
                foreach (string s in files)
                {
                    fileName = "Wallpaper_" + i + ".jpg";
                    destFile = Path.Combine(targetPath, fileName);
                    File.Copy(s, destFile, true);
                    i++;
                }
            }
            else
            {
                Console.WriteLine("Source path does not exist!");
            }
        }

        public static void StartCopy()
        {
            string userName = GetUserName();
            string targetPath = @"C:\Users\" + userName + @"\Pictures\BingLockScreenImages";
            if (Directory.Exists(targetPath))
            {
                Console.WriteLine("That path exists already.");
                Console.WriteLine("Start copying...");
                CopyFiles(targetPath);
                Console.WriteLine("Copying finished!");
            }
            else
            {
                DirectoryInfo directory = Directory.CreateDirectory(targetPath);
                Console.WriteLine("The directory was created successfully at {0}.", Directory.GetCreationTime(targetPath));
                Console.WriteLine("Start copying...");
                CopyFiles(targetPath);
                Console.WriteLine("Copying finished!");
            }
        }
    }
}
