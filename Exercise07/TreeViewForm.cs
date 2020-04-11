using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Labs
{
	/// <summary>
	/// Summary description for TreeViewForm.
	/// </summary>
	public class TreeViewForm : System.Windows.Forms.Form
	{
		private TreeNode _root;
		private System.Windows.Forms.TreeView _treeView1;
		private System.Windows.Forms.ImageList _imageList1;
		private System.ComponentModel.IContainer components;

		public TreeViewForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			_root = new TreeNode("Persons");
			_root.ImageIndex=1;
			_root.SelectedImageIndex=1;
			_treeView1.Nodes.Add(_root);
			PersonDataModel.getDataModel().PersonModelChanged+=new PersonModelChangedEventHandler(this.consumeChangeInPersonDataModel);

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
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(TreeViewForm));
			this._treeView1 = new System.Windows.Forms.TreeView();
			this._imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.SuspendLayout();
			// 
			// _treeView1
			// 
			this._treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this._treeView1.ImageList = this._imageList1;
			this._treeView1.Location = new System.Drawing.Point(0, 0);
			this._treeView1.Name = "_treeView1";
			this._treeView1.Size = new System.Drawing.Size(280, 268);
			this._treeView1.Sorted = true;
			this._treeView1.TabIndex = 0;
			// 
			// _imageList1
			// 
			this._imageList1.ImageSize = new System.Drawing.Size(16, 16);
			this._imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("_imageList1.ImageStream")));
			this._imageList1.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// TreeViewForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
			this.ClientSize = new System.Drawing.Size(280, 268);
			this.Controls.Add(this._treeView1);
			this.Name = "TreeViewForm";
			this.Text = "Tree View";
			this.Load += new System.EventHandler(this.TreeViewForm_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void consumeChangeInPersonDataModel(object sender, PersonDataModelChangedEventArgs e)
		{
			if(e.IsAdded)
			{
				Person p=e.PersonInChange;
				TreeNode tn = new TreeNode(p.Name+" "+p.LastName+", "+System.Convert.ToString(p.Age)+", "+p.City);
				tn.Tag=p;
				tn.ImageIndex=0;
				_root.Nodes.Add(tn);
				_root.Expand();
			}
			else if(e.IsRemoved)
			{
				foreach(TreeNode tn in _root.Nodes)
				{
					Person p = (Person)tn.Tag;
					if(p==e.PersonInChange)
					{
						tn.Remove();
						break;
					}
				}
			}

		}

		private void TreeViewForm_Load(object sender, System.EventArgs e)
		{
			foreach(Person p in PersonDataModel.getDataModel().getAllPersons())
			{				
				TreeNode tn = new TreeNode(p.Name+" "+p.LastName+", "+System.Convert.ToString(p.Age)+", "+p.City);
				tn.Tag=p;
				tn.ImageIndex=0;
				tn.SelectedImageIndex=0;
				_root.Nodes.Add(tn);				
			}
			_root.Expand();
		}
	}
}
