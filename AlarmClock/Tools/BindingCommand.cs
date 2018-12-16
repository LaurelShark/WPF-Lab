using System;
using System.Windows.Input;

namespace AlarmClock.Tools
{
    public class BindingCommand<T> : ICommand
    {
        #region Fields
        readonly Action<T> _action;
        readonly Predicate<T> _predicate;

        #endregion

        #region Constructors
        /* public BindingCommand(Action<T> action)
             : this(action, null)
         {
         }
         */

        public BindingCommand(Action<T> action, Predicate<T> canExecute)
        {
            if (action != null)
                _action = action;
            else
                throw new ArgumentNullException(nameof(action));
            _predicate = canExecute;
        }
        #endregion

        public bool CanExecute(object parameter)
        {
            return _predicate.Invoke((T)parameter);
        }

        public void Execute(object parameter)
        {
            _action((T)parameter);
        }

        ///<summary>
        ///Occurs when changes occur that affect whether or not the command should execute.
        ///</summary>
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }



    }
}
