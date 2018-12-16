using AlarmClock.Managers;
using AlarmClock.Tools;
using DBModels.Models;
using Managers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Tools;

namespace AlarmClock.ViewModels.Archive
{
    public class ArchiveViewModel : INotifyPropertyChanged
    {

        private ObservableCollection<ViewableQuery> _queriesHistory;

        public ObservableCollection<ViewableQuery> QueriesHistory
        {
            get { return _queriesHistory; }
            set { _queriesHistory = value; }
        }

        #region Commands
        private ICommand _fromArchiveToTreeView;
        #endregion

        #region Commands
        public ICommand FromArchiveToTreeView
        {
            get
            {
                return _fromArchiveToTreeView ?? (_fromArchiveToTreeView = new BindingCommand<object>(FromArchiveToTreeViewExecute, (obj) => true));
            }
        }
        #endregion

        internal ArchiveViewModel()
        {
            Logger.Log("Initializing history query view");
            QueriesHistory = new ObservableCollection<ViewableQuery>();
            PopulateDataGrid();
        }

        private void FromArchiveToTreeViewExecute(object obj)
        {
            NavigationManager.Instance.Navigate(ModesEnum.Tree);
        }

        private void PopulateDataGrid()
        {
            Logger.Log("Populating query history...");
            IEnumerable<Query> queries = DBManager.GetQueriesForUser(SessionManager.User);
            foreach (Query q in queries)
            {
                string path = q.Path;
                DateTime date = q.Date;
                QueriesHistory.Add(new ViewableQuery(path, date));
            }
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
