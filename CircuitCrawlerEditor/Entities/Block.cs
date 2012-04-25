using System;
using System.ComponentModel;

namespace CircuitCrawlerEditor.Entities
{
    public class Block : HoldObject
    {
        [Category("Physics"), Description("The amount of speed lost over time and per bounce")]
        public float Friction { get; set; }

        public Block(float xPos, float yPos)
            : base(xPos, yPos)
        {
            Friction = 1;
        }
    }
}
