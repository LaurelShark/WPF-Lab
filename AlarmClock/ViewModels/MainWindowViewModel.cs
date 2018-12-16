using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using AlarmClock.Managers;
using AlarmClock.Properties;
using AlarmClock.Tools;
using Managers;
using Tools;

namespace AlarmClock.ViewModels
{
    class MainWindowViewModel : ILoaderOwner
    {

        #region Fields
        private Visibility _visibility = Visibility.Hidden;
        private bool _isEnabled = true;
        #endregion

        #region Properties
        public Visibility LoaderVisibility
        {
            get { return _visibility; }
            set
            {
                _visibility = value;
                OnPropertyChanged();
            }
        }

        public bool IsEnabled
        {
            get { return _isEnabled; }
            set
            {
                _isEnabled = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Constructors
        public MainWindowViewModel()
        {
            LoaderManager.Instance.Initialize(this);
        }
        #endregion

        internal void StartApplication()
        {
            if (SessionManager.IsLastSessionActive())
            {
                Logger.Log("Auto login: previous session was not finished");
                SessionManager.DeserializeLastUser();
                NavigationManager.Instance.Navigate(ModesEnum.Tree);
            }
            else
            {
                Logger.Log("Manual login");
                NavigationManager.Instance.Navigate(ModesEnum.SignIn);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
