using System;
using System.ComponentModel;
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
    internal class SignInViewModel : INotifyPropertyChanged
    {
        #region Fields
        private string _login;
        private string _password;
        #endregion

        #region Commands
        private ICommand _signInCommand;
        private ICommand _signUpCommand;
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
        #endregion

        #region Commands
        public ICommand SignInCommand
        {
            get { return _signInCommand ?? (_signInCommand = new BindingCommand<object>(SignInExecute, SignInCanExecute)); }
        }

        public ICommand SignUpCommand
        {
            get { return _signUpCommand ?? (_signUpCommand = new BindingCommand<object>(SignUpView, (obj) => true)); }
        }

        public ICommand ExitCommand
        {
            get { return _exitCommand ?? (_exitCommand = new BindingCommand<object>(ExitExecute, (obj) => true)); }
        }

        public object NavigationManagers { get; private set; }
        #endregion

        private void SignUpView(object obj)
        {
            NavigationManager.Instance.Navigate(ModesEnum.SignUp);
        }

        private bool SignInCanExecute(object obj)
        {
            return !String.IsNullOrWhiteSpace(_login) && !String.IsNullOrWhiteSpace(_password);
        }

        private async void SignInExecute(object obj)
        {
            LoaderManager.Instance.ShowLoader();
            var res = await Task.Run(() =>
            {
                LabUser currUser;
                try
                {
                    currUser = DBManager.GetUserByLogin(_login);
                    if (currUser == null)
                    {
                        Logger.Log("User doesnt exist");
                        MessageBox.Show("User doesnt exist");
                        return false;
                    }
                    Logger.Log("User found.");
                    if (!currUser.PasswordMatch(_password))
                    {
                        Logger.Log("Passwords do not match");
                        MessageBox.Show("Wrong password");
                        return false;
                    }
                    DBManager.UpdateLoggedInDateToCurrent(currUser);
                    SessionManager.User = currUser;
                    SessionManager.SerializeCurrentUser();
                    Logger.Log("Logged in. New session started");
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    Logger.Log("Login failed", e);
                    return false;
                }
                return true;
            });
            LoaderManager.Instance.HideLoader();
            if (res)
            {
                Password = "";
                Login = "";
                NavigationManager.Instance.Navigate(ModesEnum.Tree);
            }
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
