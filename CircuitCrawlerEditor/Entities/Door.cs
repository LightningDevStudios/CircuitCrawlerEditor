using System;
using System.ComponentModel;

using CircuitCrawlerEditor.Models;

namespace CircuitCrawlerEditor.Entities
{
	public class Door : Entity
	{
		public Door(float xPos, float yPos)
			: base(xPos, yPos)
		{
			Dir = Direction.LEFT;

			vertVbo = DoorData.GetVertexBufferID();
			indVbo = DoorData.GetIndexBufferID();
			indCount = DoorData.GetIndexCount();
			tex = Resources.Textures["door.png"];
		}

		[Category("Door"), Description("The direction in which the door opens.")]
		public Direction Dir { get; set; }
	}
}
