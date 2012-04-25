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
		private Light selectedLight;

		private float gridSnap;
		private bool snapping;

		private SelectionCube selectionCube;

		public FormEditor()
		{
			InitializeComponent();

			camera = new Camera();
			level = new Level();
            gridSnap = 72;
			showLights = true;

			WindowState = FormWindowState.Maximized;
			Application.Idle += Application_Idle;
			label2.Text = "";
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

			Resources.LoadAll();

			GenerateTiles(16, 16);

			initialSize = worldView.Size;

			selectionCube = new SelectionCube(Vector2.Zero);

			Light l = new Light();
			l.Diffuse = Color4.White;
			l.Ambient = new Color4(0.1f, 0.1f, 0.1f, 1f);
			l.Position = new Vector4(-40, 0, 5, 1);
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

			GL.PushMatrix();

			if (showLights)
				GL.Disable(EnableCap.Lighting);

			selectionCube.Update();
			selectionCube.Draw();

			if (showLights)
				GL.Enable(EnableCap.Lighting);

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

			camera.AspectRatio = (float)worldView.Width / (float)worldView.Height;
			camera.LoadProjection();
			camera.LoadView();
		}

		#endregion

		#region Mouse Events

		private void worldView_MouseClick(object sender, MouseEventArgs e)
		{
			Vector2 pos = ScreenToWorld(new Vector2(e.Location.X, e.Location.Y), true);

			foreach (Tile[] t in level.Tileset.Tiles)
			{
				foreach (Tile tile in t)
				{
					if (PointInSquare(pos, tile.Position, Tile.SIZE))
					{
						if (selectedTile == tile)
						{
							selectedTile = null;
						}
						else
						{
							selectedTile = tile;
							TreeNodeCollection nodes = levelItemsList.Nodes;
							foreach (TreeNode node in nodes)
							{
								if (node.Tag == selectedTile)
								{
									levelItemsList.SelectedNode = node;
									break;
								}
							}
							selectedItemProperties.SelectedObject = selectedTile;
						}
					}
				}
			}

			if (selectedTile == null && selectedEntity == null && selectedLight == null)
			{
				selectedItemProperties.SelectedObject = null;
				selectionCube.Hidden = true;
			}
			else
			{
				selectionCube.Hidden = false;
				if (selectedTile != null)
				{
					selectionCube.Position = selectedTile.Position;
				}
				if (selectedEntity != null)
				{
					selectionCube.Position = new Vector2(selectedEntity.XPos, selectedEntity.YPos);
				}
				if (selectedLight != null)
				{
					selectionCube.Position = selectedLight.Position.Xy;
				}
			}
		}

		private void worldView_MouseMove(object sender, MouseEventArgs e)
		{
			Vector2 mousePos = ScreenToWorld(new Vector2(e.Location.X, e.Location.Y), true);
			label2.Text = "X: " + (int)mousePos.X + " Y: " + (int)mousePos.Y;
			if (e.Button == MouseButtons.Left)
			{
				if (panning)
				{
					camera.Position = initialCameraPos + new Vector2((e.X - initialMousePos.X) * initialSize.Width / worldView.Size.Width, (initialMousePos.Y - e.Y) * initialSize.Width / worldView.Size.Width);
					camera.LoadView();
				}
				else
				{
					if (selectedEntity != null)
					{
						Vector2 pos = ScreenToWorld(new Vector2(e.Location.X, e.Location.Y), true);

						if (snapping)
							pos = SnapToGrid(pos);

						selectedEntity.XPos = pos.X;
						selectedEntity.YPos = pos.Y;
					}

					if (selectedTile == null && selectedEntity == null && selectedLight == null)
					{
						selectedItemProperties.SelectedObject = null;
						selectionCube.Hidden = true;
					}
					else
					{
						selectionCube.Hidden = false;
						if (selectedTile != null)
						{
							selectionCube.Position = selectedTile.Position;
						}
						if (selectedEntity != null)
						{
							selectionCube.Position = new Vector2(selectedEntity.XPos, selectedEntity.YPos);
						}
						if (selectedLight != null)
						{
							selectionCube.Position = selectedLight.Position.Xy;
						}
					}
				}
			}
		}

		private void worldView_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				if (panning)
				{
					initialMousePos = new Point(e.X, e.Y);
					initialCameraPos = camera.Position;
				}
				else
				{
					foreach (Entity ent in level.Entities)
					{
						Vector2 pos = ScreenToWorld(new Vector2(e.Location.X, e.Location.Y), true);

						if (RadiusCheck(pos, new Vector2(ent.XPos, ent.YPos), 32))
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
						}
					}
				}
			}
		}

		private void worldView_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				if (!panning)
				{
					if (selectedEntity != null)
					{
						Vector2 pos = ScreenToWorld(new Vector2(e.Location.X, e.Location.Y), true);

						if (snapping)
							pos = SnapToGrid(pos);

						selectedEntity.XPos = pos.X;
						selectedEntity.YPos = pos.Y;
						selectedEntity = null;
					}
				}
			}
		}

		private void worldView_MouseWheel(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			float zoom = camera.Zoom;
			if (e.Delta > 0)
				zoom *= 2f * ((float)e.Delta / 120f);
			else
				zoom /= 2f * -((float)e.Delta / 120f);
			if (zoom < 0.015625f)
				zoom = 0.012625f;
			camera.Zoom = zoom;
			camera.LoadView();
		}

		#endregion

		#region Keyboard Events

		private void worldView_KeyUp(object sender, KeyEventArgs e)
		{
			switch (e.KeyData)
			{
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

			camera.LoadProjection();
			camera.LoadView();
		}

		#endregion

		#region Drag and Drop Events

		private void worldView_DragDrop(object sender, DragEventArgs e)
		{
			panning = false;

			Vector2 worldPos = ScreenToWorld(e.X, e.Y);

			if (snapping)
			{
				worldPos = SnapToGrid(worldPos);
			}

			//get item
			ListViewItem item = new ListViewItem();
			if (e.Data.GetData(typeof(ListViewItem)) != null)
				item = (ListViewItem)e.Data.GetData(typeof(ListViewItem));

			object selectedObject = null;

			switch ((string)item.Tag)
			{
				case "Light":
					if (level.Lights.Count < 8)
					{
						Light l = new Light();
						l.Diffuse = Color4.White;
						l.Ambient = new Color4(0.1f, 0.1f, 0.1f, 1f);
						l.Position = new Vector4(worldPos.X, worldPos.Y, 36, 1);
						l.ConstantAttenuation = 1f;
						l.LinearAttenuation = 1f / 3000f;
						l.QuadraticAttenuation = 1f / 40000f;
						level.Lights.Add(l);

						for (int i = 0; i < 8; i++)
						{
							bool inUse = false;
							for (int j = 0; j < level.Lights.Count; j++)
							{
								if (level.Lights[j].Index == i)
								{
									inUse = true;
								}
							}
							if (!inUse)
							{
								l.Index = i;
							}
						}
						selectedObject = l;
					}
					else
					{
						MessageBox.Show("To many lights. Max light count is 8.", "Light Count", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
					break;
				case "Ball":
					Ball ball = new Ball(worldPos.X, worldPos.Y);
					level.Entities.Add(ball);
					selectedObject = ball;
					break;
				case "Block":
					Block block = new Block(worldPos.X, worldPos.Y);
					level.Entities.Add(block);
					selectedObject = block;
					break;
				case "BreakableDoor":
					BreakableDoor bdoor = new BreakableDoor(worldPos.X, worldPos.Y);
					bdoor.MaxHits = 3;
					level.Entities.Add(bdoor);
					selectedObject = bdoor;
					break;
				case "Button":
					Entities.Button button = new Entities.Button(worldPos.X, worldPos.Y);
					level.Entities.Add(button);
					selectedObject = button;
					break;
				case "Cannon":
					Cannon cannon = new Cannon(worldPos.X, worldPos.Y);
					level.Entities.Add(cannon);
					selectedObject = cannon;
					break;
				case "Door":
					Door door = new Door(worldPos.X, worldPos.Y);
					level.Entities.Add(door);
					selectedObject = door;
					break;
				case "LaserShooter":
					LaserShooter ls = new LaserShooter(worldPos.X, worldPos.Y);
					level.Entities.Add(ls);
					selectedObject = ls;
					break;
				case "Player":
					Player p = new Player(worldPos.X, worldPos.Y);
					level.Entities.Add(p);
					selectedObject = p;
					break;
				case "PuzzleBox":
					PuzzleBox pb = new PuzzleBox(worldPos.X, worldPos.Y);
					level.Entities.Add(pb);
					selectedObject = pb;
					break;
				case "SpikeWall":
					SpikeWall sw = new SpikeWall(worldPos.X, worldPos.Y);
					level.Entities.Add(sw);
					selectedObject = sw;
					break;
				case "Teleporter":
					Teleporter tp = new Teleporter(worldPos.X, worldPos.Y);
					level.Entities.Add(tp);
					selectedObject = tp;
					break;
				case "CauseAND":
					CauseAND cAnd = new CauseAND();
					level.Causes.Add(cAnd);
					selectedObject = cAnd;
					break;
				case "CauseNOT":
					CauseNOT cNot = new CauseNOT();
					level.Causes.Add(cNot);
					selectedObject = cNot;
					break;
				case "CauseOR":
					CauseOR cOr = new CauseOR();
					level.Causes.Add(cOr);
					selectedObject = cOr;
					break;
				case "CauseXOR":
					CauseXOR cXor = new CauseXOR();
					level.Causes.Add(cXor);
					selectedObject = cXor;
					break;
				case "CauseButton":
					CauseButton cBtn = new CauseButton();
					level.Causes.Add(cBtn);
					selectedObject = cBtn;
					break;
				case "CauseEntityDestruction":
					CauseEntityDestruction cEntD = new CauseEntityDestruction();
					level.Causes.Add(cEntD);
					selectedObject = cEntD;
					break;
				case "CauseLocation":
					CauseLocation cLoc = new CauseLocation();
					level.Causes.Add(cLoc);
					selectedObject = cLoc;
					break;
				case "CauseTimePassed":
					CauseTimePassed cTime = new CauseTimePassed();
					level.Causes.Add(cTime);
					selectedObject = cTime;
					break;
				case "EffectAND":
					EffectAND eAnd = new EffectAND();
					level.Effects.Add(eAnd);
					selectedObject = eAnd;
					break;
				case "EffectList":
					EffectList eList = new EffectList();
					level.Effects.Add(eList);
					selectedObject = eList;
					break;
				case "EffectDoor":
					EffectDoor eDoor = new EffectDoor();
					level.Effects.Add(eDoor);
					selectedObject = eDoor;
					break;
				case "EffectEndGame":
					EffectEndGame eEnd = new EffectEndGame();
					level.Effects.Add(eEnd);
					selectedObject = eEnd;
					break;
				case "EffectRaiseBridge":
					EffectRaiseBridge eBridge = new EffectRaiseBridge();
					level.Effects.Add(eBridge);
					selectedObject = eBridge;
					break;
				case "EffectRemoveEntity":
					EffectRemoveEntity eRemove = new EffectRemoveEntity();
					level.Effects.Add(eRemove);
					selectedObject = eRemove;
					break;
				case "EffectTriggerTimer":
					EffectTriggerTimer eTimer = new EffectTriggerTimer();
					level.Effects.Add(eTimer);
					selectedObject = eTimer;
					break;
				case "Trigger":
					Trigger t = new Trigger();
					level.Triggers.Add(t);
					selectedObject = t;
					break;
			}

			selectedItemProperties.SelectedObject = selectedObject;

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

			if(selectedEntity != null)
				selectionCube.Position = new Vector2(selectedEntity.XPos, selectedEntity.YPos);
		}

		private void levelItemsList_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyData == Keys.Delete)
			{
                try
                {
                    if (levelItemsList.SelectedNode.Parent != null)
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
                    }
                }
                catch { }
				
				UpdateWorldTree();
			}
		}

		#endregion	

		#region ToolStrip Events

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MessageBox.Show("CC Level Editor: \r\n//TODO Put Stuff Here.", "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void saveToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ShowSaveDialog();
			UpdateWorldTree();
		}

		private void openToolStripMenuItem_Click(object sender, EventArgs e)
		{
			loadDialog.FileName = "";
			if (loadDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				if (MessageBox.Show("Opening this file will discard all current changes.\r\nAre you sure you want to continue?", "Open Level", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
				{
					Level newlevel = Parser.Parser.LoadLevel(loadDialog.FileName);
					if (newlevel != null)
						level = newlevel;
				}
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
			switch (PromptUserSave())
			{
				case DialogResult.Yes:
					if (!ShowSaveDialog())
						return;
					break;
				case DialogResult.Cancel:
					return;
			}
			level = new Level();
			worldView_Load(this, EventArgs.Empty);
		}

		private void resizeTilesetToolStripMenuItem_Click(object sender, EventArgs e)
		{
			using (TileSize form = new TileSize())
			{
				form.ShowDialog();

				if (level.Tileset.Tiles.Length == form.X && level.Tileset.Tiles[0].Length == form.Y)
					return;

				GenerateTiles(form.X, form.Y);
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
			//distance * distance is faster than two Math.Sqrts and float casts.
			return Vector2.Subtract(a, b).LengthSquared < distance * distance;
		}

		private Vector2 SnapToGrid(Vector2 v)
		{
			v.X = v.X - v.X % gridSnap;

			if (v.Y % gridSnap < gridSnap / 2)
				v.Y = v.Y - v.Y % gridSnap;
			else
				v.Y = v.Y + (gridSnap - v.Y % gridSnap);

            //if(v.X < gridSnap
			return new Vector2(v.X + Tile.SIZE_F / 2, v.Y - Tile.SIZE_F / 2);
		}

		private Vector2 ScreenToWorld(Vector2 v, bool hack = false)
		{
			Point formPosition = new Point((int)v.X, (int)v.Y);
			if (!hack)
			{
				formPosition = PointToClient(new Point((int)v.X, (int)v.Y));

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
			}
			//formPosition.X += worldView.Width / 2;
			//formPosition.Y += worldView.Height / 2;

			Matrix4 fakeProjection = Matrix4.CreateOrthographic(Tile.SIZE_F * 7, Tile.SIZE_F * 6 / camera.AspectRatio, 1f, Tile.SIZE_F * 4);

			return ExtraMath.Unproject(fakeProjection, camera.View, worldView.Size, formPosition).Xy;
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
			level.Tileset = new Tileset(tiles, Resources.Textures["tilesetworld.png"]);
		}

		#endregion

		private void selectedItemProperties_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
		{
			if (selectedTile != null)
			{
				selectionCube.Position = selectedTile.Position;
			}
			if (selectedEntity != null)
			{
				selectionCube.Position = new Vector2(selectedEntity.XPos, selectedEntity.YPos);
			}
			if (selectedLight != null)
			{
				selectionCube.Position = selectedLight.Position.Xy;
			}

			UpdateWorldTree();
		}

		private void FormEditor_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Alt)
			{
				panning = true;
				e.Handled = true;
				e.SuppressKeyPress = true;
			}
		}

		private void FormEditor_KeyUp(object sender, KeyEventArgs e)
		{
			if (!e.Alt)
			{
				panning = false;
				e.Handled = true;
				e.SuppressKeyPress = true;
			}
		}

		private void FormEditor_FormClosing(object sender, FormClosingEventArgs e)
		{
			switch (PromptUserSave())
			{
				case System.Windows.Forms.DialogResult.Yes:
					if (!ShowSaveDialog())
						e.Cancel = true;
					break;
				case DialogResult.No:
					break;
				case DialogResult.Cancel:
					e.Cancel = true;
					break;
			}
		}

		private bool ShowSaveDialog()
		{
			if (saveDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				Parser.Parser.SaveLevel(saveDialog.FileName, level);
				return true;
			}

			return false;
		}

		private DialogResult PromptUserSave()
		{
			return MessageBox.Show("Unsaved changes will be shot, surviving changes will be shot repeatedly until dead. Do you want to save your changes from this horrible fate before you go?", "Leaving, bro?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
		}
	}
}
