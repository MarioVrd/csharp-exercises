using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace Labs
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class AppForm : System.Windows.Forms.Form
	{
		private static int VIEW_COUNTER=0;
		private static int NEW_VIEW_START_X_POS=0;
		private static int NEW_VIEW_START_Y_POS=0;

		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem _newPersonMenuItem;
		private System.Windows.Forms.MenuItem _newListViewMenuItem;
		private System.Windows.Forms.MenuItem _newTreeViewMenuItem;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public AppForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			PersonDataModel pdm=new PersonDataModel();

			
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
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
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this._newPersonMenuItem = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this._newListViewMenuItem = new System.Windows.Forms.MenuItem();
			this._newTreeViewMenuItem = new System.Windows.Forms.MenuItem();
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem1,
																					  this.menuItem3});
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 0;
			this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this._newPersonMenuItem});
			this.menuItem1.Text = "Insert";
			// 
			// _newPersonMenuItem
			// 
			this._newPersonMenuItem.Index = 0;
			this._newPersonMenuItem.Text = "New Person";
			this._newPersonMenuItem.Click += new System.EventHandler(this.newPersonMenuItem_Click);
			// 
			// menuItem3
			// 
			this.menuItem3.Index = 1;
			this.menuItem3.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this._newListViewMenuItem,
																					  this._newTreeViewMenuItem});
			this.menuItem3.Text = "View";
			// 
			// _newListViewMenuItem
			// 
			this._newListViewMenuItem.Index = 0;
			this._newListViewMenuItem.Shortcut = System.Windows.Forms.Shortcut.CtrlL;
			this._newListViewMenuItem.Text = "New List View";
			this._newListViewMenuItem.Click += new System.EventHandler(this._newListViewMenuItem_Click);
			// 
			// _newTreeViewMenuItem
			// 
			this._newTreeViewMenuItem.Index = 1;
			this._newTreeViewMenuItem.Shortcut = System.Windows.Forms.Shortcut.CtrlT;
			this._newTreeViewMenuItem.Text = "New Tree View";
			this._newTreeViewMenuItem.Click += new System.EventHandler(this._newTreeViewMenuItem_Click);
			// 
			// AppForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
			this.ClientSize = new System.Drawing.Size(528, 280);
			this.IsMdiContainer = true;
			this.Menu = this.mainMenu1;
			this.Name = "AppForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Custom Events Lab";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new AppForm());
		}

		private void newPersonMenuItem_Click(object sender, System.EventArgs e)
		{
			PersonPropertiesForm ppf=new PersonPropertiesForm();
			ppf.ShowDialog(this);
			if(ppf.DialogResult==DialogResult.OK)
			{
				try
				{
					string name=ppf.getNameTextBoxText();
					string lastName=ppf.getLastNameTextBoxText();
					int age=System.Convert.ToInt32(ppf.getAgeTextBoxText());
					string city=ppf.getCityComboBoxText();
					Person p=new Person(name,lastName,age,city);

					PersonDataModel.getDataModel().addNewPerson(p);

				}
				catch
				{
					
				}

			}

			ppf.Dispose();
		
		}

		private void _newListViewMenuItem_Click(object sender, System.EventArgs e)
		{
			VIEW_COUNTER++;
			ListViewForm lvf=new ListViewForm();
			lvf.MdiParent=this;
			lvf.Location = new Point(NEW_VIEW_START_X_POS,NEW_VIEW_START_Y_POS);
			lvf.Text="List View "+VIEW_COUNTER;

			NEW_VIEW_START_X_POS+=20;
			NEW_VIEW_START_Y_POS+=20;
			lvf.Show();		
		}

		private void _newTreeViewMenuItem_Click(object sender, System.EventArgs e)
		{
			VIEW_COUNTER++;
			TreeViewForm tvf=new TreeViewForm();
			tvf.MdiParent=this;
			tvf.Location = new Point(NEW_VIEW_START_X_POS,NEW_VIEW_START_Y_POS);
			tvf.Text="Tree View "+VIEW_COUNTER;

			NEW_VIEW_START_X_POS+=20;
			NEW_VIEW_START_Y_POS+=20;
			tvf.Show();

		
		}
		
	}
}
