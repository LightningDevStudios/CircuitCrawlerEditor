using System;
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

		private Camera camera;
		private Level level;

		public FormEditor()
		{
			InitializeComponent();

			camera = new Camera();
			level = new Level();

			Application.Idle += Application_Idle;
		}

		void Application_Idle(object sender, EventArgs e)
		{
			if (!loaded)
				return;

			worldView.Invalidate();
		}

		#region WorldView Events

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

			level.Tileset = new Tileset(new Tile[][]
			{
				new Tile[] { new Tile(new Point(0, 0), 4, 4, TileType.Wall), new Tile(new Point(1, 0), 4, 4, TileType.Wall), new Tile(new Point(2, 0), 4, 4, TileType.Pit), new Tile(new Point(3, 0), 4, 4, TileType.Wall) },
				new Tile[] { new Tile(new Point(0, 1), 4, 4, TileType.Wall), new Tile(new Point(1, 1), 4, 4, TileType.Floor), new Tile(new Point(2, 1), 4, 4, TileType.Wall), new Tile(new Point(3, 1), 4, 4, TileType.Wall) },
				new Tile[] { new Tile(new Point(0, 2), 4, 4, TileType.Wall), new Tile(new Point(1, 2), 4, 4, TileType.Floor), new Tile(new Point(2, 2), 4, 4, TileType.Wall), new Tile(new Point(3, 2), 4, 4, TileType.Wall) },
				new Tile[] { new Tile(new Point(0, 3), 4, 4, TileType.Wall), new Tile(new Point(1, 3), 4, 4, TileType.Wall), new Tile(new Point(2, 3), 4, 4, TileType.Wall), new Tile(new Point(3, 3), 4, 4, TileType.Wall) }
			}, new Texture(new Bitmap("Resources/Textures/tilesetworld.png"), 16, 8, TextureMinFilter.Linear, TextureMagFilter.Linear, TextureWrapMode.Clamp, TextureWrapMode.Clamp));

			Light l = new Light();
			l.Diffuse = Color4.White;
			l.Ambient = new Color4(0.1f, 0.1f, 0.1f, 1f);
			l.Position = new Vector4(-40, 0, 1, 1);
			l.ConstantAttenuation = 1f;
			l.LinearAttenuation = 1f / 100f;
			l.QuadraticAttenuation = 1f / 20000f;
			level.Lights.Add(l);
		}

		private void worldView_Paint(object sender, PaintEventArgs e)
		{
			GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

			GL.Disable(EnableCap.CullFace);
			GL.FrontFace(FrontFaceDirection.Cw);

			GL.Enable(EnableCap.Lighting);
			GL.Enable(EnableCap.Texture2D);
			GL.EnableClientState(ArrayCap.VertexArray);
			GL.EnableClientState(ArrayCap.TextureCoordArray);
			GL.EnableClientState(ArrayCap.NormalArray);

			GL.PushMatrix();

			GL.Translate(new Vector3(0, 0, -1));

			level.Draw();

			GL.PopMatrix();

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

		private void worldView_DragDrop(object sender, DragEventArgs e)
		{
			//Convert to world position
			Point formPosition = PointToClient(new Point(e.X, e.Y));

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

			Vector2 worldPos = ExtraMath.UnProject(camera.Projection, camera.View, worldView.Size, formPosition).Xy;

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
					l.Position = new Vector4(worldPos.X, worldPos.Y, 1, 1);
					l.ConstantAttenuation = 1f;
					l.LinearAttenuation = 1f / 100f;
					l.QuadraticAttenuation = 1f / 20000f;
					level.Lights.Add(l);
					break;
				case "Ball":
					Ball ball = new Ball(32, worldPos.X, worldPos.Y);
					level.Entities.Add(ball);
					break;
				case "Block":
					Block block = new Block(50, worldPos.X, worldPos.Y);
					level.Entities.Add(block);
					break;
				case "BreakableDoor":
					BreakableDoor bdoor = new BreakableDoor(worldPos.X, worldPos.Y, 5);
					level.Entities.Add(bdoor);
					break;
				case "Button":
					Entities.Button button = new Entities.Button(worldPos.X, worldPos.Y);
					level.Entities.Add(button);
					break;
				case "Cannon":
					Cannon cannon = new Cannon(50, worldPos.X, worldPos.Y);
					level.Entities.Add(cannon);
					break;
				case "Door":
					Door door = new Door(worldPos.X, worldPos.Y);
					level.Entities.Add(door);
					break;
				case "LaserShooter":
					LaserShooter ls = new LaserShooter(50, worldPos.X, worldPos.Y);
					level.Entities.Add(ls);
					break;
				case "Player":
					Player p = new Player(32, worldPos.X, worldPos.Y);
					level.Entities.Add(p);
					break;
				case "PuzzleBox":
					PuzzleBox pb = new PuzzleBox(32, worldPos.X, worldPos.Y);
					level.Entities.Add(pb);
					break;
				case "SpikeWall":
					SpikeWall sw = new SpikeWall(worldPos.X, worldPos.Y);
					break;
				case "Teleporter":
					Teleporter tp = new Teleporter(64, worldPos.X, worldPos.Y);
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
		}

		private void worldView_DragOver(object sender, DragEventArgs e)
		{
			e.Effect = DragDropEffects.Copy;
		}

		#endregion

		#region SpawnList Events

		private void spawnList_MouseDown(object sender, MouseEventArgs e)
		{
			ListViewItem item = spawnList.GetItemAt(e.X, e.Y);

			if (item != null)
				spawnList.DoDragDrop(item.Clone(), DragDropEffects.Copy);
		}

		#endregion
	}
}
