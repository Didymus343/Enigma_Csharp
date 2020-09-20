using Enigma.StarField;
using System;
using System.ComponentModel;
using System.Windows.Input;

namespace Enigma.ViewModel
{
    class NavigationViewModel : INotifyPropertyChanged
    {
        public ICommand UserCommand { get; set; }

        public ICommand EnigmaCommand { get; set; }

        public ICommand StarFieldCommand { get; set; }

        private object selectedViewModel;

        public object SelectedViewModel

        {

            get { return selectedViewModel; }

            set { selectedViewModel = value; OnPropertyChanged("SelectedViewModel"); }

        }



        public NavigationViewModel()

        {

            UserCommand = new BaseCommand(OpenUser);

            EnigmaCommand = new BaseCommand(OpenEnigma);

            StarFieldCommand = new BaseCommand(OpenStarField);

        }

        private void OpenUser(object obj)

        {

            SelectedViewModel = new UserViewModel();

        }

        private void OpenEnigma(object obj)

        {

            SelectedViewModel = new EnigmaViewModel();

        }

        private void OpenStarField(object obj)

        {

            SelectedViewModel = new StarFieldViewModel();

        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propName)

        {

            if (PropertyChanged != null)

            {

                PropertyChanged(this, new PropertyChangedEventArgs(propName));

            }

        }
    }

    public class BaseCommand : ICommand
    {
        private Predicate<object> _canExecute;
        private Action<object> _method;
        public event EventHandler CanExecuteChanged;

        public BaseCommand(Action<object> method)
            : this(method, null)
        {
        }

        public BaseCommand(Action<object> method, Predicate<object> canExecute)
        {
            _method = method;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            if (_canExecute == null)
            {
                return true;
            }

            return _canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            _method.Invoke(parameter);
        }
    }
}
