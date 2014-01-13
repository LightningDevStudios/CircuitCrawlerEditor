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
		private int vertVbo, indVbo;

		public SelectionCube(Vector2 position)
		{
			this.color = Color4.Green;
			this.position = position;
			vertVbo = BlockData.GetVertexBufferID();
			indVbo = BlockData.GetIndexBufferID();
		}

		public bool Hidden { get; set; }

		public void Draw()
		{
			if (Hidden)
				return;

			GL.Color4(color);

			Matrix4 model = Matrix4.Scale(80f / 50f) * Matrix4.CreateTranslation(new Vector3(position));

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
