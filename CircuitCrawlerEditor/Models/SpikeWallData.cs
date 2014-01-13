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

using OpenTK.Graphics.OpenGL;

namespace CircuitCrawlerEditor.Models
{
	/// <summary>
	/// Automatically generated vertex data for model "SpikeWall.obj".
	/// </summary>
	public static class SpikeWallData
	{
		/// <summary>
		/// The number of vertices in the vertex array.
		/// </summary>
		private const int vertexCount = 40;

		/// <summary>
		/// The number of floats in the vertex array.
		/// </summary>
		private const int vertexFloatCount = 320;

		/// <summary>
		/// The number of bytes in the vertex array.
		/// </summary>
		private const int vertexByteCount = 1280;

		/// <summary>
		/// The number of indices in the index array.
		/// </summary>
		private const int indexCount = 96;

		/// <summary>
		/// The number of bytes in the index array.
		/// </summary>
		private const int indexByteCount = 192;

		/// <summary>
		/// Vertex data.
		/// </summary>
		private static readonly float[] vertices =
		{
			-36f, 6.686293f, 6.686293f, 0.169922f, 0.998047f, 0.21693f, -0.690269f, -0.690268f,
			-36f, 2.000002f, 18f, 0.251953f, 0.998047f, 0.21693f, -0.976187f, 0f,
			36f, 18f, 18f, 0.498047f, 0.001953006f, 1f, 0f, 0f,
			-36f, 6.686293f, 29.31371f, 0.333984f, 0.998047f, 0.21693f, -0.690269f, 0.690269f,
			-36f, 18f, 34f, 0.416016f, 0.998047f, 0.21693f, 0f, 0.976187f,
			-36f, 29.31371f, 29.31371f, 0.498047f, 0.998047f, 0.21693f, 0.690268f, 0.690269f,
			-36f, 34f, 18f, 0.583984f, 0.998047f, 0.21693f, 0.976187f, 0f,
			-36f, 29.31371f, 6.686292f, 0.666016f, 0.998047f, 0.21693f, 0.690269f, -0.690269f,
			-36f, 18f, 2f, 0.748047f, 0.998047f, 0.21693f, 0f, -0.976187f,
			-36f, 6.686293f, 6.686293f, 0.830078f, 0.998047f, 0.21693f, -0.690269f, -0.690268f,
			-36f, -31.31371f, 6.686293f, 0.169922f, 0.998047f, 0.21693f, -0.690269f, -0.690268f,
			-36f, -36f, 18f, 0.251953f, 0.998047f, 0.21693f, -0.976187f, 0f,
			36f, -20f, 18f, 0.498047f, 0.001953006f, 1f, 0f, 0f,
			-36f, -31.31371f, 29.31371f, 0.333984f, 0.998047f, 0.21693f, -0.690269f, 0.690269f,
			-36f, -20f, 34f, 0.416016f, 0.998047f, 0.21693f, 0f, 0.976187f,
			-36f, -8.686293f, 29.31371f, 0.498047f, 0.998047f, 0.21693f, 0.690268f, 0.690269f,
			-36f, -4.000001f, 18f, 0.583984f, 0.998047f, 0.21693f, 0.976187f, 0f,
			-36f, -8.686292f, 6.686292f, 0.666016f, 0.998047f, 0.21693f, 0.690269f, -0.690269f,
			-36f, -20f, 2f, 0.748047f, 0.998047f, 0.21693f, 0f, -0.976187f,
			-36f, -31.31371f, 6.686293f, 0.830078f, 0.998047f, 0.21693f, -0.690269f, -0.690268f,
			-36f, 6.686293f, 44.68629f, 0.169922f, 0.998047f, 0.21693f, -0.690269f, -0.690268f,
			-36f, 2.000002f, 56f, 0.251953f, 0.998047f, 0.21693f, -0.976187f, 0f,
			36f, 18f, 56f, 0.498047f, 0.001953006f, 1f, 0f, 0f,
			-36f, 6.686293f, 67.31371f, 0.333984f, 0.998047f, 0.21693f, -0.690269f, 0.690269f,
			-36f, 18f, 72f, 0.416016f, 0.998047f, 0.21693f, 0f, 0.976187f,
			-36f, 29.31371f, 67.31371f, 0.498047f, 0.998047f, 0.21693f, 0.690268f, 0.690269f,
			-36f, 34f, 56f, 0.583984f, 0.998047f, 0.21693f, 0.976187f, 0f,
			-36f, 29.31371f, 44.68629f, 0.666016f, 0.998047f, 0.21693f, 0.690269f, -0.690269f,
			-36f, 18f, 40f, 0.748047f, 0.998047f, 0.21693f, 0f, -0.976187f,
			-36f, 6.686293f, 44.68629f, 0.830078f, 0.998047f, 0.21693f, -0.690269f, -0.690268f,
			-36f, -31.31371f, 44.68629f, 0.169922f, 0.998047f, 0.21693f, -0.690269f, -0.690268f,
			-36f, -36f, 56f, 0.251953f, 0.998047f, 0.21693f, -0.976187f, 0f,
			36f, -20f, 56f, 0.498047f, 0.001953006f, 1f, 0f, 0f,
			-36f, -31.31371f, 67.31371f, 0.333984f, 0.998047f, 0.21693f, -0.690269f, 0.690269f,
			-36f, -20f, 72f, 0.416016f, 0.998047f, 0.21693f, 0f, 0.976187f,
			-36f, -8.686293f, 67.31371f, 0.498047f, 0.998047f, 0.21693f, 0.690268f, 0.690269f,
			-36f, -4.000001f, 56f, 0.583984f, 0.998047f, 0.21693f, 0.976187f, 0f,
			-36f, -8.686292f, 44.68629f, 0.666016f, 0.998047f, 0.21693f, 0.690269f, -0.690269f,
			-36f, -20f, 40f, 0.748047f, 0.998047f, 0.21693f, 0f, -0.976187f,
			-36f, -31.31371f, 44.68629f, 0.830078f, 0.998047f, 0.21693f, -0.690269f, -0.690268f,
		};

		/// <summary>
		/// Index data.
		/// </summary>
		private static readonly ushort[] indices =
		{
			0, 1, 2,
			1, 3, 2,
			3, 4, 2,
			4, 5, 2,
			5, 6, 2,
			6, 7, 2,
			7, 8, 2,
			8, 9, 2,
			10, 11, 12,
			11, 13, 12,
			13, 14, 12,
			14, 15, 12,
			15, 16, 12,
			16, 17, 12,
			17, 18, 12,
			18, 19, 12,
			20, 21, 22,
			21, 23, 22,
			23, 24, 22,
			24, 25, 22,
			25, 26, 22,
			26, 27, 22,
			27, 28, 22,
			28, 29, 22,
			30, 31, 32,
			31, 33, 32,
			33, 34, 32,
			34, 35, 32,
			35, 36, 32,
			36, 37, 32,
			37, 38, 32,
			38, 39, 32,
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
		/// Gets a VBO that contains the vertex data for the model SpikeWall.obj.
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
		/// Gets a VBO that contains the index data for the model SpikeWall.obj.
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
