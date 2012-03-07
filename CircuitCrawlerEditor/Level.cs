using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CircuitCrawlerEditor
{
	public class Level
	{
		private Tileset tileset;

		public void Update()
		{
			tileset.Update();
		}

		public void Draw()
		{
			tileset.Draw();
		}

		public void SetTileset(Tileset ts)
		{
			this.tileset = ts;
		}
	}
}
