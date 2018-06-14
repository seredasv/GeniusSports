using System.Collections.ObjectModel;

namespace Test.Core
{
    public interface IDataStorage
    {
        ObservableCollection<string> Persons { get; set; }

        void AddPerson(string name, string surname);
    }
}