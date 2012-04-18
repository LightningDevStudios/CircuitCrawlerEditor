using System;
using System.ComponentModel;

namespace CircuitCrawlerEditor.Entities
{
    public class Block : HoldObject
    {

        [Category("PhysBlock"), Description("The amount of speed lost over time and per bounce")]
        public float Friction { get; set; }

        public Block(float size, float xPos, float yPos)
            : base(size, xPos, yPos)
        {
        }
    }
}
