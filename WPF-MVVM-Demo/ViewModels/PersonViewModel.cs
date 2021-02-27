using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WPF_MVVM_Demo.ViewModels
{
    //For simplicity all elements required to make this viewmodel work and bindable are built into this class.
    //INotifyPropertyChanged is the minumum required interface to use the built in WPF binding.
    //Developers usually place the interface in a base class since it can be considered redundant.
    public class PersonViewModel : INotifyPropertyChanged
    {
        private string firstName;
        private string lastName;
        private int age;

        //This is the event fired when a property changes.
        public event PropertyChangedEventHandler PropertyChanged;
        private void Notify([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string FirstName
        {
            get { return firstName; }
            set
            {
                firstName = value;
                Notify();
            }
        }

        public string LastName
        {
            get { return lastName; }
            set
            {
                lastName = value;
                Notify();
            }
        }

        public int Age
        {
            get { return age; }
            set
            {
                age = value;
                Notify();
            }
        }
    }
}
