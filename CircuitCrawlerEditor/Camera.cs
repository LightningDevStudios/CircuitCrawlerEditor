using System;
using System.Drawing;

using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace CircuitCrawlerEditor
{
	public class Camera
	{
		private float zoom;
		private Vector2 position;

		private Size viewport;

		private Matrix4 view;
		private Matrix4 projection;

		public Matrix4 View { get { return view; } set { view = value; } }
		public Matrix4 Projection { get { return projection; } set { projection = value; } }

		public float Zoom 
		{
			get
			{
				return zoom;
			}
			set
			{
				zoom = value;
				UpdateProjection(viewport);
			}
		}

		public Vector2 Position
		{
			get
			{
				return position;
			}

			set
			{
				position = value;
				UpdateView(value);
			}
		}

		public Camera(Vector2 position, Size viewportSize)
		{
			UpdateProjection(viewportSize);
			UpdateView(position);
			zoom = 100;
			viewport = viewportSize;
		}

		public Camera()
		{
			projection = Matrix4.Identity;
			view = Matrix4.Identity;
			zoom = 100;
			viewport = new Size(1, 1);
		}

		public void UpdateProjection(Size viewportSize)
		{
			float aspectRatio = (float)viewportSize.Width / (float)viewportSize.Height;
			viewport = viewportSize;
			projection = Matrix4.CreatePerspectiveOffCenter(-2.5f, 2.5f, -2.5f / aspectRatio, 2.5f / aspectRatio, 1 / zoom, 1.5f);
		}

		public void UpdateView(Vector2 position)
		{
			this.position = position;
			view = Matrix4.CreateTranslation(position.X, position.Y, 0);
		}

		public void LoadProjection()
		{
			GL.MatrixMode(MatrixMode.Projection);
			GL.LoadMatrix(ref projection);
		}

		public void LoadView()
		{
			GL.MatrixMode(MatrixMode.Modelview);
			GL.LoadMatrix(ref view);
		}
	}
}
