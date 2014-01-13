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
using System.Drawing;

using OpenTK;

using CircuitCrawlerEditor.Entities;

namespace CircuitCrawlerEditor
{
	public static class TilesetHelper
	{
		/**
	 * Gets the vertices for a non-floor tile.
	 * @param borders The borders of the tile.
	 * @param size The size of the tile.
	 * @param height The height of the tile.
	 * @return The vertices for the wall tile.
	 */
		public static float[] getTileVertices(byte borders, float size, float height)
		{
			bool left = (borders & 0x08) == 0x08;
			bool right = (borders & 0x10) == 0x10;
			bool top = (borders & 0x02) == 0x02;
			bool bottom = (borders & 0x40) == 0x40;

			int vertLength = 12;
			if (left) vertLength += 12;
			if (right) vertLength += 12;
			if (bottom) vertLength += 12;
			if (top) vertLength += 12;

			float[] vertices = new float[vertLength];

			vertices[0] = -size;
			vertices[1] = size;
			vertices[2] = height;
			vertices[3] = -size;
			vertices[4] = -size;
			vertices[5] = height;
			vertices[6] = size;
			vertices[7] = -size;
			vertices[8] = height;
			vertices[9] = size;
			vertices[10] = size;
			vertices[11] = height;

			int addPosition = 12;

			if (left)
			{
				vertices[addPosition] = -size;
				vertices[addPosition + 1] = size;
				vertices[addPosition + 2] = height;
				vertices[addPosition + 3] = -size;
				vertices[addPosition + 4] = size;
				vertices[addPosition + 5] = 0f;
				vertices[addPosition + 6] = -size;
				vertices[addPosition + 7] = -size;
				vertices[addPosition + 8] = 0f;
				vertices[addPosition + 9] = -size;
				vertices[addPosition + 10] = -size;
				vertices[addPosition + 11] = height;
				addPosition += 12;
			}

			if (right)
			{
				vertices[addPosition] = size;
				vertices[addPosition + 1] = -size;
				vertices[addPosition + 2] = height;
				vertices[addPosition + 3] = size;
				vertices[addPosition + 4] = -size;
				vertices[addPosition + 5] = 0f;
				vertices[addPosition + 6] = size;
				vertices[addPosition + 7] = size;
				vertices[addPosition + 8] = 0f;
				vertices[addPosition + 9] = size;
				vertices[addPosition + 10] = size;
				vertices[addPosition + 11] = height;
				addPosition += 12;
			}

			if (top)
			{
				vertices[addPosition] = size;
				vertices[addPosition + 1] = size;
				vertices[addPosition + 2] = height;
				vertices[addPosition + 3] = size;
				vertices[addPosition + 4] = size;
				vertices[addPosition + 5] = 0f;
				vertices[addPosition + 6] = -size;
				vertices[addPosition + 7] = size;
				vertices[addPosition + 8] = 0f;
				vertices[addPosition + 9] = -size;
				vertices[addPosition + 10] = size;
				vertices[addPosition + 11] = height;
				addPosition += 12;
			}

			if (bottom)
			{
				vertices[addPosition] = -size;
				vertices[addPosition + 1] = -size;
				vertices[addPosition + 2] = height;
				vertices[addPosition + 3] = -size;
				vertices[addPosition + 4] = -size;
				vertices[addPosition + 5] = 0f;
				vertices[addPosition + 6] = size;
				vertices[addPosition + 7] = -size;
				vertices[addPosition + 8] = 0f;
				vertices[addPosition + 9] = size;
				vertices[addPosition + 10] = -size;
				vertices[addPosition + 11] = height;
				addPosition += 12;
			}

			return vertices;
		}

