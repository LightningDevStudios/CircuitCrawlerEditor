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
using System.Drawing.Design;
using System.Drawing.Imaging;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using System.ComponentModel;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace CircuitCrawlerEditor
{
	public class Texture
	{
		//private variables
		private Bitmap bmp;
		private int xSize;
		private int ySize;
		private int xPixels;
		private int yPixels;
		private int xTiles;
		private int yTiles;
		private float offsetX;
		private float offsetY;
		private int texturePtr;
		private TextureMinFilter minFilter;
		private TextureMagFilter magFilter;
		private TextureWrapMode wrapS;
		private TextureWrapMode wrapT;
		private string id;

		//fields
		[CategoryAttribute("Bitmap"), DescriptionAttribute("The System.Drawing.Imaging.Bitmap class that stores the image.")]
		public Bitmap Bmp { get { return bmp; } set { bmp = value; Reload(); } }

		[CategoryAttribute("Sizes"), DescriptionAttribute("Number of pixels in the X axis"), ReadOnlyAttribute(true)]
		public int XSize { get { return xSize; } }

		[CategoryAttribute("Sizes"), DescriptionAttribute("Number of pixels in the Y axis"), ReadOnlyAttribute(true)]
		public int YSize { get { return ySize; } }

		[CategoryAttribute("Sizes"), DescriptionAttribute("Number of pixels per tile in the X axis"), ReadOnlyAttribute(true)]
		public int XPixels { get { return xPixels; } }

		[CategoryAttribute("Sizes"), DescriptionAttribute("Number of pixels per tile in the Y axis"), ReadOnlyAttribute(true)]
		public int YPixels { get { return yPixels; } }

		[CategoryAttribute("Sizes"), DescriptionAttribute("The number of tiles in the X direction")]
		public int XTiles { get { return xTiles; } set { xTiles = value; } }

		[CategoryAttribute("Sizes"), DescriptionAttribute("The number of tiles in the Y direction")]
		public int YTiles { get { return yTiles; } set { yTiles = value; } }

		public float OffsetX { get { return offsetX; } set { offsetX = value; } }

		public float OffsetY { get { return offsetY; } set { offsetY = value; } }

		[CategoryAttribute("OpenGL Settings"), DescriptionAttribute("Internal OpenGL pointer to the texture data")]
		public int TexturePtr { get { return texturePtr; } }

		[CategoryAttribute("OpenGL settings"), DescriptionAttribute("Near bilinear filtering")]
		public TextureMinFilter MinFilter { get { return minFilter; } set { minFilter = value; Reload(); } }

		[CategoryAttribute("OpenGL settings"), DescriptionAttribute("Far bilinear filtering")]
		public TextureMagFilter MagFilter { get { return magFilter; } set { magFilter = value; Reload(); } }

		[CategoryAttribute("OpenGL settings"), DescriptionAttribute("Texture wrapping along the X axis")]
		public TextureWrapMode WrapS { get { return wrapS; } set { wrapS = value; Reload(); } }

		[CategoryAttribute("OpenGL settings"), DescriptionAttribute("Texture wrapping along the Y axis")]
		public TextureWrapMode WrapT { get { return wrapT; } set { wrapT = value; Reload(); } }

		[CategoryAttribute("ID"), DescriptionAttribute("A unique ID for each Texture")]
		public String ID { get { return id; } set { id = value; } }

		public Texture(Bitmap bmp, int xTiles, int yTiles) : this(bmp, xTiles, yTiles, TextureMinFilter.Nearest, TextureMagFilter.Nearest, TextureWrapMode.Repeat, TextureWrapMode.Repeat) { }

		public Texture(Bitmap bmp, int xTiles, int yTiles, TextureMinFilter minFilter, TextureMagFilter magFilter, TextureWrapMode wrapS, TextureWrapMode wrapT)
		{
			this.bmp = bmp;
			this.xSize = bmp.Width;
			this.ySize = bmp.Height;
			this.xTiles = xTiles;
			this.yTiles = yTiles;
			if (xTiles == 0 || yTiles == 0)
			{
				this.xPixels = xSize;
				this.yPixels = ySize;
			}
			else
			{
				this.xPixels = xSize / xTiles;
				this.yPixels = ySize / yTiles;
			}

			this.minFilter = minFilter;
			this.magFilter = magFilter;
			this.wrapS = wrapS;
			this.wrapT = wrapT;

			offsetX = 1.0f / (float)(2 * xSize);
			offsetY = 1.0f / (float)(2 * ySize);

			Load();
		}

		private void Load()
		{
			GL.GenTextures(1, out texturePtr);
			Reload();
		}

		public void Reload()
		{
			BitmapData bmpData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
			GL.BindTexture(TextureTarget.Texture2D, texturePtr);

			GL.TexEnv(TextureEnvTarget.TextureEnv, TextureEnvParameter.TextureEnvMode, (float)TextureEnvMode.Modulate);
			GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (float)minFilter);
			GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (float)magFilter);
			GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (float)wrapS);
			GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (float)wrapT);

			GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, bmp.Width, bmp.Height, 0, OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, bmpData.Scan0);

			bmp.UnlockBits(bmpData);
		}

		public override string ToString()
		{
			if (String.IsNullOrEmpty(ID))
				return this.GetType().Name;

			return ID;
		}
	}
}
