using System;
using System.Drawing;
using System.Windows.Forms;

namespace Task1
{
    partial class AddPersonForm
    {
        private Button okButton;
        private Button cancelButton;
        private Label labelName;
        private TextBox textBoxName;
        private Label labelLastName;
        private TextBox textBoxLastName;
        private Label labelAge;
        private TextBox textBoxAge;
        private Label labelCity;
        private ComboBox comboBoxCity;

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
            okButton = new Button();
            cancelButton = new Button();
            labelName = new Label();
            textBoxName = new TextBox();
            labelLastName = new Label();
            textBoxLastName = new TextBox();
            labelAge = new Label();
            textBoxAge = new TextBox();
            labelCity = new Label();
            comboBoxCity = new ComboBox();

            //
            // OK Button
            //
            okButton.DialogResult = DialogResult.OK;
            okButton.Enabled = false; // Enable when all values are valid
            okButton.Name = "okButton";
            okButton.Location = new Point(80, 160);
            okButton.Size = new Size(80, 30);
            okButton.TabIndex = 5;
            okButton.Text = "Add";

            //
            // Cancel Button
            //
            cancelButton.DialogResult = DialogResult.Cancel;
            cancelButton.Name = "cancelButton";
            cancelButton.Location = new Point(195, 160);
            cancelButton.Size = new Size(80, 30);
            cancelButton.TabIndex = 6;
            cancelButton.Text = "Cancel";

            // 
            // labelName
            //
            labelName.Location = new Point(10, 10);
            labelName.Text = "Name:";
            labelName.Name = "labelName";
            labelName.Size = new Size(50, 22);

            //
            // textBoxName
            //
            textBoxName.Location = new Point(80, 10);
            textBoxName.Size = new Size(200, 22);
            textBoxName.Name = "textBoxName";
            textBoxName.TabIndex = 1;
            textBoxName.Text = "";
            textBoxName.TextChanged += new System.EventHandler(textBoxValidate_TextChanged);

            // 
            // labelLastName
            //
            labelLastName.Location = new Point(10, 40);
            labelLastName.Text = "Last Name:";
            labelLastName.Name = "labelLastName";
            labelLastName.Size = new Size(70, 22);

            //
            // textBoxLastName
            //
            textBoxLastName.Location = new Point(80, 40);
            textBoxLastName.Size = new Size(200, 22);
            textBoxLastName.Name = "textBoxLastName";
            textBoxLastName.TabIndex = 2;
            textBoxLastName.Text = "";
            textBoxLastName.TextChanged += new System.EventHandler(textBoxValidate_TextChanged);


            // 
            // labelAge
            //
            labelAge.Location = new Point(10, 70);
            labelAge.Text = "Age:";
            labelAge.Name = "labelAge";
            labelAge.Size = new Size(50, 22);

            //
            // textBoxAge
            //
            textBoxAge.Location = new Point(80, 70);
            textBoxAge.Size = new Size(200, 22);
            textBoxAge.Name = "textBoxAge";
            textBoxAge.TabIndex = 3;
            textBoxAge.Text = "";
            textBoxAge.TextChanged += new System.EventHandler(textBoxValidate_TextChanged);

            // 
            // labelCity
            //
            labelCity.Location = new Point(10, 100);
            labelCity.Text = "City:";
            labelCity.Name = "labelCity";
            labelCity.Size = new Size(50, 22);

            //
            // comboBoxCity
            //
            comboBoxCity.Location = new Point(80, 100);
            comboBoxCity.Size = new Size(200, 22);
            comboBoxCity.TabIndex = 4;
            comboBoxCity.Items.AddRange(new object[]
            {
                "Split",
                "Zagreb",
                "Osijek",
                "Zadar",
                "Karlovac"
            });
            comboBoxCity.TextChanged += new System.EventHandler(textBoxValidate_TextChanged);


            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 300);
            this.Text = "AddPersonForm";

            this.Controls.AddRange(new Control[]
            {
                okButton,
                cancelButton,
                labelName,
                textBoxName,
                labelLastName,
                textBoxLastName,
                labelAge,
                textBoxAge,
                labelCity,
                comboBoxCity
            });

            this.AcceptButton = okButton;
            this.CancelButton = cancelButton;
        }

        private void textBoxValidate_TextChanged(object sender, EventArgs e)
        {
            bool isInt = int.TryParse(textBoxAge.Text, out int age);

            if (isInt && age >= 0 && textBoxName.Text.Length > 0 && 
                textBoxLastName.Text.Length > 0 && comboBoxCity.Text.Length > 0)
            {
                okButton.Enabled = true;
            } else
            {
                okButton.Enabled = false;
            }
        }

        #endregion

        public string getNameInput()
        {
            return textBoxName.Text.Trim();
        }
        public string getLastNameInput()
        {
            return textBoxLastName.Text.Trim();
        }
        public int getAgeInput()
        {
            return int.Parse(textBoxAge.Text.Trim());
        }
        public string getCityInput()
        {
            return comboBoxCity.Text.Trim();
        }
    }
}