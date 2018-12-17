using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Windows.Forms;
using Tools;

namespace DBModels.Models
{
    [Serializable]
    [Table("UsersTable")]
    public class LabUser
    {

        #region Fields
        
        public int userId;
        private string name;
        private string surname;
        private string _login;
        private string _email;
        private string password;
        private DateTime lastLoginDate;
        private ICollection<Query> query;
        #endregion


        #region Properties
        [Key]
        public int UserId
        {
            get
            {
                return userId;
            }
            internal set
            {
                userId = value;
            }
        }
        public string Name
        {
            get
            {
                return name;
            }
            internal set
            {
                name = value;
            }
        }
        public string Surname
        {
            get
            {
                return surname;
            }
            set
            {
                surname = value;
            }
        }
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
            }
        }

        public string Login
        {
            get
            {
                return _login;
            }
            set
            {
                _login = value;
            }
        }
        public string Password
        {
            get
            {
                return password;
            }
            internal set
            {
                password = value;
            }
        }
        public DateTime LastLoginDate
        {
            get
            {
                return lastLoginDate;
            }
            set
            {
                lastLoginDate = value;
            }
        }

        public ICollection<Query> Query
        {
            get { return query; }
            set { query = value; }
        }
        #endregion

        public LabUser(string firstName, string lastName, string email, string login, string password) : this()
        {
            name = firstName;
            surname = lastName;
            _email = email;
            _login = login;
            lastLoginDate = DateTime.Now;

            Password = Encrypting.ConvertToMd5(password);
        }

        public bool PasswordMatch(string inputPwd)
        {
            try
            {
                string hashedinputPwd = Encrypting.ConvertToMd5(inputPwd);
                return hashedinputPwd.Equals(Password);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
        }

        public bool CheckPassword(LabUser userCandidate)
        {
            try
            {
                return password == userCandidate.password;
            }
            catch (Exception)
            {
                return false;
            }
        }

        internal LabUser()
        {
            LastLoginDate = DateTime.Now;
        }

    }
}
