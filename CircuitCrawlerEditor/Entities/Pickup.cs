using System;
using System.ComponentModel;

namespace CircuitCrawlerEditor.Entities
{
    public abstract class Pickup : PhysEnt
    {
		[Category("Pickup"), Description("The value of this pickup.")]
		public int Value { get; set; }

        public Pickup(float xPos, float yPos, int value)
            : base(20.0f, xPos, yPos, 50.0f, 90.0f, 1.0f)
        {
			this.Value = value;
        }
    }
}
