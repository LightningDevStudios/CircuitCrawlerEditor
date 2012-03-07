using System;
using System.ComponentModel;

namespace CircuitCrawlerEditor.Entities
{
    public class Player : Character
    {
        public Player(float size, float xPos, float yPos, int health)
            : base(size, xPos, yPos, health)
        {
        }
    }
}
