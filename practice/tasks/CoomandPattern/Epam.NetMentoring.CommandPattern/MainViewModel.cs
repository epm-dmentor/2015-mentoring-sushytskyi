using System.Windows.Input;
using Microsoft.TeamFoundation.MVVM;

namespace Epam.NetMentoring.CommandPattern
{
    public class MainViewModel : ViewModelBase, IMentoringModel
    {
        private string _text = "";
        private readonly ICommandProvider _comProvider;

        public MainViewModel(ICommandProvider comProvider)
        {
            _comProvider = comProvider;
        }

        private void Execute(object commandName)
        {
            _comProvider.GetCommand(commandName.ToString()).Invoker = this;
            _comProvider.GetCommand(commandName.ToString()).Execute(null);
        }

        private bool CanExecute(object commandName)
        {            
            return _comProvider.GetCommand(commandName.ToString()).CanExecute(null);
        }

        public ICommand ComandRouter
        {
            get
            {
                return new RelayCommand(Execute, CanExecute);
            }
        }

        private const string LastNamePropertyName = "Text";
        public string Text
        {
            get { return _text; }
            set
            {
                _text = value;
                RaisePropertyChanged(LastNamePropertyName);
            }
        }

    }


}
