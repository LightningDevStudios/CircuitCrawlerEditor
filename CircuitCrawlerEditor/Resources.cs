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
