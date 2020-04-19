using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
    public class DataModel
    {
        private static List<Person> people = new List<Person>();

        public DataModel()
        {
            
        }

        public static List<Person> GetPeople()
        {
            return people;
        }

        public static void AddPerson(Person person)
        {
            people.Add(person);
        }

    }
}
