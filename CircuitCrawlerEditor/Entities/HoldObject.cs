using System;

namespace CircuitCrawlerEditor.Entities
{
    public class HoldObject : PhysEnt
    {
        public HoldObject(float size, float xPos, float yPos)
            : base(size, xPos, yPos, 100.0f, 90.0f, 5.0f)
        {
        }
    }
}
