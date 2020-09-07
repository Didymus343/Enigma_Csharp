using Enigma.Model;
using System.ComponentModel;

namespace Enigma.ViewModel
{
    public class UserViewModel: INotifyPropertyChanged
    {
        private User user;

        public UserViewModel()
        {
            user = new User
            {
                FirstName = "Thomas",
                LastName = "Jansen"
            };

        }


        public string FirstName
        {
            get { return user.FirstName; }
            set
            {
                if (user.FirstName.Equals(value)) return;

                user.FirstName = value;
            }
        }

        public string LastName
        {
            get { return user.LastName; }
            set
            {
                if (user.LastName.Equals(value)) return;

                user.LastName = value;
            }
        }

        public string FullName
        {
        get { return FirstName + " " + LastName; }
                
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChange(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}
