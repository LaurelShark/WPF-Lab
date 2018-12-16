using System;
using AlarmClock.Views.AlarmClocks;
using AlarmClock.Views.Archive;
using AlarmClock.Views.Authentication;
using AlarmClock.Views.Tree;

namespace AlarmClock.Tools
{
    internal enum ModesEnum
    {
        SignIn,
        SignUp,
        Tree,
        Archive
    }

    internal class NavigationModel
    {
        private readonly IContentWindow _contentWindow;
        private SignInView signInView;
        private WindowTreeView windowTreeView;
        private ArchiveView archiveView;
        private SignUpView signUpView;

        internal NavigationModel(IContentWindow contentWindow)
        {
            _contentWindow = contentWindow;
        }

        internal void Navigate(ModesEnum mode)
        {
            switch (mode)
            {
                case ModesEnum.SignIn:
                    _contentWindow.ContentControl.Content = signInView ?? (signInView = new SignInView());
                    break;

                case ModesEnum.SignUp:
                    _contentWindow.ContentControl.Content = signUpView ?? (signUpView = new SignUpView());
                    break;

                case ModesEnum.Tree:
                    _contentWindow.ContentControl.Content = windowTreeView ?? (windowTreeView = new WindowTreeView());
                    break;

                case ModesEnum.Archive:
                    _contentWindow.ContentControl.Content = archiveView ?? (archiveView = new ArchiveView());
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(mode), mode, null);
            }
        }
    }
}