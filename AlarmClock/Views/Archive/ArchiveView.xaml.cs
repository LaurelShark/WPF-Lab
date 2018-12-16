using AlarmClock.ViewModels.Archive;
using Managers;
using System.Windows.Controls;

namespace AlarmClock.Views.Archive
{
    /// <summary>
    /// Interaction logic for ArchiveView.xaml
    /// </summary>
    public partial class ArchiveView : UserControl
    {
        public ArchiveView()
        {
            InitializeComponent();
            string fullName = SessionManager.User.Name + " " + SessionManager.User.Surname;
            textBlockFullName.Text = fullName;
            var _archiveViewModel = new ArchiveViewModel();
            DataContext = _archiveViewModel;
        }
    }
}
