﻿using System;
using System.ComponentModel;

namespace CircuitCrawlerEditor.Entities
{
	class Cannon : Entity
	{
		public Cannon(float size, float xPos, float yPos)
			: base(size, xPos, yPos)
		{
		}

		[Category("Cannon"), Description("The speed at which the balls from this cannon fire.")]
		public int BallSpeed { get; set; }

		[Category("Cannon"), Description("The interval at which balls fire from this cannon.")]
		public int FireRate { get; set; }
	}
}
