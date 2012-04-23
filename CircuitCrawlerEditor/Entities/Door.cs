using System;
using System.ComponentModel;

namespace CircuitCrawlerEditor.Entities
{
    public class Door : Entity
    {
        public Door(float xPos, float yPos)
            : base(80, xPos, yPos)
        {
			Dir = Direction.LEFT;
        }

		[Category("Door"), Description("The direction in which the door opens.")]
		public Direction Dir { get; set; }
    }
}
