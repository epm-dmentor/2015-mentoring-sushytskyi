using System;
using System.Windows.Input;
using Microsoft.TeamFoundation.MVVM;

namespace Epam.NetMentoring.CommandPattern
{
    public interface IMentoringCommand : ICommand
    {
        ViewModelBase Invoker { get; set; }
    }

    class MyAppCommand : IMentoringCommand
    {
        private readonly Func<string> _function;
        public ViewModelBase Invoker { get; set; }

        public MyAppCommand(Func<string> f)
        {
            _function = f;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            var model = Invoker as IMentoringModel;
            if (model != null)
                model.Text = _function();
            else
                _function();
        }
    }
}
