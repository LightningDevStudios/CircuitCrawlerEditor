using System;
using System.Drawing;
using System.Windows.Forms;

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
			l.Diffuse = Color4.Blue;
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
	}
}
