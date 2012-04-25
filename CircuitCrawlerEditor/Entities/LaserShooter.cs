using System;
using System.ComponentModel;

using CircuitCrawlerEditor.Models;

namespace CircuitCrawlerEditor.Entities
{
	public class LaserShooter : Entity
	{
		public LaserShooter(float xPos, float yPos)
			: base(xPos, yPos)
		{
            ShotsPerSecond = 1;
            BeamWidth = 5;
            Stupidity = 0;
		}

		[Category("LaserShooter"), Description("The number of times the laser fires per second.")]
		public float ShotsPerSecond { get; set; }

		[Category("LaserShooter"), Description("The width of the laser beam.")]
		public float BeamWidth { get; set; }

		[Category("LaserShooter"), Description("The stupidity of the LaserShooter's AI.")]
		public float Stupidity { get; set; }
	}
}
