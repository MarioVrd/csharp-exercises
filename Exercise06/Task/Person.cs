using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
    public class Person
    {
        public int _id { get; set; }
        public string _firstName { get; set; }
        public string _lastName { get; set; }
        public string _city { get; set; }
        public int _age { get; set; }

        public Person()
        {

        }

        public Person(string firstName, string lastName, string city, int age)
        {
            _firstName = firstName;
            _lastName = lastName;
            _city = city;
            _age = age;
        }
    }
}
