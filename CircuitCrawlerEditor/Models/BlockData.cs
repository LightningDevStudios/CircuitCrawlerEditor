#region MIT License
/*Copyright (c) 2010-2012 Lightning Development Studios <lightningdevelopmentstudios@gmail.com>
Permission is hereby granted, free of charge, to any person obtaining a copy of
this software and associated documentation files (the "Software"), to deal in
the Software without restriction, including without limitation the rights to
use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies
of the Software, and to permit persons to whom the Software is furnished to do
so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.*/
#endregion

using System;

using OpenTK.Graphics.OpenGL;

namespace CircuitCrawlerEditor.Models
{
	/// <summary>
	/// Automatically generated vertex data for model "Block.obj".
	/// </summary>
	public static class BlockData
	{
		/// <summary>
		/// The number of vertices in the vertex array.
		/// </summary>
		private const int vertexCount = 24;

		/// <summary>
		/// The number of floats in the vertex array.
		/// </summary>
		private const int vertexFloatCount = 192;

		/// <summary>
		/// The number of bytes in the vertex array.
		/// </summary>
		private const int vertexByteCount = 768;

		/// <summary>
		/// The number of indices in the index array.
		/// </summary>
		private const int indexCount = 36;

		/// <summary>
		/// The number of bytes in the index array.
		/// </summary>
		private const int indexByteCount = 72;

		/// <summary>
		/// Vertex data.
		/// </summary>
		private static readonly float[] vertices =
		{
			-25f, 25f, 0f, 0f, 1f, 0f, 1f, 0f,
			25f, 25f, 0f, 1f, 1f, 0f, 1f, 0f,
			-25f, 25f, 50f, 0f, 0f, 0f, 1f, 0f,
			25f, 25f, 50f, 1f, 0f, 0f, 1f, 0f,
			-25f, 25f, 50f, 0f, 1f, 0f, 0f, 1f,
			25f, 25f, 50f, 1f, 1f, 0f, 0f, 1f,
			-25f, -25f, 50f, 0f, 0f, 0f, 0f, 1f,
			25f, -25f, 50f, 1f, 0f, 0f, 0f, 1f,
			-25f, -25f, 50f, 0f, 0f, 0f, -1f, 0f,
			25f, -25f, 50f, 1f, 0f, 0f, -1f, 0f,
			-25f, -25f, 0f, 0f, 1f, 0f, -1f, 0f,
			25f, -25f, 0f, 1f, 1f, 0f, -1f, 0f,
			-25f, -25f, 0f, 0f, 0f, 0f, 0f, -1f,
			25f, -25f, 0f, 1f, 0f, 0f, 0f, -1f,
			-25f, 25f, 0f, 0f, 1f, 0f, 0f, -1f,
			25f, 25f, 0f, 1f, 1f, 0f, 0f, -1f,
			25f, 25f, 0f, 0f, 1f, 1f, 0f, 0f,
			25f, -25f, 0f, 1f, 1f, 1f, 0f, 0f,
			25f, 25f, 50f, 0f, 0f, 1f, 0f, 0f,
			25f, -25f, 50f, 1f, 0f, 1f, 0f, 0f,
			-25f, -25f, 0f, 1f, 1f, -1f, 0f, 0f,
			-25f, 25f, 0f, 0f, 1f, -1f, 0f, 0f,
			-25f, -25f, 50f, 1f, 0f, -1f, 0f, 0f,
			-25f, 25f, 50f, 0f, 0f, -1f, 0f, 0f,
		};

		/// <summary>
		/// Index data.
		/// </summary>
		private static readonly ushort[] indices =
		{
			0, 1, 2,
			2, 1, 3,
			4, 5, 6,
			6, 5, 7,
			8, 9, 10,
			10, 9, 11,
			12, 13, 14,
			14, 13, 15,
			16, 17, 18,
			18, 17, 19,
			20, 21, 22,
			22, 21, 23,
		};

		/// <summary>
		/// A VBO handle for vertices.
		/// </summary>
		private static int vertVbo;

		/// <summary>
		/// A VBO handle for indices.
		/// </summary>
		private static int indVbo;

		/// <summary>
		/// Gets a VBO that contains the vertex data for the model Block.obj.
		/// </summary>
		/// <returns>A VBO handle.</returns>
		public static int GetVertexBufferID()
		{
			if (vertVbo == 0)
			{
				GL.GenBuffers(1, out vertVbo);

				GL.BindBuffer(BufferTarget.ArrayBuffer, vertVbo);
				GL.BufferData<float>(BufferTarget.ArrayBuffer, (IntPtr)vertexByteCount, vertices, BufferUsageHint.StaticDraw);
				GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
			}

			return vertVbo;
		}

		/// <summary>
		/// Gets a VBO that contains the index data for the model Block.obj.
		/// </summary>
		/// <returns>A VBO handle.</returns>
		public static int GetIndexBufferID()
		{
			if (indVbo == 0)
			{
				GL.GenBuffers(1, out indVbo);

				GL.BindBuffer(BufferTarget.ArrayBuffer, indVbo);
				GL.BufferData<ushort>(BufferTarget.ArrayBuffer, (IntPtr)indexByteCount, indices, BufferUsageHint.StaticDraw);
				GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
			}

			return indVbo;
		}

		/// <summary>
		/// Gets the number of indices.
		/// </summary>
		/// <returns>The number of indices.</returns>
		public static int GetIndexCount()
		{
			return indexCount;
		}

		/// <summary>
		/// Unloads the model data from the VBO.
		/// </summary>
		public static void Unload()
		{
			int[] buffers = new int[] { vertVbo, indVbo };
			GL.DeleteBuffers(2, buffers);
			vertVbo = 0;
			indVbo = 0;
		}
	}
}
