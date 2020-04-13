using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labs
{
    public class ChangePersonCmd : AbstractCommand
    {
        private Person _beforeUpdate;
        private Person _updatedPerson;

        public ChangePersonCmd(Person beforeUpdate, Person updatedPerson)
        {
            _beforeUpdate = beforeUpdate;
            _updatedPerson = updatedPerson;
        }

        public override void doit()
        {
            _updatedPerson.updateTreeText();
            AppForm.getAppForm().MyTreeView.SelectedNode = _updatedPerson;
        }

        public override void redo()
        {
            switchPersons();
            doit();
        }

        public override void undo()
        {
            switchPersons();
            doit();
        }

        private void switchPersons()
        {
            Person temp = new Person(_updatedPerson.Name, _updatedPerson.LastName, _updatedPerson.Age, _updatedPerson.City);

            _updatedPerson.Name = _beforeUpdate.Name;
            _updatedPerson.LastName = _beforeUpdate.LastName;
            _updatedPerson.Age = _beforeUpdate.Age;
            _updatedPerson.City = _beforeUpdate.City;

            _beforeUpdate = temp;

        }
    }
}
