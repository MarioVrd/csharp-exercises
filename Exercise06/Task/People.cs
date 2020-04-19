using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task
{
    public partial class People : Form
    {
        public People()
        {
            InitializeComponent();
        }

        // Fill form with existing data on load
        private void People_Load(object sender, EventArgs e)
        {
            List<Person> people = DataModel.GetPeople();

            peopleListView.Items.Clear();

            people.ForEach(person =>
            {
                ListViewItem listViewItem = new ListViewItem(person._firstName);
                listViewItem.SubItems.Add(person._lastName);
                listViewItem.Tag = person;
                peopleListView.Items.Add(listViewItem);
            });
        }

        // Show context menu on right click if clicked any item
        private void peopleListView_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (peopleListView.Focused)
                {
                    contextMenuStrip1.Show(Cursor.Position);

                }
            }
        }

        private void newPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PersonForm personForm = new PersonForm(PersonFormType.Add);
            personForm.ShowDialog(this);

            if (personForm.DialogResult == DialogResult.OK)
            {
                Person newPerson = new Person
                {
                    _firstName = personForm.getNameInput(),
                    _lastName = personForm.getLastNameInput(),
                    _age = personForm.getAgeInput(),
                    _city = personForm.getCityInput()
                };

                DataModel.AddPerson(newPerson);

                // Update list
                ListViewItem listViewItem = new ListViewItem(newPerson._firstName);
                listViewItem.SubItems.Add(newPerson._lastName);
                listViewItem.Tag = newPerson;
                peopleListView.Items.Add(listViewItem);

                personForm.Dispose();
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Person person = (Person)peopleListView.FocusedItem.Tag;

            PersonForm personForm = new PersonForm(PersonFormType.Edit, person);
            personForm.ShowDialog(this);

            if (personForm.DialogResult == DialogResult.OK)
            {
                person._firstName = personForm.getNameInput();
                person._lastName = personForm.getLastNameInput();
                person._age = personForm.getAgeInput();
                person._city = personForm.getCityInput();

                peopleListView.FocusedItem.SubItems.Clear();
                peopleListView.FocusedItem.Text = person._firstName;
                peopleListView.FocusedItem.SubItems.Add(person._lastName);

                personForm.Dispose();
            }
        }

        private void detailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Person person = (Person)peopleListView.FocusedItem.Tag;
            PersonForm personForm = new PersonForm(PersonFormType.View, person);
            personForm.ShowDialog(this);

        }
    }
}
