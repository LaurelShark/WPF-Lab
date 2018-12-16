using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlarmClock.FileUtils
{
    public abstract class AbstractNode
    {
        public string Name
        {
            get;
            private set;
        }

        private List<AbstractNode> _children;

        public List<AbstractNode> Children
        {
            get { return new List<AbstractNode>(_children); }
            private set { _children = value; }
        }

        public AbstractNode(string name, List<AbstractNode> children = null)
        {
            Name = name;
            Children = children ?? new List<AbstractNode>();
        }

        public abstract bool IsDirectory();
    }
}
