namespace CircuitCrawlerEditor
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
			this.components = new System.ComponentModel.Container();
			System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Entities", System.Windows.Forms.HorizontalAlignment.Left);
			System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("Causes", System.Windows.Forms.HorizontalAlignment.Left);
			System.Windows.Forms.ListViewGroup listViewGroup3 = new System.Windows.Forms.ListViewGroup("Effects", System.Windows.Forms.HorizontalAlignment.Left);
			System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("Light", 9);
			System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("Ball", 0);
			System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem("Block", 1);
			System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem("BreakableDoor", 4);
			System.Windows.Forms.ListViewItem listViewItem5 = new System.Windows.Forms.ListViewItem("Button", 2);
			System.Windows.Forms.ListViewItem listViewItem6 = new System.Windows.Forms.ListViewItem("Cannon", 3);
			System.Windows.Forms.ListViewItem listViewItem7 = new System.Windows.Forms.ListViewItem("Door", 4);
			System.Windows.Forms.ListViewItem listViewItem8 = new System.Windows.Forms.ListViewItem("LaserShooter", 5);
			System.Windows.Forms.ListViewItem listViewItem9 = new System.Windows.Forms.ListViewItem("Player", 6);
			System.Windows.Forms.ListViewItem listViewItem10 = new System.Windows.Forms.ListViewItem("PuzzleBox", 7);
			System.Windows.Forms.ListViewItem listViewItem11 = new System.Windows.Forms.ListViewItem("SpikeWall", 8);
			System.Windows.Forms.ListViewItem listViewItem12 = new System.Windows.Forms.ListViewItem("Teleporter", 7);
			System.Windows.Forms.ListViewItem listViewItem13 = new System.Windows.Forms.ListViewItem("AND", 10);
			System.Windows.Forms.ListViewItem listViewItem14 = new System.Windows.Forms.ListViewItem("NOT", 10);
			System.Windows.Forms.ListViewItem listViewItem15 = new System.Windows.Forms.ListViewItem("OR", 10);
			System.Windows.Forms.ListViewItem listViewItem16 = new System.Windows.Forms.ListViewItem("XOR", 10);
			System.Windows.Forms.ListViewItem listViewItem17 = new System.Windows.Forms.ListViewItem("Button", 10);
			System.Windows.Forms.ListViewItem listViewItem18 = new System.Windows.Forms.ListViewItem("EntityDestruction", 10);
			System.Windows.Forms.ListViewItem listViewItem19 = new System.Windows.Forms.ListViewItem("Location", 10);
			System.Windows.Forms.ListViewItem listViewItem20 = new System.Windows.Forms.ListViewItem("TimePassed", 10);
			System.Windows.Forms.ListViewItem listViewItem21 = new System.Windows.Forms.ListViewItem("AND", 11);
			System.Windows.Forms.ListViewItem listViewItem22 = new System.Windows.Forms.ListViewItem("List", 11);
			System.Windows.Forms.ListViewItem listViewItem23 = new System.Windows.Forms.ListViewItem("Door", 11);
			System.Windows.Forms.ListViewItem listViewItem24 = new System.Windows.Forms.ListViewItem("EndGame", 11);
			System.Windows.Forms.ListViewItem listViewItem25 = new System.Windows.Forms.ListViewItem("RaiseBridge", 11);
			System.Windows.Forms.ListViewItem listViewItem26 = new System.Windows.Forms.ListViewItem("RemoveEntity", 11);
			System.Windows.Forms.ListViewItem listViewItem27 = new System.Windows.Forms.ListViewItem("TriggerTimer", 11);
			System.Windows.Forms.ListViewItem listViewItem28 = new System.Windows.Forms.ListViewItem("Trigger", 12);
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEditor));
			System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Entities");
			System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Causes");
			System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Effects");
			System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Triggers");
			System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Lights");
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
			this.spawnList = new System.Windows.Forms.ListView();
			this.spawnIcons = new System.Windows.Forms.ImageList(this.components);
			this.splitContainer2 = new System.Windows.Forms.SplitContainer();
			this.worldView = new OpenTK.GLControl();
			this.splitContainer3 = new System.Windows.Forms.SplitContainer();
			this.levelItemsList = new System.Windows.Forms.TreeView();
			this.selectedItemProperties = new System.Windows.Forms.PropertyGrid();
			this.menuStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
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
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.spawnList);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
			this.splitContainer1.Size = new System.Drawing.Size(855, 501);
			this.splitContainer1.SplitterDistance = 217;
			this.splitContainer1.TabIndex = 2;
			// 
			// spawnList
			// 
			this.spawnList.AllowDrop = true;
			this.spawnList.Dock = System.Windows.Forms.DockStyle.Fill;
			listViewGroup1.Header = "Entities";
			listViewGroup1.Name = "EntitesGroup";
			listViewGroup2.Header = "Causes";
			listViewGroup2.Name = "CausesGroup";
			listViewGroup3.Header = "Effects";
			listViewGroup3.Name = "EffectsGroup";
			this.spawnList.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2,
            listViewGroup3});
			this.spawnList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			listViewItem1.Tag = "Light";
			listViewItem2.Group = listViewGroup1;
			listViewItem2.Tag = "Ball";
			listViewItem3.Group = listViewGroup1;
			listViewItem3.Tag = "Block";
			listViewItem4.Group = listViewGroup1;
			listViewItem4.Tag = "BreakableDoor";
			listViewItem5.Group = listViewGroup1;
			listViewItem5.Tag = "Button";
			listViewItem6.Group = listViewGroup1;
			listViewItem6.Tag = "Cannon";
			listViewItem7.Group = listViewGroup1;
			listViewItem7.Tag = "Door";
			listViewItem8.Group = listViewGroup1;
			listViewItem8.Tag = "LaserShooter";
			listViewItem9.Group = listViewGroup1;
			listViewItem9.Tag = "Player";
			listViewItem10.Group = listViewGroup1;
			listViewItem10.Tag = "PuzzleBox";
			listViewItem11.Group = listViewGroup1;
			listViewItem11.Tag = "SpikeWall";
			listViewItem12.Group = listViewGroup1;
			listViewItem12.Tag = "Teleporter";
			listViewItem13.Group = listViewGroup2;
			listViewItem13.Tag = "CauseAND";
			listViewItem14.Group = listViewGroup2;
			listViewItem14.Tag = "CauseNOT";
			listViewItem15.Group = listViewGroup2;
			listViewItem15.Tag = "CauseOR";
			listViewItem16.Group = listViewGroup2;
			listViewItem16.Tag = "CauseXOR";
			listViewItem17.Group = listViewGroup2;
			listViewItem17.Tag = "CauseButton";
			listViewItem18.Group = listViewGroup2;
			listViewItem18.Tag = "CauseEntityDestruction";
			listViewItem19.Group = listViewGroup2;
			listViewItem19.Tag = "CauseLocation";
			listViewItem20.Group = listViewGroup2;
			listViewItem20.Tag = "CauseTimePassed";
			listViewItem21.Group = listViewGroup3;
			listViewItem21.Tag = "EffectAND";
			listViewItem22.Group = listViewGroup3;
			listViewItem22.Tag = "EffectList";
			listViewItem23.Group = listViewGroup3;
			listViewItem23.Tag = "EffectDoor";
			listViewItem24.Group = listViewGroup3;
			listViewItem24.Tag = "EffectEndGame";
			listViewItem25.Group = listViewGroup3;
			listViewItem25.Tag = "EffectRaiseBridge";
			listViewItem26.Group = listViewGroup3;
			listViewItem26.Tag = "EffectRemoveEntity";
			listViewItem27.Group = listViewGroup3;
			listViewItem27.Tag = "EffectTriggerTimer";
			listViewItem28.Tag = "Trigger";
			this.spawnList.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3,
            listViewItem4,
            listViewItem5,
            listViewItem6,
            listViewItem7,
            listViewItem8,
            listViewItem9,
            listViewItem10,
            listViewItem11,
            listViewItem12,
            listViewItem13,
            listViewItem14,
            listViewItem15,
            listViewItem16,
            listViewItem17,
            listViewItem18,
            listViewItem19,
            listViewItem20,
            listViewItem21,
            listViewItem22,
            listViewItem23,
            listViewItem24,
            listViewItem25,
            listViewItem26,
            listViewItem27,
            listViewItem28});
			this.spawnList.LabelWrap = false;
			this.spawnList.LargeImageList = this.spawnIcons;
			this.spawnList.Location = new System.Drawing.Point(0, 0);
			this.spawnList.MultiSelect = false;
			this.spawnList.Name = "spawnList";
			this.spawnList.Size = new System.Drawing.Size(217, 501);
			this.spawnList.TabIndex = 0;
			this.spawnList.TileSize = new System.Drawing.Size(200, 5);
			this.spawnList.UseCompatibleStateImageBehavior = false;
			this.spawnList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.spawnList_MouseDown);
			// 
			// spawnIcons
			// 
			this.spawnIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("spawnIcons.ImageStream")));
			this.spawnIcons.TransparentColor = System.Drawing.Color.Transparent;
			this.spawnIcons.Images.SetKeyName(0, "BallIcon.png");
			this.spawnIcons.Images.SetKeyName(1, "BlockIcon.png");
			this.spawnIcons.Images.SetKeyName(2, "ButtonIcon.png");
			this.spawnIcons.Images.SetKeyName(3, "CannonIcon.png");
			this.spawnIcons.Images.SetKeyName(4, "DoorIcon.png");
			this.spawnIcons.Images.SetKeyName(5, "LaserShooterIcon.png");
			this.spawnIcons.Images.SetKeyName(6, "PlayerIcon.png");
			this.spawnIcons.Images.SetKeyName(7, "PuzzleBoxIcon.png");
			this.spawnIcons.Images.SetKeyName(8, "SpikeWallIcon.png");
			this.spawnIcons.Images.SetKeyName(9, "LightIcon.png");
			this.spawnIcons.Images.SetKeyName(10, "CauseIcon.png");
			this.spawnIcons.Images.SetKeyName(11, "EffectIcon.png");
			this.spawnIcons.Images.SetKeyName(12, "TriggerIcon.png");
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
			this.worldView.AllowDrop = true;
			this.worldView.BackColor = System.Drawing.Color.Black;
			this.worldView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.worldView.Location = new System.Drawing.Point(0, 0);
			this.worldView.Name = "worldView";
			this.worldView.Size = new System.Drawing.Size(365, 501);
			this.worldView.TabIndex = 0;
			this.worldView.VSync = true;
			this.worldView.Load += new System.EventHandler(this.worldView_Load);
			this.worldView.DragDrop += new System.Windows.Forms.DragEventHandler(this.worldView_DragDrop);
			this.worldView.DragOver += new System.Windows.Forms.DragEventHandler(this.worldView_DragOver);
			this.worldView.Paint += new System.Windows.Forms.PaintEventHandler(this.worldView_Paint);
			this.worldView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.worldView_MouseClick);
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
			this.splitContainer3.Panel1.Controls.Add(this.levelItemsList);
			// 
			// splitContainer3.Panel2
			// 
			this.splitContainer3.Panel2.Controls.Add(this.selectedItemProperties);
			this.splitContainer3.Size = new System.Drawing.Size(265, 501);
			this.splitContainer3.SplitterDistance = 220;
			this.splitContainer3.TabIndex = 0;
			// 
			// levelItemsList
			// 
			this.levelItemsList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.levelItemsList.Location = new System.Drawing.Point(0, 0);
			this.levelItemsList.Name = "levelItemsList";
			treeNode1.Name = "TreeViewEntities";
			treeNode1.Text = "Entities";
			treeNode2.Name = "TreeViewCauses";
			treeNode2.Text = "Causes";
			treeNode3.Name = "TreeViewEffects";
			treeNode3.Text = "Effects";
			treeNode4.Name = "TreeViewTriggers";
			treeNode4.Text = "Triggers";
			treeNode5.Name = "TreeViewLights";
			treeNode5.Text = "Lights";
			this.levelItemsList.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5});
			this.levelItemsList.Size = new System.Drawing.Size(265, 220);
			this.levelItemsList.TabIndex = 0;
			this.levelItemsList.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.levelItems_NodeMouseClick);
			// 
			// selectedItemProperties
			// 
			this.selectedItemProperties.Dock = System.Windows.Forms.DockStyle.Fill;
			this.selectedItemProperties.Location = new System.Drawing.Point(0, 0);
			this.selectedItemProperties.Name = "selectedItemProperties";
			this.selectedItemProperties.Size = new System.Drawing.Size(265, 277);
			this.selectedItemProperties.TabIndex = 0;
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
			this.splitContainer1.Panel1.ResumeLayout(false);
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
		private System.Windows.Forms.TreeView levelItemsList;
		private System.Windows.Forms.PropertyGrid selectedItemProperties;
		private System.Windows.Forms.ListView spawnList;
		private System.Windows.Forms.ImageList spawnIcons;
	}
}