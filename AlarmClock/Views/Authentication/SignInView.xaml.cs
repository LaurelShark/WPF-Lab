﻿using AlarmClock.ViewModels.Authentication;

namespace AlarmClock.Views.Authentication
{
    /// <summary>
    /// Interaction logic for SignInView.xaml
    /// </summary>
    public partial class SignInView
    {
        #region Constructor
        internal SignInView()
        { 
            InitializeComponent();
            var signInViewModel = new SignInViewModel();
            DataContext = signInViewModel;
        }
        #endregion
    }
}
