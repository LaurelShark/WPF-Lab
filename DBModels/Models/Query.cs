using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBModels.Models
{
    public class Query
    {
        #region Fields
        private int userId;
        private User user;
        private int id;
        private string path;
        private DateTime date;
        #endregion

        #region Properties
        public int UserId
        {
            get { return userId; }
            set { userId = value; }
        }
        public User User
        {
            get { return user; }
            internal set { user = value; }
        }
        public int Id
        {
            get { return id; }
            internal set { id = value; }
        }
        public string Path
        {
            get { return path; }
            set { path = value; }
        }
        public DateTime Date
        {
            get { return date; }
            internal set { date = value; }
        }
        #endregion

        public Query()
        {
            Date = DateTime.Now;
        }

        internal Query(string path, DateTime date)
        {
            Path = path;
            Date = date;
        }

        public void DeleteDatabaseValues()
        {
            user = null;
        }
    }
}
