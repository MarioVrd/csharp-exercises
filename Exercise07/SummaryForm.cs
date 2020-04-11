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
        public SummaryForm()
        {
            InitializeComponent();

            PersonDataModel.getDataModel().PersonModelChanged += new PersonModelChangedEventHandler(this.consumeChangeInPersonDataModel);

            
        }

        private void consumeChangeInPersonDataModel(object sender, PersonDataModelChangedEventArgs e)
        {
            if (e.IsAdded)
            {
                if (e.PersonInChange.City.Equals("Split"))
                {
                    int current = Convert.ToInt32(fromSplitLabel.Text);
                    fromSplitLabel.Text = Convert.ToString(current + 1);
                }
                else if (e.PersonInChange.City.Equals("Zagreb"))
                {
                    int current = Convert.ToInt32(fromZagrebLabel.Text);
                    fromZagrebLabel.Text = Convert.ToString(current + 1);
                }
                else if (e.PersonInChange.City.Equals("Rijeka"))
                {
                    int current = Convert.ToInt32(fromRijekaLabel.Text);
                    fromRijekaLabel.Text = Convert.ToString(current + 1);
                }
            }
        }

        private void SummaryForm_Load(object sender, EventArgs e)
        {
            ArrayList people = PersonDataModel.getDataModel().getAllPersons();
            int fromSplit = 0;
            int fromZagreb = 0;
            int fromRijeka = 0;

            foreach (Person person in people)
            {
                if (person.City.Equals("Split"))
                {
                    fromSplit += 1;
                }
                else if (person.City.Equals("Zagreb"))
                {
                    fromZagreb += 1;
                }
                else if (person.City.Equals("Rijeka"))
                {
                    fromRijeka += 1;
                }
            }

            fromSplitLabel.Text = fromSplit.ToString();
            fromZagrebLabel.Text = fromZagreb.ToString();
            fromRijekaLabel.Text = fromRijeka.ToString();
        }
    }
}
