using System;
using System.ComponentModel;

using CircuitCrawlerEditor.Models;

namespace CircuitCrawlerEditor.Entities
{
	public class SpikeWall : Entity
	{
		public SpikeWall(float xPos, float yPos)
			: base(xPos, yPos)
		{
			Dir = Direction.LEFT;

			vertVbo = SpikeWallData.GetVertexBufferID();
			indVbo = SpikeWallData.GetIndexBufferID();
			indCount = SpikeWallData.GetIndexCount();
			tex = Resources.Textures["spikewall.png"];
		}

		[Category("SpikeWall"), Description("The direction in which the spikewall pushes.")]
		public Direction Dir { get; set; }
	}
}
