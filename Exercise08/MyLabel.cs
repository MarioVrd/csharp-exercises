using System;
using System.Windows.Forms;
using System.Drawing;

namespace Labs
{
    /// <summary>
    /// Summary description for MyLabel.
    /// </summary>
    public class MyLabel : System.Windows.Forms.Label
    {
        private bool _isOdd;
        private int _index;

        public MyLabel(int index)
        {
            int width = 250;
            int height = 80;

            _index = index;

            this.Text = System.Convert.ToString(index);
            this.Size = new Size(width, height);
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;

            this.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(238)));
            this.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.AllowDrop = true;

            int n = index / 2;
            if ((index % 2) == 0)
            {
                _isOdd = false;
                this.Location = new Point(width, (n - 1) * height);
            }
            else
            {
                _isOdd = true;
                this.Location = new Point(0, n * height);
            }

            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.MyLabel_DragEnter);
            this.DragLeave += new System.EventHandler(this.MyLabel_DragLeave);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MyLabel_DragDrop);

            this.MouseDown += MyLabel_MouseDown;
        }

        private void MyLabel_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            MyLabel label = (MyLabel)sender;
            ListViewItem lvi = (ListViewItem)e.Data.GetData(DataFormats.Serializable);
            Person inMovePerson = (Person)lvi.Tag;

            bool isOddInMovePerson;
            if (inMovePerson.Index % 2 == 0)
            {
                isOddInMovePerson = false;
            }
            else
            {
                isOddInMovePerson = true;
            }

            if (label.Tag == null && (isOddInMovePerson == this._isOdd))
            {
                label.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                e.Effect = DragDropEffects.Move;
            }
        }

        private void MyLabel_DragLeave(object sender, System.EventArgs e)
        {
            MyLabel label = (MyLabel)sender;
            if (label.BorderStyle == System.Windows.Forms.BorderStyle.FixedSingle)
            {
                label.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            }
        }

        private void MyLabel_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            ListViewItem lvi = (ListViewItem)e.Data.GetData(DataFormats.Serializable);
            Person dropedPerson = (Person)lvi.Tag;

            this.Text = dropedPerson.Name + " " + dropedPerson.LastName;
            this.Tag = lvi;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;

            this.ContextMenu = new ContextMenu();
            this.ContextMenu.Popup += ContextMenu_Popup;
        }

        private void ContextMenu_Popup(object sender, EventArgs e)
        {
            this.ContextMenu.MenuItems.Clear();

            MenuItem showPersonMenuItem = new MenuItem("Show data");
            this.ContextMenu.MenuItems.Add(showPersonMenuItem);
            showPersonMenuItem.Click += ShowPersonMenuItem_Click;
        }

        private void ShowPersonMenuItem_Click(object sender, EventArgs e)
        {
            ListViewItem lvi = (ListViewItem)this.Tag;
            Person person = (Person)lvi.Tag;

            PersonPropertiesForm personPropertiesForm = new PersonPropertiesForm(person);
            personPropertiesForm.ShowDialog(this);
        }

        private void MyLabel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && this.Tag != null)
            {
                ListViewItem lvi = (ListViewItem)this.Tag;

                if (DragDropEffects.Move == this.DoDragDrop(lvi, DragDropEffects.Move)) {
                    this.Tag = null;
                    this.Text = Convert.ToString(_index);
                }
            }
        }

    }
}
