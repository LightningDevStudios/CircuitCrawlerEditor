using System;
using System.ComponentModel;

namespace CircuitCrawlerEditor.Entities
{
    public class Ball : HoldObject
    {
        [Category("Physics"), Description("The amount of speed lost over time and per bounce")]
        public float Friction { get; set; }

        public Ball(float xPos, float yPos)
            : base(xPos, yPos)
        {

        }
    }
}
