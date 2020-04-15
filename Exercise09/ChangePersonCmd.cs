using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labs
{
    public class ChangePersonCmd : AbstractCommand
    {
        private Person _person;

        private string _prevName;
        private string _prevLastName;
        private int _prevAge;
        private string _prevCity;
        
        private string _newName;
        private string _newLastName;
        private int _newAge;
        private string _newCity;

        public ChangePersonCmd(Person person, string newName, string newLastName, int newAge, string newCity)
        {
            _person = person;

            _prevName = person.Name;
            _prevLastName = person.LastName;
            _prevAge = person.Age;
            _prevCity = person.City;
            
            _newName = newName;
            _newLastName = newLastName;
            _newAge = newAge;
            _newCity = newCity;
        }

        public override void doit()
        {
            _person.Name = _newName;
            _person.LastName = _newLastName;
            _person.Age = _newAge;
            _person.City = _newCity;

            _person.updateTreeText();
            
            AppForm.getAppForm().MyTreeView.SelectedNode = _person;
        }

        public override void redo()
        {
            doit();
        }

        public override void undo()
        {
            _person.Name = _prevName;
            _person.LastName = _prevLastName;
            _person.Age = _prevAge;
            _person.City = _prevCity;

            _person.updateTreeText();
            AppForm.getAppForm().MyTreeView.SelectedNode = _person;
        }

    }
}
