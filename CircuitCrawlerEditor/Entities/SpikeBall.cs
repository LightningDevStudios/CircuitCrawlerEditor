using System;
using System.ComponentModel;

namespace CircuitCrawlerEditor.Entities
{
	public class SpikeBall : PhysEnt
	{
		public SpikeBall(float size, float xPos, float yPos)
			: base(size, xPos, yPos, 10, 90, 1)
		{
		}

		[Category("SpikeBall")]
		public int MoveToX { get; set; }

		[Category("SpikeBall")]
		public int MoveToY { get; set; }

		[Category("SpikeBall")]
		public bool RotateLeft { get; set; }
	}
}
