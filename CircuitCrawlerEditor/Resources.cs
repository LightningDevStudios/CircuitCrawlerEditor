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
using System.IO;

using OpenTK.Graphics.OpenGL;

namespace CircuitCrawlerEditor
{
	public static class Resources
	{
		public static Dictionary<string, Texture> Textures = new Dictionary<string, Texture>();

		public static void LoadAll()
		{
			if (Textures.Count > 0)
				Unload();

			foreach (FileInfo f in Directory.CreateDirectory(@"Resources/Textures").EnumerateFiles())
			{
				if (f.Extension == ".png")
				{
					if (f.Name == "tilesetworld.png")
						Textures.Add("tilesetworld.png", new Texture(new Bitmap(f.FullName), 16, 8));
					else
						Textures.Add(f.Name, new Texture(new Bitmap(f.FullName), 1, 1));
				}
			}
		}

		public static void Unload()
		{
			foreach (Texture tex in Textures.Values)
			{
				GL.DeleteTexture(tex.TexturePtr);
			}

			Textures.Clear();
		}
	}
}
