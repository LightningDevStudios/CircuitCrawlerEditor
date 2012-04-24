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
		private float aspectRatio;

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
				UpdateView();
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
				UpdateView();
			}
		}

		public float AspectRatio
		{
			get
			{
				return aspectRatio;
			}

			set
			{
				aspectRatio = value;
				UpdateProjection();
			}
		}

		public Camera(Vector2 position, Size viewportSize)
		{
			UpdateProjection();
			UpdateView();
			zoom = 1;
			aspectRatio = (float)viewportSize.Width / (float)viewportSize.Height;
		}

		public Camera()
		{
			projection = Matrix4.Identity;
			view = Matrix4.Identity;
			zoom = 1;
		}

		private void UpdateProjection()
		{
			projection = Matrix4.CreatePerspectiveOffCenter(-2.5f, 2.5f, -2.5f / aspectRatio, 2.5f / aspectRatio, 0.01f, 1.5f);
		}

		private void UpdateView()
		{
			view = Matrix4.Scale(zoom) * Matrix4.CreateTranslation(position.X, position.Y, 0);
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
