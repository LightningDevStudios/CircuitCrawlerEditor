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
using System.Collections.Generic;
using OpenTK.Graphics.OpenGL;

namespace CircuitCrawlerEditor
{
	public class Tileset
	{
		private Tile[][] tiles;
		private Texture tex;

		private int vertCount;
		private int indCount;
		private int vertBuffer;
		private int indBuffer;

		private bool updated;

		public Tile[][] Tiles { get { return tiles; } private set { tiles = value; } }

		public Tileset(Tile[][] tiles, Texture tex)
		{
			this.tiles = tiles;
			this.tex = tex;

			Reload();
		}

		/**
	 * Draws the tileset.
	 * @param gl The OpenGL context to draw with.
	 */
		public void Draw()
		{
			GL.BindTexture(TextureTarget.Texture2D, tex.TexturePtr);

			GL.BindBuffer(BufferTarget.ArrayBuffer, vertBuffer);
			GL.VertexPointer(3, VertexPointerType.Float, 32, 0);
			GL.TexCoordPointer(2, TexCoordPointerType.Float, 32, 12);
			GL.NormalPointer(NormalPointerType.Float, 32, 20);

			GL.BindBuffer(BufferTarget.ElementArrayBuffer, indBuffer);
			GL.DrawElements(BeginMode.Triangles, indCount, DrawElementsType.UnsignedShort, 0);

			GL.BindBuffer(BufferTarget.ElementArrayBuffer, 0);
			GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
			GL.BindTexture(TextureTarget.Texture2D, 0);
		}

		public void Reload()
		{
			foreach (Tile[] ta in tiles)
				foreach (Tile t in ta)
					t.SetTileset(this);

			List<float> verts = new List<float>();
			List<ushort> indices = new List<ushort>();

			ushort indPos = 0;

			//iterate through tileset, generate vertex data, then append to the buffer.
			for (int i = 0; i < tiles.Length; i++)
			{
				for (int j = 0; j < tiles[0].Length; j++)
				{
					tiles[i][j].calculateBorders(tiles);
					float[] vertData = tiles[i][j].getVertexData();
					ushort[] indData = tiles[i][j].getIndexData(indPos);

					indPos += (ushort)(vertData.Length / 8);

					verts.AddRange(vertData);

					indices.AddRange(indData);
				}
			}

			vertCount = verts.Count;
			indCount = indices.Count;

			//generate VBO
			int[] glBuffers = new int[2];
			GL.GenBuffers(2, glBuffers);
			vertBuffer = glBuffers[0];
			indBuffer = glBuffers[1];

			GL.BindBuffer(BufferTarget.ArrayBuffer, vertBuffer);
			GL.BufferData<float>(BufferTarget.ArrayBuffer, (IntPtr)(vertCount * sizeof(float)), verts.ToArray(), BufferUsageHint.StaticDraw);
			GL.BindBuffer(BufferTarget.ArrayBuffer, 0);

			GL.BindBuffer(BufferTarget.ElementArrayBuffer, indBuffer);
			GL.BufferData<ushort>(BufferTarget.ElementArrayBuffer, (IntPtr)(indCount * sizeof(ushort)), indices.ToArray(), BufferUsageHint.StaticDraw);
			GL.BindBuffer(BufferTarget.ElementArrayBuffer, 0);
		}
	}
}
