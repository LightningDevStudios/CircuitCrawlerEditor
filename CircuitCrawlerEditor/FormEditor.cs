using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using CircuitCrawlerEditor.Entities;
using CircuitCrawlerEditor.Triggers;

using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace CircuitCrawlerEditor
{
	public partial class FormEditor : Form
	{
		private bool loaded;
		private bool showLights;
		private bool panning;

		private Point initialMousePos;
		private Vector2 initialCameraPos;

		private Size initialSize;

		private Camera camera;
		private Level level;

		private Entity selectedEntity;
		private Tile selectedTile;

		private float gridSnap;
		private bool snapping;

		public FormEditor()
		{
			InitializeComponent();

			camera = new Camera();
			level = new Level();

			showLights = true;

			Application.Idle += Application_Idle;
		}

		void Application_Idle(object sender, EventArgs e)
		{
			if (!loaded)
				return;

			worldView.Invalidate();
		}

		#region WorldView Events

		#region Graphics Events

		private void worldView_Load(object sender, EventArgs e)
		{
			loaded = true;

			//Initialize all OpenGL stuff
			GL.ShadeModel(ShadingModel.Smooth);
			GL.Enable(EnableCap.DepthTest);
			GL.DepthFunc(DepthFunction.Lequal);
			GL.DepthMask(true);
			GL.Enable(EnableCap.Blend);
			GL.BlendFunc(BlendingFactorSrc.One, BlendingFactorDest.OneMinusSrcAlpha);

			GL.ClearColor(Color.CornflowerBlue);

			ResizeViewport();

			GenerateTiles(4, 4);

			initialSize = worldView.Size;

			Light l = new Light();
			l.Diffuse = Color4.White;
			l.Ambient = new Color4(0.1f, 0.1f, 0.1f, 1f);
			l.Position = new Vector4(-40, 0, 85, 1);
			l.ConstantAttenuation = 1f;
			l.LinearAttenuation = 1f / 3000f;
			l.QuadraticAttenuation = 1f / 40000f;
			level.Lights.Add(l);

			UpdateWorldTree();
		}

		private void worldView_Paint(object sender, PaintEventArgs e)
		{
			GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

			GL.Disable(EnableCap.CullFace);
			GL.FrontFace(FrontFaceDirection.Cw);

			if(showLights)
				GL.Enable(EnableCap.Lighting);

			GL.Enable(EnableCap.Texture2D);
			GL.EnableClientState(ArrayCap.VertexArray);
			GL.EnableClientState(ArrayCap.TextureCoordArray);
			GL.EnableClientState(ArrayCap.NormalArray);

			GL.PushMatrix();

			GL.Translate(new Vector3(0, 0, -1));

			level.Draw();

			GL.PopMatrix();

			if (showLights)
				GL.Disable(EnableCap.Lighting);

			GL.Disable(EnableCap.Texture2D);
			GL.DisableClientState(ArrayCap.NormalArray);
			GL.DisableClientState(ArrayCap.TextureCoordArray);
			GL.DisableClientState(ArrayCap.VertexArray);

			worldView.SwapBuffers();
		}

		private void worldView_Resize(object sender, EventArgs e)
		{
			if (!loaded)
				return;

			ResizeViewport();
		}

		private void ResizeViewport()
		{
			GL.Viewport(0, 0, worldView.Width, worldView.Height);

			camera.UpdateProjection(worldView.Size);
			camera.LoadProjection();
			GL.MatrixMode(MatrixMode.Modelview);
			GL.LoadIdentity();
		}

		#endregion

		#region Mouse Events

		private void worldView_MouseClick(object sender, MouseEventArgs e)
		{
			Vector2 pos = ScreenToWorld(e.Location);

			if (selectedEntity != null)
			{
				if(snapping)
				{
					pos = SnapToGrid(pos);
				}
				selectedEntity.XPos = pos.X;
				selectedEntity.YPos = pos.Y;
				selectedEntity = null;
			}
			else
			{
				bool selected = false;
				foreach (Entity ent in level.Entities)
				{
					if (RadiusCheck(pos, new Vector2(ent.XPos, ent.YPos), 32)) //TODO: make this better
					{
						selectedEntity = ent;
						TreeNodeCollection nodes = levelItemsList.Nodes;
						foreach (TreeNode node in nodes)
						{
							if (node.Tag == ent)
							{
								levelItemsList.SelectedNode = node;
								break;
							}
						}
						selectedItemProperties.SelectedObject = ent;
						selected = true;
					}
				}
				if (!selected)
				{
					selectedEntity = null;
					foreach (Tile[] t in level.Tileset.Tiles)
					{
						foreach (Tile tile in t)
						{
							if (PointInSquare(pos, tile.Position, Tile.TILE_SIZE))
							{
								selectedTile = tile;
								selectedItemProperties.SelectedObject = selectedTile;
							}
						}
					}
				}
			}
		}

		private void worldView_MouseMove(object sender, MouseEventArgs e)
		{
			Vector2 pos = ScreenToWorld(e.Location);
			label1.Text = "X: " + (int)pos.X + " Y: " + (int)pos.Y;

			if (panning && e.Button == MouseButtons.Left)
			{
				camera.Position = initialCameraPos + new Vector2((e.X - initialMousePos.X) * initialSize.Width / worldView.Size.Width, (initialMousePos.Y - e.Y) * initialSize.Width / worldView.Size.Width) * camera.Zoom / 100;
				camera.LoadView();
			}
		}

		private void worldView_MouseDown(object sender, MouseEventArgs e)
		{
			if (panning && e.Button == MouseButtons.Left)
			{
				initialMousePos = new Point(e.X, e.Y);
				initialCameraPos = camera.Position;
			}
		}

		private void worldView_MouseWheel(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			float zoom = camera.Zoom + -e.Delta / 20;
			if (zoom < 1)
				zoom = 1;
			camera.Zoom = zoom;
			camera.LoadProjection();
		}

		#endregion

		#region Keyboard Events

		private void worldView_KeyUp(object sender, KeyEventArgs e)
		{
			switch (e.KeyData)
			{
				case Keys.Q:
					panning = false;
					break;
				case Keys.Delete:
					level.Entities.Remove(selectedEntity);
					selectedEntity = null;
					UpdateWorldTree();
					break;
			}
		}

		private void worldView_KeyDown(object sender, KeyEventArgs e)
		{
			switch (e.KeyData)
			{
				case Keys.Q:
					panning = true;
					break;
				case Keys.W:
					camera.Position -= Vector2.UnitY * 10;
					break;
				case Keys.S:
					camera.Position += Vector2.UnitY * 10;
					break;
				case Keys.A:
					camera.Position += Vector2.UnitX * 10;
					break;
				case Keys.D:
					camera.Position -= Vector2.UnitX * 10;
					break;
				case Keys.PageUp:
					float zoom = camera.Zoom - 5;
					if (zoom <= 1)
						zoom = 1;
					camera.Zoom = zoom;
					break;
				case Keys.PageDown:
					camera.Zoom += 5;
					break;
			}

			camera.LoadView();
			camera.LoadProjection();
		}

		#endregion

		#region Drag and Drop Events

		private void worldView_DragDrop(object sender, DragEventArgs e)
		{
			Vector2 worldPos = ScreenToWorld(e.X, e.Y);

			if (snapping)
			{
				worldPos = SnapToGrid(worldPos);
			}

			//get item
			ListViewItem item = new ListViewItem();
			if (e.Data.GetData(typeof(ListViewItem)) != null)
				item = (ListViewItem)e.Data.GetData(typeof(ListViewItem));

			switch ((string)item.Tag)
			{
				case "Light":
					Light l = new Light();
					l.Diffuse = Color4.White;
					l.Ambient = new Color4(0.1f, 0.1f, 0.1f, 1f);
					l.Position = new Vector4(worldPos.X, worldPos.Y, 85, 1);
					l.ConstantAttenuation = 1f;
					l.LinearAttenuation = 1f / 3000f;
					l.QuadraticAttenuation = 1f / 40000f;
					level.Lights.Add(l);
					break;
				case "Ball":
					Ball ball = new Ball(worldPos.X, worldPos.Y);
					level.Entities.Add(ball);
					break;
				case "Block":
					Block block = new Block(worldPos.X, worldPos.Y);
					level.Entities.Add(block);
					break;
				case "BreakableDoor":
					BreakableDoor bdoor = new BreakableDoor(worldPos.X, worldPos.Y);
					bdoor.MaxHits = 3;
					level.Entities.Add(bdoor);
					break;
				case "Button":
					Entities.Button button = new Entities.Button(worldPos.X, worldPos.Y);
					level.Entities.Add(button);
					break;
				case "Cannon":
					Cannon cannon = new Cannon(worldPos.X, worldPos.Y);
					level.Entities.Add(cannon);
					break;
				case "Door":
					Door door = new Door(worldPos.X, worldPos.Y);
					level.Entities.Add(door);
					break;
				case "LaserShooter":
					LaserShooter ls = new LaserShooter(worldPos.X, worldPos.Y);
					level.Entities.Add(ls);
					break;
				case "Player":
					Player p = new Player(worldPos.X, worldPos.Y);
					level.Entities.Add(p);
					break;
				case "PuzzleBox":
					PuzzleBox pb = new PuzzleBox(worldPos.X, worldPos.Y);
					level.Entities.Add(pb);
					break;
				case "SpikeWall":
					SpikeWall sw = new SpikeWall(worldPos.X, worldPos.Y);
					break;
				case "Teleporter":
					Teleporter tp = new Teleporter(worldPos.X, worldPos.Y);
					level.Entities.Add(tp);
					break;
				case "CauseAND":
					level.Causes.Add(new CauseAND());
					break;
				case "CauseNOT":
					level.Causes.Add(new CauseNOT());
					break;
				case "CauseOR":
					level.Causes.Add(new CauseOR());
					break;
				case "CauseXOR":
					level.Causes.Add(new CauseXOR());
					break;
				case "CauseButton":
					level.Causes.Add(new CauseButton());
					break;
				case "CauseEntityDestruction":
					level.Causes.Add(new CauseEntityDestruction());
					break;
				case "CauseLocation":
					level.Causes.Add(new CauseButton());
					break;
				case "CauseTimePast":
					level.Causes.Add(new CauseButton());
					break;
				case "EffectAND":
					level.Effects.Add(new EffectAND());
					break;
				case "EffectList":
					level.Effects.Add(new EffectList());
					break;
				case "EffectDoor":
					level.Effects.Add(new EffectDoor());
					break;
				case "EffectEndGame":
					level.Effects.Add(new EffectEndGame());
					break;
				case "EffectRaiseBridge":
					level.Effects.Add(new EffectRaiseBridge());
					break;
				case "EffectRemoveEntity":
					level.Effects.Add(new EffectRemoveEntity());
					break;
				case "EffectTriggerTimer":
					level.Effects.Add(new EffectTriggerTimer());
					break;
				case "Trigger":
					level.Triggers.Add(new Trigger());
					break;
			}

			UpdateWorldTree();
		}

		private void worldView_DragOver(object sender, DragEventArgs e)
		{
			e.Effect = DragDropEffects.Copy;
		}

		#endregion

		#endregion

		#region SpawnList Events

		private void spawnList_MouseDown(object sender, MouseEventArgs e)
		{
			ListViewItem item = spawnList.GetItemAt(e.X, e.Y);

			if (item != null)
				spawnList.DoDragDrop(item.Clone(), DragDropEffects.Copy);
		}

		#endregion

		#region LevelItemsList Events

		private void levelItems_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
		{
			selectedItemProperties.SelectedObject = e.Node.Tag;
			selectedEntity = e.Node.Tag as Entity;
		}

		private void levelItemsList_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyData == Keys.Delete)
			{
				switch (levelItemsList.SelectedNode.Parent.Text)
				{
					case "Entities":
						level.Entities.Remove((Entity)levelItemsList.SelectedNode.Tag);
						break;
					case "Causes":
						level.Causes.Remove((Cause)levelItemsList.SelectedNode.Tag);
						break;
					case "Effects":
						level.Effects.Remove((Effect)levelItemsList.SelectedNode.Tag);
						break;
					case "Triggers":
						level.Triggers.Remove((Trigger)levelItemsList.SelectedNode.Tag);
						break;
					case "Lights":
						level.Lights.Remove((Light)levelItemsList.SelectedNode.Tag);
						break;
				}
				
				UpdateWorldTree();
			}
		}

		#endregion	

		#region ToolStrip Events

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Are you sure you want to exit?.\r\nAll unsaved changes will be discarded.", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
				Application.Exit();
		}

		private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MessageBox.Show("CC Level Editor: \r\n//TODO Put Stuff Here.", "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void saveToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (saveDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				if (MessageBox.Show("Opening this file will discard all current changes.\r\nAre you sure you want to continue?", "Open Level", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
				{
					Parser.Parser.SaveLevel(saveDialog.FileName, level);
				}
			}

			UpdateWorldTree();
		}

		private void openToolStripMenuItem_Click(object sender, EventArgs e)
		{
			loadDialog.FileName = "";
			if (loadDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				Level newlevel = Parser.Parser.LoadLevel(loadDialog.FileName);
				if (newlevel != null)
					level = newlevel;
			}

			UpdateWorldTree();
		}

		private void snapSizeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			using (SnapSize form = new SnapSize())
			{
				form.ShowDialog();
				gridSnap = form.snapSize;
			}
		}

		private void snapToGridToolStripMenuItem_Click(object sender, EventArgs e)
		{
			snapping = !snapping;
		}

		private void lightsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			showLights = !showLights;
		}

		private void newToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Are you sure you want to create a new level?", "New Level", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
			{
				level = new Level();
				worldView_Load(this, EventArgs.Empty);
			}
		}

		private void resizeTilesetToolStripMenuItem_Click(object sender, EventArgs e)
		{
			using (TileSize form = new TileSize())
			{
				form.ShowDialog();

				if (level.Tileset.Tiles.Length == form.X && level.Tileset.Tiles[0].Length == form.Y)
					return;

				if (MessageBox.Show("Are you sure you want to resize the tiles?\r\nThis will erase all current tiles.", "Resize Tiles", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
				{
					GenerateTiles(form.X, form.Y);
				}
			}
		}

		#endregion

		#region Helper Methods

		private bool PointInSquare(Vector2 point, Vector2 boxPosition, int boxSize)
		{
			return point.X > boxPosition.X - boxSize / 2 && point.X < boxPosition.X + boxSize / 2 && point.Y > boxPosition.Y - boxSize / 2 && point.Y < boxPosition.Y + boxSize / 2;
		}

		private void UpdateWorldTree()
		{
			foreach (TreeNode node in levelItemsList.Nodes)
				node.Nodes.Clear();

			foreach (Entity ent in level.Entities)
			{
				TreeNode node = new TreeNode(ent.ToString());
				node.Tag = ent;
				levelItemsList.Nodes[0].Nodes.Add(node);
			}

			foreach (Cause cause in level.Causes)
			{
				TreeNode node = new TreeNode(cause.ToString());
				node.Tag = cause;
				levelItemsList.Nodes[1].Nodes.Add(node);
			}

			foreach (Effect effect in level.Effects)
			{
				TreeNode node = new TreeNode(effect.ToString());
				node.Tag = effect;
				levelItemsList.Nodes[2].Nodes.Add(node);
			}

			foreach (Trigger trigger in level.Triggers)
			{
				TreeNode node = new TreeNode(trigger.ToString());
				node.Tag = trigger;
				levelItemsList.Nodes[3].Nodes.Add(node);
			}

			foreach (Light light in level.Lights)
			{
				TreeNode node = new TreeNode(light.ToString());
				node.Tag = light;
				levelItemsList.Nodes[4].Nodes.Add(node);
			}

			UIEntListEditor.entList = level.Entities;
			UICauseListEditor.causeList = level.Causes;
			UIEffectListEditor.effectList = level.Effects;
			UIFormEffectListEditor.effectList = level.Effects;
		}

		private bool RadiusCheck(Vector2 a, Vector2 b, float distance)
		{
			float diag1 = (float)Math.Pow((a.X - b.X), 2);
			float diag2 = (float)Math.Pow((a.Y - b.Y), 2);
			return (float)Math.Sqrt(diag1 + diag2) < distance;
		}

		private Vector2 SnapToGrid(Vector2 v)
		{
			if (v.X % gridSnap < gridSnap / 2)
				v.X = v.X - v.X % gridSnap;
			else
				v.X = v.X + (gridSnap - v.X % gridSnap);

			if (v.Y % gridSnap < gridSnap / 2)
				v.Y = v.Y - v.Y % gridSnap;
			else
				v.Y = v.Y + (gridSnap - v.Y % gridSnap);

			return new Vector2(v.X + Tile.TILE_SIZE_F / 2, v.Y + Tile.TILE_SIZE_F / 2);
		}

		private Vector2 ScreenToWorld(Vector2 v)
		{
			Point formPosition = PointToClient(new Point((int)v.X, (int)v.Y));

			Point controlPosition = new Point();
			Control ctrl = worldView;

			while (ctrl != this)
			{
				controlPosition.X += ctrl.Location.X;
				controlPosition.Y += ctrl.Location.Y;
				ctrl = ctrl.Parent;
			}

			formPosition.X -= controlPosition.X;
			formPosition.Y -= controlPosition.Y;

			return ExtraMath.UnProject(camera.Projection, camera.View, worldView.Size, formPosition).Xy;
		}

		private Vector2 ScreenToWorld(Point p)
		{
			return ScreenToWorld(new Vector2(p.X, p.Y));
		}

		private Vector2 ScreenToWorld(float x, float y)
		{
			return ScreenToWorld(new Vector2(x, y));
		}

		private void GenerateTiles(int x, int y)
		{
			Tile[][] tiles = new Tile[x][];
			for (int i = 0; i < tiles.Length; i++)
				tiles[i] = new Tile[y];

			for (int i = 0; i < x; i++)
			{
				for (int j = 0; j < y; j++)
				{
					if (j == 0 || j == y - 1 || i == 0 || i == x - 1)
					{
						tiles[i][j] = new Tile(new Point(i, j), 4, 4, TileType.Wall); 
					}
					else
						tiles[i][j] = new Tile(new Point(i, j), 4, 4, TileType.Floor); 
				}
			}
			level.Tileset = new Tileset(tiles, new Texture(new Bitmap("Resources/Textures/tilesetworld.png"), 16, 8, TextureMinFilter.Linear, TextureMagFilter.Linear, TextureWrapMode.Clamp, TextureWrapMode.Clamp));
		}

		#endregion

		private void controlsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MessageBox.Show("Controls:\r\n    Q: Press and hold for mouse pan.\r\n    Arrow Keys: Pan screen.\r\n    PageUp/Down: Change zoom level.\r\n    //TODO more of the controls.", "Control Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}
	}
}