		/**
		 * Gets the texture coordinates for a wall tile.
		 * @param borders A byte representing the tiles around the tile.
		 * @return The texture coordinates as a float array.
		 */
		public static float[] getWallTexCoords(byte borders)
		{
			bool left = (borders & 0x08) == 0x08;
			bool right = (borders & 0x10) == 0x10;
			bool top = (borders & 0x02) == 0x02;
			bool bottom = (borders & 0x40) == 0x40;

			int sideCount = 0;
			if (left) sideCount++;
			if (right) sideCount++;
			if (bottom) sideCount++;
			if (top) sideCount++;

			float[] texCoords = new float[(sideCount + 1) * 8];

			float[] baseTexCoords = new float[]
		{
			128f / 512f + 1f / 1024f, 64f / 256f + 1f / 512f,
			128f / 512f + 1f / 1024f, 128f / 256f - 1f / 512f,
			192f / 512f - 1f / 1024f, 128f / 256f - 1f / 512f,
			192f / 512f - 1f / 1024f, 64f / 256f + 1f / 512f,
		};

			float[] sideTexCoords = new float[]
		{
			1f / 1024f, 64f / 256f + 1f / 512f,
			1f / 1024f, 128f / 256f - 1f / 512f,
			64f / 512f - 1f / 1024f, 128f / 256f - 1f / 512f,
			64f / 512f - 1f / 1024f, 64f / 256f + 1f / 512f
		};

			Array.Copy(baseTexCoords, 0, texCoords, 0, baseTexCoords.Length);

			for (int i = 0; i < sideCount; i++)
			{
				Array.Copy(sideTexCoords, 0, texCoords, (i + 1) * 8, sideTexCoords.Length);
			}

			return texCoords;
		}

		/**
		 * Gets the texture coordinates for a pit tile.
		 * @param borders A byte representing the tiles around the tile.
		 * @return The texture coordinates as a float array.
		 */
		public static float[] getPitTexCoords(byte borders)
		{
			bool left = (borders & 0x08) == 0x08;
			bool right = (borders & 0x10) == 0x10;
			bool top = (borders & 0x02) == 0x02;
			bool bottom = (borders & 0x40) == 0x40;

			int sideCount = 0;
			if (left) sideCount++;
			if (right) sideCount++;
			if (bottom) sideCount++;
			if (top) sideCount++;

			float[] texCoords = new float[(sideCount + 1) * 8];

			float[] baseTexCoords = new float[]
		{
			128f / 512f + 1f / 1024f, 1f / 512f,
			128f / 512f + 1f / 1024f, 64f / 256f - 1f / 512f,
			192f / 512f - 1f / 1024f, 64f / 256f - 1f / 512f,
			192f / 512f - 1f / 1024f, 1f / 512f,
		};

			float[] sideTexCoords = new float[]
		{
			64f / 512f + 1f / 1024f, 128f / 256f - 1f / 512f,
			64f / 512f + 1f / 1024f, 64f / 256f + 1f / 512f,
			128f / 512f - 1f / 1024f, 64f / 256f + 1f / 512f,
			128f / 512f - 1f / 1024f, 128f / 256f - 1f / 512f
		};

			Array.Copy(baseTexCoords, 0, texCoords, 0, baseTexCoords.Length);

			for (int i = 0; i < sideCount; i++)
			{
				Array.Copy(sideTexCoords, 0, texCoords, (i + 1) * 8, sideTexCoords.Length);
			}

			return texCoords;
		}

		/**
		 * Get the vertex normals for a tile.
		 * @param borders A byte representing the tiles around the tile.
		 * @return The normals as a float array.
		 */
		public static float[] getTileNormals(byte borders)
		{
			float[] baseNormals =
			{
				0, 0, 1,
				0, 0, 1,
				0, 0, 1,
				0, 0, 1,
			};

			bool left = (borders & 0x08) == 0x08;
			bool right = (borders & 0x10) == 0x10;
			bool top = (borders & 0x02) == 0x02;
			bool bottom = (borders & 0x40) == 0x40;

			int sideCount = 0;
			if (left) sideCount++;
			if (right) sideCount++;
			if (bottom) sideCount++;
			if (top) sideCount++;

			float[] normals = new float[12 * (sideCount + 1)];

			Array.Copy(baseNormals, 0, normals, 0, baseNormals.Length);

			int addPosition = 12;

			if (left)
			{
				normals[addPosition] = -1;
				normals[addPosition + 3] = -1;
				normals[addPosition + 6] = -1;
				normals[addPosition + 9] = -1;
				addPosition += 12;
			}

			if (right)
			{
				normals[addPosition] = 1;
				normals[addPosition + 3] = 1;
				normals[addPosition + 6] = 1;
				normals[addPosition + 9] = 1;
				addPosition += 12;
			}

			if (top)
			{
				normals[addPosition + 1] = 1;
				normals[addPosition + 4] = 1;
				normals[addPosition + 7] = 1;
				normals[addPosition + 10] = 1;
				addPosition += 12;
			}

			if (bottom)
			{
				normals[addPosition + 1] = -1;
				normals[addPosition + 4] = -1;
				normals[addPosition + 7] = -1;
				normals[addPosition + 10] = -1;
				addPosition += 12;
			}

			return normals;
		}

