using System.Collections.Generic;

namespace WPF_MVVM_Demo.Models
{
    //Singleton
    public class PersonDb
    {
        //Mock Data
        private readonly List<Person> persons = new List<Person>
        {
            new Person
            {
                FirstName = "Michael",
                LastName = "Puckett",
                Age = 40
            },
            new Person
            {
                FirstName = "Erin",
                LastName = "Puckett",
                Age = 33
            }
        };

        PersonDb() { }
        public static PersonDb Instance { get; } = new PersonDb();

        //Access to mock data
        public IEnumerable<Person> Persons => persons;
    }
}
