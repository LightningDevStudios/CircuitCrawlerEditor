﻿namespace CircuitCrawlerEditor
{
	partial class FormEditor
	{
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
			System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Tileset");
			System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Entities");
			System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Causes");
			System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Effects");
			System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Triggers");
			System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Lights");
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.selectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.deselectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.invertSelectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.tilesetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.borderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.squareToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.resizeTilesetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.lightsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.snapToGridToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.snapSizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.splitContainer2 = new System.Windows.Forms.SplitContainer();
			this.worldView = new OpenTK.GLControl();
			this.splitContainer3 = new System.Windows.Forms.SplitContainer();
			this.levelTreeView = new System.Windows.Forms.TreeView();
			this.propertyGridSelected = new System.Windows.Forms.PropertyGrid();
			this.menuStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
			this.splitContainer2.Panel1.SuspendLayout();
			this.splitContainer2.Panel2.SuspendLayout();
			this.splitContainer2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
			this.splitContainer3.Panel1.SuspendLayout();
			this.splitContainer3.Panel2.SuspendLayout();
			this.splitContainer3.SuspendLayout();
			this.SuspendLayout();
			// 
			// statusStrip1
			// 
			this.statusStrip1.Location = new System.Drawing.Point(0, 525);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(855, 22);
			this.statusStrip1.TabIndex = 0;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.helpToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(855, 24);
			this.menuStrip1.TabIndex = 1;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "File";
			// 
			// newToolStripMenuItem
			// 
			this.newToolStripMenuItem.Name = "newToolStripMenuItem";
			this.newToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
			this.newToolStripMenuItem.Text = "New...";
			// 
			// openToolStripMenuItem
			// 
			this.openToolStripMenuItem.Name = "openToolStripMenuItem";
			this.openToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
			this.openToolStripMenuItem.Text = "Open...";
			// 
			// saveToolStripMenuItem
			// 
			this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
			this.saveToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
			this.saveToolStripMenuItem.Text = "Save...";
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(109, 6);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
			this.exitToolStripMenuItem.Text = "Exit";
			// 
			// editToolStripMenuItem
			// 
			this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectionToolStripMenuItem,
            this.toolStripSeparator4,
            this.resizeTilesetToolStripMenuItem});
			this.editToolStripMenuItem.Name = "editToolStripMenuItem";
			this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
			this.editToolStripMenuItem.Text = "Edit";
			// 
			// selectionToolStripMenuItem
			// 
			this.selectionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectAllToolStripMenuItem,
            this.deselectAllToolStripMenuItem,
            this.invertSelectionToolStripMenuItem,
            this.toolStripSeparator3,
            this.tilesetToolStripMenuItem});
			this.selectionToolStripMenuItem.Name = "selectionToolStripMenuItem";
			this.selectionToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.selectionToolStripMenuItem.Text = "Selection";
			// 
			// selectAllToolStripMenuItem
			// 
			this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
			this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
			this.selectAllToolStripMenuItem.Text = "Select All";
			// 
			// deselectAllToolStripMenuItem
			// 
			this.deselectAllToolStripMenuItem.Name = "deselectAllToolStripMenuItem";
			this.deselectAllToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
			this.deselectAllToolStripMenuItem.Text = "Deselect All";
			// 
			// invertSelectionToolStripMenuItem
			// 
			this.invertSelectionToolStripMenuItem.Name = "invertSelectionToolStripMenuItem";
			this.invertSelectionToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
			this.invertSelectionToolStripMenuItem.Text = "Invert Selection";
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(152, 6);
			// 
			// tilesetToolStripMenuItem
			// 
			this.tilesetToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.borderToolStripMenuItem,
            this.squareToolStripMenuItem});
			this.tilesetToolStripMenuItem.Name = "tilesetToolStripMenuItem";
			this.tilesetToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
			this.tilesetToolStripMenuItem.Text = "Tileset";
			// 
			// borderToolStripMenuItem
			// 
			this.borderToolStripMenuItem.Name = "borderToolStripMenuItem";
			this.borderToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
			this.borderToolStripMenuItem.Text = "Border";
			// 
			// squareToolStripMenuItem
			// 
			this.squareToolStripMenuItem.Name = "squareToolStripMenuItem";
			this.squareToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
			this.squareToolStripMenuItem.Text = "Square";
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(149, 6);
			// 
			// resizeTilesetToolStripMenuItem
			// 
			this.resizeTilesetToolStripMenuItem.Name = "resizeTilesetToolStripMenuItem";
			this.resizeTilesetToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.resizeTilesetToolStripMenuItem.Text = "Resize Tileset...";
			// 
			// viewToolStripMenuItem
			// 
			this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lightsToolStripMenuItem,
            this.toolStripSeparator2,
            this.snapToGridToolStripMenuItem,
            this.snapSizeToolStripMenuItem});
			this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
			this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
			this.viewToolStripMenuItem.Text = "View";
			// 
			// lightsToolStripMenuItem
			// 
			this.lightsToolStripMenuItem.Name = "lightsToolStripMenuItem";
			this.lightsToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
			this.lightsToolStripMenuItem.Text = "Lights";
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(139, 6);
			// 
			// snapToGridToolStripMenuItem
			// 
			this.snapToGridToolStripMenuItem.Name = "snapToGridToolStripMenuItem";
			this.snapToGridToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
			this.snapToGridToolStripMenuItem.Text = "Snap To Grid";
			// 
			// snapSizeToolStripMenuItem
			// 
			this.snapSizeToolStripMenuItem.Name = "snapSizeToolStripMenuItem";
			this.snapSizeToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
			this.snapSizeToolStripMenuItem.Text = "Snap Size...";
			// 
			// helpToolStripMenuItem
			// 
			this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
			this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
			this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
			this.helpToolStripMenuItem.Text = "Help";
			// 
			// aboutToolStripMenuItem
			// 
			this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
			this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
			this.aboutToolStripMenuItem.Text = "About";
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
			this.splitContainer1.Location = new System.Drawing.Point(0, 24);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
			this.splitContainer1.Size = new System.Drawing.Size(855, 501);
			this.splitContainer1.SplitterDistance = 217;
			this.splitContainer1.TabIndex = 2;
			// 
			// splitContainer2
			// 
			this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
			this.splitContainer2.Location = new System.Drawing.Point(0, 0);
			this.splitContainer2.Name = "splitContainer2";
			// 
			// splitContainer2.Panel1
			// 
			this.splitContainer2.Panel1.Controls.Add(this.worldView);
			// 
			// splitContainer2.Panel2
			// 
			this.splitContainer2.Panel2.Controls.Add(this.splitContainer3);
			this.splitContainer2.Size = new System.Drawing.Size(634, 501);
			this.splitContainer2.SplitterDistance = 365;
			this.splitContainer2.TabIndex = 0;
			// 
			// worldView
			// 
			this.worldView.BackColor = System.Drawing.Color.Black;
			this.worldView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.worldView.Location = new System.Drawing.Point(0, 0);
			this.worldView.Name = "worldView";
			this.worldView.Size = new System.Drawing.Size(365, 501);
			this.worldView.TabIndex = 0;
			this.worldView.VSync = true;
			this.worldView.Load += new System.EventHandler(this.worldView_Load);
			this.worldView.Paint += new System.Windows.Forms.PaintEventHandler(this.worldView_Paint);
			this.worldView.Resize += new System.EventHandler(this.worldView_Resize);
			// 
			// splitContainer3
			// 
			this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer3.Location = new System.Drawing.Point(0, 0);
			this.splitContainer3.Name = "splitContainer3";
			this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer3.Panel1
			// 
			this.splitContainer3.Panel1.Controls.Add(this.levelTreeView);
			// 
			// splitContainer3.Panel2
			// 
			this.splitContainer3.Panel2.Controls.Add(this.propertyGridSelected);
			this.splitContainer3.Size = new System.Drawing.Size(265, 501);
			this.splitContainer3.SplitterDistance = 220;
			this.splitContainer3.TabIndex = 0;
			// 
			// levelTreeView
			// 
			this.levelTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.levelTreeView.Location = new System.Drawing.Point(0, 0);
			this.levelTreeView.Name = "levelTreeView";
			treeNode7.Name = "TreeViewTileset";
			treeNode7.Text = "Tileset";
			treeNode8.Name = "TreeViewEntities";
			treeNode8.Text = "Entities";
			treeNode9.Name = "TreeViewCauses";
			treeNode9.Text = "Causes";
			treeNode10.Name = "TreeViewEffects";
			treeNode10.Text = "Effects";
			treeNode11.Name = "TreeViewTriggers";
			treeNode11.Text = "Triggers";
			treeNode12.Name = "TreeViewLights";
			treeNode12.Text = "Lights";
			this.levelTreeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode7,
            treeNode8,
            treeNode9,
            treeNode10,
            treeNode11,
            treeNode12});
			this.levelTreeView.Size = new System.Drawing.Size(265, 220);
			this.levelTreeView.TabIndex = 0;
			// 
			// propertyGridSelected
			// 
			this.propertyGridSelected.Dock = System.Windows.Forms.DockStyle.Fill;
			this.propertyGridSelected.Location = new System.Drawing.Point(0, 0);
			this.propertyGridSelected.Name = "propertyGridSelected";
			this.propertyGridSelected.Size = new System.Drawing.Size(265, 277);
			this.propertyGridSelected.TabIndex = 0;
			// 
			// FormEditor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(855, 547);
			this.Controls.Add(this.splitContainer1);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "FormEditor";
			this.Text = "FormEditor";
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.splitContainer2.Panel1.ResumeLayout(false);
			this.splitContainer2.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
			this.splitContainer2.ResumeLayout(false);
			this.splitContainer3.Panel1.ResumeLayout(false);
			this.splitContainer3.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
			this.splitContainer3.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem selectionToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem deselectAllToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem invertSelectionToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripMenuItem tilesetToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem borderToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem squareToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
		private System.Windows.Forms.ToolStripMenuItem resizeTilesetToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem lightsToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripMenuItem snapToGridToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem snapSizeToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.SplitContainer splitContainer2;
		private OpenTK.GLControl worldView;
		private System.Windows.Forms.SplitContainer splitContainer3;
		private System.Windows.Forms.TreeView levelTreeView;
		private System.Windows.Forms.PropertyGrid propertyGridSelected;
	}
}