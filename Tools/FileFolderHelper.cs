using System;
using System.IO;

namespace Tools
{
    public static class FileFolderHelper
    {
        private static readonly string AppDataPath =
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

        internal static readonly string ClientFolderPath =
            Path.Combine(AppDataPath, "DirectoryFileBrowser");

        internal static readonly string LogFolderPath =
            Path.Combine(ClientFolderPath, "logger_output");

        internal static readonly string LogFilepath = Path.Combine(LogFolderPath,
            "App_" + DateTime.Now.ToString("yyyy_MM_dd") + ".txt");

        public static readonly string LastUserFilePath =
            Path.Combine(ClientFolderPath, "LastUser.dfb");

        public static FileInfo LastUserFile
        {
            get { return new FileInfo(LastUserFilePath); }
        }

        public static void CheckAndCreateFile(string filePath)
        {
            try
            {
                FileInfo file = new FileInfo(filePath);
                if (!file.Directory.Exists)
                {
                    file.Directory.Create();
                }
                if (!file.Exists)
                {
                    file.Create().Close();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        internal static void FileDelete(string filePath)
        {
            try
            {
                FileInfo file = new FileInfo(filePath);
                if (file.Exists)
                {
                    file.Delete();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
