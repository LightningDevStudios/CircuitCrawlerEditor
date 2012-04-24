using System;
using System.ComponentModel;

namespace CircuitCrawlerEditor.Entities
{
	public class SpikeWall : Entity
	{
		public SpikeWall(float xPos, float yPos)
            : base(xPos, yPos)
        {
			Dir = Direction.LEFT;
        }

		[Category("SpikeWall"), Description("The direction in which the spikewall pushes.")]
		public Direction Dir { get; set; }
	}
}
