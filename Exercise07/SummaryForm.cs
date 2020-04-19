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
                UpdateLabels();

            }
        }

        private void SummaryForm_Load(object sender, EventArgs e)
        {
            ArrayList people = PersonDataModel.getDataModel().getAllPersons();

            foreach (Person person in people)
            {
                UpsertPeopleInCity(person.City);
            }

            UpdateLabels();
        }

        private void UpsertPeopleInCity(string city)
        {
            if (PeopleInCity.ContainsKey(city))
            {
                PeopleInCity[city] += 1;
            }
            else
            {
                PeopleInCity.Add(city, 1);
            }
        }

        private void UpdateLabels()
        {
            try
            {
                fromRijekaLabel.Text = Convert.ToString(PeopleInCity["Rijeka"]);
                fromSplitLabel.Text = Convert.ToString(PeopleInCity["Split"]);
                fromZagrebLabel.Text = Convert.ToString(PeopleInCity["Zagreb"]);

            }
            catch 
            {
            }
        }

    }
}
