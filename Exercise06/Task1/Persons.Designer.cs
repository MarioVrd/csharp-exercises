using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Task1
{
    partial class Persons
    {
        List<Person> persons = new List<Person>()
            {
                new Person("John", "Doe", "London", 32),
                new Person("Mary", "Smith", "Dublin", 23),
                new Person("Kevin", "Johnson", "Manchester", 47)
            };


        private ListView personsList;
        private MainMenu mainMenu;
        private MenuItem menuItem_NewPerson;
        private ContextMenu viewEditContextMenu;


        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            mainMenu = new MainMenu();
            menuItem_NewPerson = new MenuItem("New Person");
            personsList = new ListView();

            //
            // mainMenu
            //
            mainMenu.MenuItems.Add(menuItem_NewPerson);

            //
            // menuItem_NewPerson
            //
            menuItem_NewPerson.Click += new System.EventHandler(menuItem_NewPerson_Click);

            //
            // personsList
            //
            personsList.Bounds = new Rectangle(new Point(10, 10), new Size(400, 400));

            // Set the view to show details.
            personsList.View = View.Details;
            // Allow the user to rearrange columns.
            personsList.AllowColumnReorder = true;
            // Select the item and subitems when selection is made.
            personsList.FullRowSelect = true;
            // Display grid lines.
            personsList.GridLines = true;

            // Create columns for the items and subitems.
            // Width of -2 indicates auto-size.
            personsList.Columns.Add("Name", -2, HorizontalAlignment.Left);
            personsList.Columns.Add("Last Name", -2, HorizontalAlignment.Left);


            viewEditContextMenu = new ContextMenu();

            personsList.ContextMenu = viewEditContextMenu;

            personsList.Click += new System.EventHandler(viewEditContextMenu_Click);

            foreach (var person in persons)
            {
                ListViewItem item = new ListViewItem(person._name);
                item.SubItems.Add(person._lastName);
                item.ToolTipText = "Test";
                personsList.Items.Add(item);
            }

            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);

            this.Name = "Exercise 06 - Persons";
            this.Text = "Exercise 06 - Persons";
            this.Menu = mainMenu;
            this.Controls.Add(personsList);
        }

        private void menuItem_NewPerson_Click(object sender, EventArgs e)
        {
            AddPersonForm addPersonForm = new AddPersonForm();
            addPersonForm.ShowDialog(this);

            if (addPersonForm.DialogResult == DialogResult.OK)
            {
                Person newPerson = new Person(addPersonForm.getNameInput(),
                    addPersonForm.getLastNameInput(),
                    addPersonForm.getCityInput(),
                    addPersonForm.getAgeInput());

                persons.Add(newPerson);

                ListViewItem item = new ListViewItem(newPerson._name);
                item.SubItems.Add(newPerson._lastName);
                personsList.Items.Add(item);
            }
        }

        private void viewEditContextMenu_Click(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection selectedItems = personsList.SelectedItems;
            this.Text = selectedItems.GetType().Name;
        }

        #endregion
    }
}

