using System;
using System.ComponentModel;

namespace CircuitCrawlerEditor.Entities
{
    public class Ball : HoldObject
    {
        [Category("PhysBall"), Description("The amount of speed lost over time and per bounce")]
        public float Friction { get; set; }

        public Ball(float size, float xPos, float yPos)
            : base(size, xPos, yPos)
        {

        }
    }
}