		/**
		 * Gets the indices of the tile.
		 * @param borders A byte representing the tiles around the tile.
		 * @return The indices as an int array.
		 */
		public static ushort[] getTileIndices(byte borders)
		{
			bool left = (borders & 0x08) == 0x08;
			bool right = (borders & 0x10) == 0x10;
			bool top = (borders & 0x02) == 0x02;
			bool bottom = (borders & 0x40) == 0x40;

			int sideCount = 0;
			if (left) sideCount++;
			if (right) sideCount++;
			if (bottom) sideCount++;
			if (top) sideCount++;

			ushort[] indices = new ushort[(sideCount + 1) * 6];

			ushort[] trianglesIndices = new ushort[] { 0, 1, 2, 0, 2, 3 };

			Array.Copy(trianglesIndices, 0, indices, 0, trianglesIndices.Length);

			for (int i = 0; i < sideCount; i++)
			{
				ushort[] newIndices = new ushort[6];
				for (int j = 0; j < trianglesIndices.Length; j++)
				{
					newIndices[j] = (ushort)(trianglesIndices[j] + ((i + 1) * 4));
				}

				Array.Copy(newIndices, 0, indices, (i + 1) * 6, newIndices.Length);
			}

			return indices;
		}

		public static float[] getTextureVertices(Texture tex, Point p)
		{
			return getTextureVertices(p.X, p.Y, 0, tex.XTiles - 1, 0, tex.YTiles - 1, tex.OffsetX, tex.OffsetY);
		}

		public static float[] getTextureVertices(int x, int y, int minX, int maxX, int minY, int maxY, float offsetX, float offsetY)
	{
		if (x >= minX && x <= maxX && y >= minY && y <= maxY)
		{
			float intervalX = 1.0f / (float)(maxX - minX + 1);
			float intervalY = 1.0f / (float)(maxY - minY + 1);

			float negX = x * intervalX + offsetX;
			float posX = (x + 1) * intervalX - offsetX;

			float negY = y * intervalY + offsetY;
			float posY = (y + 1) * intervalY - offsetY;

			float[] coords = 
			{
				negX, negY,
				negX, posY,
				posX, negY,
				posX, posY 
			};

			return coords;
		}

		else
			return null;
	}

		public static float[] getTextureVertices(Texture tex, int tileID)
		{
			int y = tileID / tex.XTiles;
			int x = tileID - (tex.XTiles * y);

			return getTextureVertices(x, y, 0, tex.XTiles - 1, 0, tex.YTiles - 1, tex.OffsetX, tex.OffsetY);
		}

		public static int getTilesetIndex(float[] vertices, int min, int max)
		{
			float interval = (1.0f / (float)(max - min + 1));

			int x = (int)(vertices[4] / interval);
			int y = (int)(vertices[1] / interval);

			return (y * (max - min + 1) + x);
		}

		public static int getTilesetX(int tileID, Texture tex)
		{
			return tileID - (tex.XTiles * (tileID / tex.XTiles));
		}

		public static int getTilesetY(int tileID, Texture tex)
		{
			return (tileID / tex.XTiles);
		}

		public static int getTilesetID(int x, int y, Texture tex)
		{
			return (y * tex.XTiles + x);
		}

		public static void setInitialTileOffset(Tile tile, Point p, int length, int width)
		{
			tile.Position = new Vector2(-(float)width / 2 * Tile.SIZE_F + p.X * Tile.SIZE_F + Tile.SIZE_F / 2, (float)length / 2 * Tile.SIZE_F - p.Y * Tile.SIZE_F - Tile.SIZE_F / 2);
		}
	}
}
