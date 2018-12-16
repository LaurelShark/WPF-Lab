using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlarmClock.FileUtils
{
    class Utils
    {
        public static AbstractNode GetFileTreeByDirectoryPath(string path)
        {
            try
            {
                DirectoryInfo info = new DirectoryInfo(path);
                if (info.Exists)
                    return new DirectoryNode(path, BuildFileTree(info));
                else
                    throw new ReadException("Error! Path either doesn't exist or isn't a directory", null);
            }
            catch (ReadException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                string msg = String.Format("Error! Failed to read path '{0}'. Exception '{1}' occurred.",
                    path, e.GetType().ToString());
                throw new ReadException(msg, e);
            }
        }

        private static List<AbstractNode> BuildFileTree(DirectoryInfo directory)
        {
            IEnumerable<DirectoryNode> dirs = directory.GetDirectories()
                .Select(dir => new DirectoryNode(dir.Name, BuildFileTree(dir)));
            IEnumerable<FileNode> files = directory.GetFiles()
                .Select(file => new FileNode(file.Name));
            return dirs.Concat<AbstractNode>(files)
                .ToList();
        }
    }

    class ReadException : Exception
    {
        public ReadException(string msg, Exception cause) : base(msg, cause)
        { }
    }
}
