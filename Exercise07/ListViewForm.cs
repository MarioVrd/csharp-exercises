using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Labs
{
	/// <summary>
	/// Summary description for ListViewForm.
	/// </summary>
	public class ListViewForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ContextMenu _contextMenu1;
		private System.Windows.Forms.ListView _listView1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ListViewForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			PersonDataModel.getDataModel().PersonModelChanged += new PersonModelChangedEventHandler(this.consumeChangeInPersonDataModel);
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this._listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._contextMenu1 = new System.Windows.Forms.ContextMenu();
            this.SuspendLayout();
            // 
            // _listView1
            // 
            this._listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this._listView1.ContextMenu = this._contextMenu1;
            this._listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this._listView1.FullRowSelect = true;
            this._listView1.GridLines = true;
            this._listView1.HideSelection = false;
            this._listView1.Location = new System.Drawing.Point(0, 0);
            this._listView1.Name = "_listView1";
            this._listView1.Size = new System.Drawing.Size(280, 268);
            this._listView1.TabIndex = 0;
            this._listView1.UseCompatibleStateImageBehavior = false;
            this._listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 136;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Last Name";
            this.columnHeader2.Width = 140;
            // 
            // _contextMenu1
            // 
            this._contextMenu1.Popup += new System.EventHandler(this.contextMenu1_Popup);
            // 
            // ListViewForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(280, 268);
            this.Controls.Add(this._listView1);
            this.Name = "ListViewForm";
            this.Text = "List View";
            this.Load += new System.EventHandler(this.ListViewForm_Load);
            this.ResumeLayout(false);

		}
		#endregion
	
	
		private void consumeChangeInPersonDataModel(object sender, PersonDataModelChangedEventArgs e)
		{
			if(e.IsAdded)
			{
				Person p=e.PersonInChange;
				string[] str=new string[2]{p.Name,p.LastName};
				ListViewItem lvi=new ListViewItem(str);
				lvi.Tag=p;
				_listView1.Items.Add(lvi);

			}
			else if(e.IsRemoved)
			{
				foreach(ListViewItem lvi in _listView1.Items)
				{
					Person p = (Person)lvi.Tag;
					if(p==e.PersonInChange)
					{
						_listView1.Items.Remove(lvi);
						break;
					}
				}
			}

		}

		private void ListViewForm_Load(object sender, System.EventArgs e)
		{
			foreach(Person p in PersonDataModel.getDataModel().getAllPersons())
			{
				string[] str=new string[2]{p.Name,p.LastName};
				ListViewItem lvi=new ListViewItem(str);
				lvi.Tag=p;
				_listView1.Items.Add(lvi);
			}
		}

		private void contextMenu1_Popup(object sender, System.EventArgs e)
		{		

			if(_listView1.SelectedItems.Count>0)
			{
				_contextMenu1.MenuItems.Clear();

				ListViewItem lvi=_listView1.SelectedItems[0];
				if(lvi!=null)
				{
					Person p=(Person)lvi.Tag;
					MenuItem menuItem1 = new MenuItem("Delete person '"+p.Name+" "+p.LastName+"'");
					menuItem1.Click += new System.EventHandler(this.deletePerson_Click);
					_contextMenu1.MenuItems.Add(menuItem1);				
				}

			}

		}

		private void deletePerson_Click(object sender, System.EventArgs e)
		{
			ListViewItem lvi=_listView1.SelectedItems[0];
			Person p=(Person)lvi.Tag;
			PersonDataModel.getDataModel().removeFromModel(p);			

		}
	}
}
