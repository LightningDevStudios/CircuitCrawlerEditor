using System;
using System.Collections.Generic;
using System.ComponentModel;
using CircuitCrawlerEditor.Entities;

namespace CircuitCrawlerEditor.Triggers
{
    public class EffectRaiseBridge : Effect
    {
		[Category("Values"), Description("The X index of the tileset tile to activate.")]
        public int TileX { get; set; }

		[Category("Values"), Description("The Y index of the tileset tile to activate.")]
		public int TileY { get; set; }
    }
}
