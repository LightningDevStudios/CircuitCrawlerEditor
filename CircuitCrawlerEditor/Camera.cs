#region License
/**
 * Copyright (c) 2010-2012 Lightning Development Studios <lightningdevelopmentstudios@gmail.com>
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy of
 * this software and associated documentation files (the "Software"), to deal in
 * the Software without restriction, including without limitation the rights to
 * use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies
 * of the Software, and to permit persons to whom the Software is furnished to do
 * so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 */
#endregion

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
			zoom = 1;
			aspectRatio = (float)viewportSize.Width / (float)viewportSize.Height;
			UpdateProjection();
			UpdateView();
		}

		public Camera()
			: this(new Vector2(0, 0), new Size(1, 1))
		{
		}

		private void UpdateProjection()
		{
			projection = Matrix4.CreatePerspectiveOffCenter(-0.75f, 0.75f, -0.75f / aspectRatio, 0.75f / aspectRatio, 1f, Tile.SIZE_F * 6);
		}

		private void UpdateView()
		{
			view = Matrix4.Scale(zoom) * Matrix4.CreateTranslation(position.X, position.Y, -Tile.SIZE_F * 4f);
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
