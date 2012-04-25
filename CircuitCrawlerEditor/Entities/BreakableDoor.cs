using System;
using System.ComponentModel;

using CircuitCrawlerEditor.Models;

namespace CircuitCrawlerEditor.Entities
{
	public class BreakableDoor : Entity
	{
		[Category("BreakableDoor"), Description("The number of hits to destroy the door.")]
		public int MaxHits { get; set; }

		public BreakableDoor(float xPos, float yPos)
			: base(xPos, yPos)
		{
            MaxHits = 3;
			vertVbo = DoorData.GetVertexBufferID();
			indVbo = DoorData.GetIndexBufferID();
			indCount = DoorData.GetIndexCount();
			tex = Resources.Textures["door.png"];
		}
	}
}
