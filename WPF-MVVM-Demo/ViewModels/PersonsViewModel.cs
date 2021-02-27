using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using WPF_MVVM_Demo.Models;

namespace WPF_MVVM_Demo.ViewModels
{
    //For simplicity all elements required to make this viewmodel work and bindable are built into this class.
    //INotifyPropertyChanged is the minumum required interface to use the built in WPF binding.
    //Developers usually place the interface in a base class since it can be considered redundant.
    public class PersonsViewModel : INotifyPropertyChanged
    {
        private bool isLoading;

        //This is the event fired when a property changes.
        public event PropertyChangedEventHandler PropertyChanged;

        public PersonsViewModel()
        {
            LoadAsynchronously();
        }

        public bool IsLoading
        {
            get { return isLoading; }
            //The set if private because we only want the ViewModel controlling this property.
            private set
            {
                isLoading = value;

                //Typically this method below is overriden in a base class and uses the [CallerMemberName] attribute to make code less redundant.
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsLoading)));
            }
        }

        //ObservableCollections have also built in bindings so make them readonly and use the Clear, Add, Remove, ... methods
        //You will notice that at the base they also inherit from INofityProperyChanged 
        //See PersonViewModel for example of this.
        public ObservableCollection<PersonViewModel> Persons { get; } = new ObservableCollection<PersonViewModel>();

        private async void LoadAsynchronously()
        {
            //When setting this it will also trigger the PropertyChanged event and pass IsLoading as the name of the property.
            //In XAML, when binding, it's wired up to automatically look for this.
            IsLoading = true;

            //Simulate some latency
            await Task.Delay(1500);

            foreach (var person in PersonDb.Instance.Persons)
            {
                Persons.Add(new PersonViewModel
                {
                    FirstName = person.FirstName,
                    LastName = person.LastName,
                    Age = person.Age
                });
            }

            IsLoading = false;
        }
    }
}
