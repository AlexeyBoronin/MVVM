using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;



namespace MVVM
{
    class RelayCommand : ICommand
    {
        private Action<object?> _execute;
        private Func<object?, bool>? _executeFunc;



        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }



        public RelayCommand(Action<object?> execute, Func<object?, bool>? executeFunc = null)
        {
            _execute = execute;
            _executeFunc = executeFunc;
        }
        public bool CanExecute(object? parameter)
        {
            return _executeFunc == null || this._executeFunc(parameter);
        }
        public void Execute(object? parameter)
        {
            _execute(parameter);
        }
    }
}