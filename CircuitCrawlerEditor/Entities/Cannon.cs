using System;
using System.ComponentModel;

using CircuitCrawlerEditor.Models;

namespace CircuitCrawlerEditor.Entities
{
	class Cannon : Entity
	{
		public Cannon(float xPos, float yPos)
			: base(xPos, yPos)
		{
            BallSpeed = 5000000;
            Stupidity = 0;
			vertVbo = BlockData.GetVertexBufferID();
			indVbo = BlockData.GetIndexBufferID();
			indCount = BlockData.GetIndexCount();
			tex = Resources.Textures["block.png"];
		}

		[Category("Cannon"), Description("The speed at which the balls from this cannon fire.")]
		public float BallSpeed { get; set; }

		[Category("Cannon"), Description("The stupidity of the Cannon's AI.")]
		public float Stupidity { get; set; }
	}
}
