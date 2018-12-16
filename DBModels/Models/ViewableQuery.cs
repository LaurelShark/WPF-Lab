using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBModels.Models
{
    public class ViewableQuery
    {
        #region Fields
        private string path;
        private DateTime date;
        #endregion

        #region Properties
        public string Path
        {
            get { return path; }
            private set { path = value; }
        }
        public DateTime Date
        {
            get { return date; }
            private set { date = value; }
        }
        #endregion

        public ViewableQuery(string path, DateTime date)
        {
            Path = path;
            Date = date;
        }
    }
}
