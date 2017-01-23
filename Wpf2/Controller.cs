using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Wpf2
{
    class Controller
    {
        private static Controller instance;
        private Repository repository;
        public Person CurrentPerson { get; private set; }
        public int PersonCount { get; private set; }
        public int PersonIndex { get; private set; }

        private Controller()
        {
            CurrentPerson = null;
            repository = new Repository();
            PersonCount = 0;
            PersonIndex = -1;
        }

        public static Controller GetInstance()
        {
            if (instance== null)
            {
                instance = new Controller();
            }
            return instance;
        }

        internal string GetFirstname() {
            String firstName = "";
            if (CurrentPerson != null) {
                firstName = CurrentPerson.FirstName;
            }
            return firstName;
        }

        internal String GetAge() {
            String age = "";
            if (CurrentPerson != null) {
                age = CurrentPerson.Age.ToString();
            }
            return age;
        }

        internal string GetTelephone() {
            String telephone = "";
            if (CurrentPerson != null) {
                telephone = CurrentPerson.Telephone;
            }
            return telephone;
        }

        internal string GetLastName() {
            String lastName = "";
            if (CurrentPerson != null) {
                lastName = CurrentPerson.LastName;
            }
            return lastName;
        }

        public void AddPerson(String fn, String ln, String age, String tel)
        {
            int ageValue;
            int.TryParse(age, out ageValue); 
            Person person = new Person(fn, ln, ageValue, tel);
            CurrentPerson = person;
            repository.AddPerson(person);
            PersonCount = repository.PersonList.Count();
            PersonIndex = PersonCount - 1;
        }

        public void DeletePerson()
        {
            if (CurrentPerson != null)
            {
                repository.RemovePerson(CurrentPerson);
                PersonCount = repository.PersonList.Count();
                if (PersonCount == 0) {
                    PersonIndex = -1;
                    CurrentPerson = null;
                }
                else {
                    if (PersonIndex == PersonCount) {
                        PersonIndex--;
                    }
                    CurrentPerson = repository.GetPersonAtIndex(PersonIndex);
                }
            }
        }

        public void NextPerson()
        {
            if (PersonIndex < PersonCount - 1)
            {
                PersonIndex++;
                CurrentPerson = repository.GetPersonAtIndex(PersonIndex);
            }
        }

        public void PrevPerson()
        {
            if (PersonIndex > 0)
            {
                PersonIndex--;
                CurrentPerson = repository.GetPersonAtIndex(PersonIndex);
            }
        }
    }
}
