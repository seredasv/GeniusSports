using System.Collections.ObjectModel;

namespace Test.Core
{
    public class DataStorage : IDataStorage
    {
        public DataStorage()
        {
            Persons = new ObservableCollection<string>();

            Persons.Add("Ser gey");
            Persons.Add("And rey");
            Persons.Add("Ol eg");
            Persons.Add("Tom asz");
            Persons.Add("Gr eg");
        }

        public ObservableCollection<string> Persons { get; set; }

        public void AddPerson(string name, string surname)
        {
            Persons.Add($"{name} {surname}");
        }
    }
}