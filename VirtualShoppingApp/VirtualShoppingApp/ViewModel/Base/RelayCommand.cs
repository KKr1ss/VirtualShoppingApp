 using System;
using System.Windows.Input;

namespace VirtualShoppingApp.ViewModel.Base
{
    public class RelayCommand : ICommand
    {
        private Action action;
        public event EventHandler CanExecuteChanged = (sender, e) => { };
        public RelayCommand(Action action) => this.action = action;
        public bool CanExecute(object parameter) => true;
        public void Execute(object parameter) => action();
    }

    public class RelayCommand<T> : ICommand
    {
        private Action<T> action;
        public event EventHandler CanExecuteChanged = (sender, e) => { };
        public RelayCommand(Action<T> action) => this.action = action;
        public bool CanExecute(object parameter) => true;
        public void Execute(object parameter) => action((T)parameter);
    }
}
