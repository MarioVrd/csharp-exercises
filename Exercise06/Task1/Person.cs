using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Person
    {
        public string _name { get; set; }
        public string _lastName { get; set; }
        public string _city { get; set; }
        public int _age { get; set; }

        public Person(string name, string lastName, string city, int age)
        {
            _name = name;
            _lastName = lastName;
            _city = city;
            _age = age;
        }
    }
}
