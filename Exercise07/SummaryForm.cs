using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Labs
{
    public partial class SummaryForm : Form
    {
        public Dictionary<string, int> PeopleInCity { get; private set; } = new Dictionary<string, int>();

        private Point location = new Point(30, 30);
        private int yDistance = 30;
        public List<Label> Labels { get; private set; } = new List<Label>();

        public SummaryForm()
        {
            InitializeComponent();

            PersonDataModel.getDataModel().PersonModelChanged += new PersonModelChangedEventHandler(this.consumeChangeInPersonDataModel);
        }

        private void consumeChangeInPersonDataModel(object sender, PersonDataModelChangedEventArgs e)
        {
            if (e.IsAdded)
            {
                UpsertPeopleInCity(e.PersonInChange.City);
            }
        }

        private void SummaryForm_Load(object sender, EventArgs e)
        {
            ArrayList people = PersonDataModel.getDataModel().getAllPersons();

            foreach (Person person in people)
            {
                UpsertPeopleInCity(person.City);
            }
        }

        private void CreateLabel(string city)
        {
            Label label = new Label();
            label.AutoSize = true;
            label.Location = location;
            label.Name = city;
            label.Text = $"Persons from { city }: { PeopleInCity[city] }";
            label.Visible = true;

            this.Controls.Add(label);
            Labels.Add(label);

            location.Y += yDistance;
        }

        private void UpsertPeopleInCity(string city)
        {
            if (PeopleInCity.ContainsKey(city))
            {
                PeopleInCity[city] += 1;

                UpdateLabel(city);
            }
            else
            {
                PeopleInCity.Add(city, 1);

                CreateLabel(city);
            }
        }

        private void UpdateLabel(string city)
        {
            Label output = Labels.Where(label => label.Name == city).FirstOrDefault();
            output.Text = $"Persons in { city }: { Convert.ToString(PeopleInCity[city]) }";
        }

    }
}
