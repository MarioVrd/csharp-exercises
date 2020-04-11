using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
    public class DataModel
    {
        private static int id = 1;
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

        public static Person GetPerson(int id)
        {
            return people.Find(person => person._id == id);
        }

        public static int GenerateID()
        {
            return id++;
        }
    }
}
