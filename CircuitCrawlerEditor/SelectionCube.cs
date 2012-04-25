using System;

using CircuitCrawlerEditor.Models;

using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace CircuitCrawlerEditor
{
	public class SelectionCube
	{
		private bool alphaIncreasing;
		private Color4 color;
		private Vector2 position;
		private Matrix4 model;
		private int vertVbo, indVbo;

		public SelectionCube(Vector2 position)
		{
			this.color = Color4.Green;
			this.model = Matrix4.Scale(80f / 50f) * Matrix4.CreateTranslation(new Vector3(position));
			vertVbo = BlockData.GetVertexBufferID();
			indVbo = BlockData.GetIndexBufferID();
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
				this.model = Matrix4.Scale(80f / 50f) * Matrix4.CreateTranslation(new Vector3(position));
			}
		}

		public bool Hidden { get; set; }

		public void Draw()
		{
			if (Hidden)
				return;

			GL.Color4(color);

			GL.MultMatrix(ref model);

			GL.BindTexture(TextureTarget.Texture2D, 0);

			GL.BindBuffer(BufferTarget.ArrayBuffer, vertVbo);
			GL.VertexPointer(3, VertexPointerType.Float, 32, 0);
			GL.TexCoordPointer(2, TexCoordPointerType.Float, 32, 12);
			GL.NormalPointer(NormalPointerType.Float, 32, 20);
			GL.BindBuffer(BufferTarget.ArrayBuffer, 0);

			GL.BindBuffer(BufferTarget.ElementArrayBuffer, indVbo);
			GL.DrawElements(BeginMode.Triangles, BlockData.GetIndexCount(), DrawElementsType.UnsignedShort, 0);
			GL.BindBuffer(BufferTarget.ElementArrayBuffer, 0);

			GL.Color4(new Color4(1f, 1f, 1f, 1f));
		}

		public void Update()
		{
			if (alphaIncreasing)
			{
				color.A += 0.03f;

				if (color.A > 0.8f)
				{
					color.A = 0.8f;
					alphaIncreasing = false;
				}
			}
			else
			{
				color.A -= 0.03f;

				if (color.A < 0)
				{
					color.A = 0;
					alphaIncreasing = true;
				}
			}
		}
	}
}
