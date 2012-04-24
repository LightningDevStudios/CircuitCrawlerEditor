using System;
using System.ComponentModel;

namespace CircuitCrawlerEditor.Entities
{
	class Cannon : Entity
	{
		public Cannon(float xPos, float yPos)
			: base(xPos, yPos)
		{
		}

		[Category("Cannon"), Description("The speed at which the balls from this cannon fire.")]
		public float BallSpeed { get; set; }

		[Category("Cannon"), Description("The stupidity of the Cannon's AI.")]
		public float Stupidity { get; set; }
	}
}
