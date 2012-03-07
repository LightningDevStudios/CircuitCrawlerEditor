using System;
using System.Drawing;

using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace CircuitCrawlerEditor
{
	public class Camera
	{
		private Vector2 position;

		private Matrix4 view;
		private Matrix4 projection;

		public Matrix4 View { get { return view; } set { view = value; } }
		public Matrix4 Projection { get { return projection; } set { projection = value; } }

		public Vector2 Position
		{
			get
			{
				return position;
			}

			set
			{
				UpdateView(value);
			}
		}

		public Camera(Vector2 position, Size viewportSize)
		{
			UpdateProjection(viewportSize);
			UpdateView(position);
		}

		public Camera()
		{
			projection = Matrix4.Identity;
			view = Matrix4.Identity;
		}

		public void UpdateProjection(Size viewportSize)
		{
			float aspectRatio = (float)viewportSize.Width / (float)viewportSize.Height;
			projection = Matrix4.CreatePerspectiveOffCenter(-2.5f, 2.5f, -2.5f / aspectRatio, 2.5f / aspectRatio, 0.01f, 1.5f);
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
