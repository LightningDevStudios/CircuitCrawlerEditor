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
	/// Automatically generated vertex data for model "Ball.obj".
	/// </summary>
	public static class BallData
	{
		/// <summary>
		/// The number of vertices in the vertex array.
		/// </summary>
		private const int vertexCount = 43;

		/// <summary>
		/// The number of floats in the vertex array.
		/// </summary>
		private const int vertexFloatCount = 344;

		/// <summary>
		/// The number of bytes in the vertex array.
		/// </summary>
		private const int vertexByteCount = 1376;

		/// <summary>
		/// The number of indices in the index array.
		/// </summary>
		private const int indexCount = 144;

		/// <summary>
		/// The number of bytes in the index array.
		/// </summary>
		private const int indexByteCount = 288;

		/// <summary>
		/// Vertex data.
		/// </summary>
		private static readonly float[] vertices =
		{
			7.999999f, -7.999999f, 4.686292f, 0f, 0.75f, 0.589656f, -0.475797f, -0.652628f,
			0f, -11.31371f, 4.686292f, 0.125f, 0.75f, 0.08051f, -0.753389f, -0.652628f,
			11.31371f, -11.31371f, 16f, 0f, 0.5f, 0.707107f, -0.707107f, 0f,
			0f, -16f, 16f, 0.125f, 0.5f, 0f, -1f, 0f,
			-7.999999f, -7.999999f, 4.686292f, 0.25f, 0.75f, -0.475797f, -0.589656f, -0.652628f,
			-11.31371f, -11.31371f, 16f, 0.25f, 0.5f, -0.707107f, -0.707107f, 0f,
			-11.31371f, 0f, 4.686292f, 0.375f, 0.75f, -0.753389f, -0.08051f, -0.652628f,
			-16f, 0f, 16f, 0.375f, 0.5f, -1f, 0f, 0f,
			-7.999999f, 7.999999f, 4.686292f, 0.5f, 0.75f, -0.589656f, 0.475797f, -0.652628f,
			-11.31371f, 11.31371f, 16f, 0.5f, 0.5f, -0.707107f, 0.707107f, 0f,
			0f, 11.31371f, 4.686292f, 0.625f, 0.75f, -0.08051f, 0.753389f, -0.652628f,
			0f, 16f, 16f, 0.625f, 0.5f, 0f, 1f, 0f,
			8f, 8f, 4.686292f, 0.75f, 0.75f, 0.475797f, 0.589656f, -0.652628f,
			11.31371f, 11.31371f, 16f, 0.75f, 0.5f, 0.707107f, 0.707107f, 0f,
			11.31371f, 0f, 4.686292f, 0.875f, 0.75f, 0.753389f, 0.08051f, -0.652628f,
			16f, 0f, 16f, 0.875f, 0.5f, 1f, 0f, 0f,
			7.999999f, -7.999999f, 4.686292f, 1f, 0.75f, 0.589656f, -0.475797f, -0.652628f,
			11.31371f, -11.31371f, 16f, 1f, 0.5f, 0.707107f, -0.707107f, 0f,
			7.999999f, -7.999999f, 27.31371f, 0f, 0.25f, 0.475797f, -0.589656f, 0.652628f,
			0f, -11.31371f, 27.31371f, 0.125f, 0.25f, -0.08051f, -0.753389f, 0.652628f,
			-7.999999f, -7.999999f, 27.31371f, 0.25f, 0.25f, -0.589656f, -0.475797f, 0.652628f,
			-11.31371f, 0f, 27.31371f, 0.375f, 0.25f, -0.753389f, 0.08051f, 0.652628f,
			-7.999999f, 7.999999f, 27.31371f, 0.5f, 0.25f, -0.475797f, 0.589656f, 0.652628f,
			0f, 11.31371f, 27.31371f, 0.625f, 0.25f, 0.08051f, 0.753389f, 0.652628f,
			8f, 8f, 27.31371f, 0.75f, 0.25f, 0.589656f, 0.475797f, 0.652628f,
			11.31371f, 0f, 27.31371f, 0.875f, 0.25f, 0.753389f, -0.08051f, 0.652628f,
			7.999999f, -7.999999f, 27.31371f, 1f, 0.25f, 0.475797f, -0.589656f, 0.652628f,
			0f, 0f, 0f, 0.0625f, 1f, 0f, 0f, -1f,
			0f, 0f, 0f, 0.1875f, 1f, 0f, 0f, -1f,
			0f, 0f, 0f, 0.3125f, 1f, 0f, 0f, -1f,
			0f, 0f, 0f, 0.4375f, 1f, 0f, 0f, -1f,
			0f, 0f, 0f, 0.5625f, 1f, 0f, 0f, -1f,
			0f, 0f, 0f, 0.6875f, 1f, 0f, 0f, -1f,
			0f, 0f, 0f, 0.8125f, 1f, 0f, 0f, -1f,
			0f, 0f, 0f, 0.9375f, 1f, 0f, 0f, -1f,
			0f, 0f, 32f, 0.0625f, 0f, 0f, 0f, 1f,
			0f, 0f, 32f, 0.1875f, 0f, 0f, 0f, 1f,
			0f, 0f, 32f, 0.3125f, 0f, 0f, 0f, 1f,
			0f, 0f, 32f, 0.4375f, 0f, 0f, 0f, 1f,
			0f, 0f, 32f, 0.5625f, 0f, 0f, 0f, 1f,
			0f, 0f, 32f, 0.6875f, 0f, 0f, 0f, 1f,
			0f, 0f, 32f, 0.8125f, 0f, 0f, 0f, 1f,
			0f, 0f, 32f, 0.9375f, 0f, 0f, 0f, 1f,
		};

		/// <summary>
		/// Index data.
		/// </summary>
		private static readonly ushort[] indices =
		{
			0, 1, 2,
			2, 1, 3,
			1, 4, 3,
			3, 4, 5,
			4, 6, 5,
			5, 6, 7,
			6, 8, 7,
			7, 8, 9,
			8, 10, 9,
			9, 10, 11,
			10, 12, 11,
			11, 12, 13,
			12, 14, 13,
			13, 14, 15,
			14, 16, 15,
			15, 16, 17,
			2, 3, 18,
			18, 3, 19,
			3, 5, 19,
			19, 5, 20,
			5, 7, 20,
			20, 7, 21,
			7, 9, 21,
			21, 9, 22,
			9, 11, 22,
			22, 11, 23,
			11, 13, 23,
			23, 13, 24,
			13, 15, 24,
			24, 15, 25,
			15, 17, 25,
			25, 17, 26,
			1, 0, 27,
			4, 1, 28,
			6, 4, 29,
			8, 6, 30,
			10, 8, 31,
			12, 10, 32,
			14, 12, 33,
			16, 14, 34,
			18, 19, 35,
			19, 20, 36,
			20, 21, 37,
			21, 22, 38,
			22, 23, 39,
			23, 24, 40,
			24, 25, 41,
			25, 26, 42,
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
		/// Gets a VBO that contains the vertex data for the model Ball.obj.
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
		/// Gets a VBO that contains the index data for the model Ball.obj.
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
