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
    public partial class PersonForm : Form
    {
        public PersonForm()
        {
            InitializeComponent();
        }

        public PersonForm(PersonFormType type) : this()
        {
            switch (type)
            {
                case PersonFormType.Add:
                    okButton.Text = "Add";
                    break;
                case PersonFormType.Edit:
                    okButton.Text = "Edit";
                    break;
                case PersonFormType.View:
                    okButton.Text = "OK";
                    cancelButton.Visible = false;
                    nameInput.Enabled = false;
                    lastNameInput.Enabled = false;
                    ageInput.Enabled = false;
                    cityInput.Enabled = false;
                    break;
                default:
                    break;
            }
        }

        public PersonForm(PersonFormType type, Person person) : this(type)
        {
            nameInput.Text = person._firstName;
            lastNameInput.Text = person._lastName;
            ageInput.Text = person._age.ToString();
            cityInput.Text = person._city;
        }

        public string getNameInput()
        {
            return nameInput.Text.Trim();
        }

        public string getLastNameInput()
        {
            return lastNameInput.Text.Trim();
        }

        public int getAgeInput()
        {
            return Convert.ToInt32(ageInput.Text.Trim());
        }

        public string getCityInput()
        {
            return cityInput.Text.Trim();
        }

        private void validateInput_TextChanged(object sender, EventArgs e)
        {
            bool isInt = int.TryParse(ageInput.Text, out int age);

            if (isInt && age >= 0 && nameInput.Text.Length > 0 &&
                lastNameInput.Text.Length > 0 && cityInput.Text.Length > 0)
            {
                okButton.Enabled = true;
            }
            else
            {
                okButton.Enabled = false;
            }
        }

    }
}
