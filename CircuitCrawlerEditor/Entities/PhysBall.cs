using System;
using System.ComponentModel;

namespace CircuitCrawlerEditor.Entities
{
    public class PhysBall : HoldObject
    {
        [Category("PhysBall"), Description("The amount of speed lost over time and per bounce")]
        public float Friction { get; set; }

        public PhysBall(float size, float xPos, float yPos)
            : base(size, xPos, yPos)
        {

        }
    }
}
