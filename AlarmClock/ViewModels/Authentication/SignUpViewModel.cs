using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using AlarmClock.Managers;
//using AlarmClock.Models;
using AlarmClock.Properties;
using AlarmClock.Tools;
using DBModels;
using DBModels.Models;
using Managers;
using Tools;

[assembly: InternalsVisibleTo("Tests")]

namespace AlarmClock.ViewModels.Authentication
{
    class SignUpViewModel : INotifyPropertyChanged
    {

        #region Fields
        private string _login;
        private string _password;
        private string _firstName;
        private string _lastName;
        private string _email;
        #endregion

        #region Commands
        private ICommand _signUpCommand;
        private ICommand _backCommand;
        private ICommand _exitCommand;
        #endregion

        #region Properties
        public string Login
        {
            get { return _login; }
            set
            {
                _login = value;
                OnPropertyChanged();
            }
        }

        public string Password { private get { return _password; } set { _password = value; OnPropertyChanged(); } }

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                OnPropertyChanged();
            }
        }

        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                OnPropertyChanged();
            }
        }

        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Commands
        public ICommand SignUpCommand
        {
            get { return _signUpCommand ?? (_signUpCommand = new BindingCommand<object>(SignUpExecute, SignUpCanExecute)); }
        }

        public ICommand BackCommand
        {
            get { return _backCommand ?? (_backCommand = new BindingCommand<object>(BackExecute, (obj) => true)); }
        }

        public ICommand ExitCommand
        {
            get { return _exitCommand ?? (_exitCommand = new BindingCommand<object>(ExitExecute, (obj) => true)); }
        }

        public object NavigationManagers { get; private set; }
        #endregion

        private async void SignUpExecute(object obj)
        {
            LoaderManager.Instance.ShowLoader();
            var result = await Task.Run(() =>
            {
                try
                {
                    if (!new EmailAddressAttribute().IsValid(_email))
                    {
                        MessageBox.Show("email is not valid");
                        return false;
                    }
                    if (DBManager.GetUserByLogin(_login) != null)
                    {
                        MessageBox.Show("user doesnt exist");
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return false;
                }
                try
                {
                    var user = new User(_firstName, _lastName, _email, _login, _password);
                    DBManager.CreateNewUser(user);
                    SessionManager.User = user;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return false;
                }
                MessageBox.Show("succesfully logged in");
                return true;
            });
            LoaderManager.Instance.HideLoader();
            if (result)
            {
                Login = "";
                Password = "";
                FirstName = "";
                LastName = "";
                Email = "";
                NavigationManager.Instance.Navigate(ModesEnum.Tree);
            }
        }

        private void BackExecute(object obj)
        {
            NavigationManager.Instance.Navigate(ModesEnum.SignIn);
        }

        private bool SignUpCanExecute(object obj)
        {
            return !String.IsNullOrWhiteSpace(_login) && !String.IsNullOrWhiteSpace(_password) &&
                !String.IsNullOrWhiteSpace(_firstName) && !String.IsNullOrWhiteSpace(_lastName) &&
                !String.IsNullOrWhiteSpace(_email);
        }

        private void ExitExecute(object obj)
        {
            Logger.Log("Exit execute");
            MessageBox.Show("ShutDown");
            Environment.Exit(1);
        }

        #region EventsAndHandlers
        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        internal virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
        #endregion
    }
}
