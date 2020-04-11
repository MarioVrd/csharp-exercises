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

        private void People_Load(object sender, EventArgs e)
        {
            List<Person> people = DataModel.GetPeople();

            people.ForEach(person =>
            {
                ListViewItem listViewItem = new ListViewItem(person._firstName);
                listViewItem.SubItems.Add(person._lastName);
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
            PersonForm personForm = new PersonForm(1);
            personForm.ShowDialog(this);

            if (personForm.DialogResult == DialogResult.OK)
            {
                Person newPerson = new Person
                {
                    _id = DataModel.GenerateID(),
                    _firstName = personForm.getNameInput(),
                    _lastName = personForm.getLastNameInput(),
                    _age = personForm.getAgeInput(),
                    _city = personForm.getCityInput()
                };

                DataModel.AddPerson(newPerson);

                // Update list
                ListViewItem listViewItem = new ListViewItem(newPerson._firstName);
                listViewItem.SubItems.Add(newPerson._lastName);
                listViewItem.Tag = newPerson._id;
                peopleListView.Items.Add(listViewItem);

                personForm.Dispose();
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(peopleListView.FocusedItem.Tag);
            Person person = DataModel.GetPerson(id);

            PersonForm personForm = new PersonForm(2, person);
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
            int id = Convert.ToInt32(peopleListView.FocusedItem.Tag);
            Person person = DataModel.GetPerson(id);
            PersonForm personForm = new PersonForm(3, person);
            personForm.ShowDialog(this);

        }
    }
}
