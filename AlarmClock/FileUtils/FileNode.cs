using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlarmClock.FileUtils
{
    public class FileNode : AbstractNode
    {
        public FileNode(string name) : base(name) { }

        public override bool IsDirectory()
        {
            return false;
        }
    }
}
