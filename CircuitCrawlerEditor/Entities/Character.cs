using System;
using System.ComponentModel;

namespace CircuitCrawlerEditor.Entities
{
    public abstract class Character : PhysEnt
    {
        private int health;
        private int energy;

        [Category("Character"), Description("The amount of health the character has.")]
        public int Health { get { return health; } set { health = value; } }

        [Category("Character"), Description("The amount of energy the character has.")]
        public int Energy { get { return energy; } set { energy = value; } }

        public Character(float size, float xPos, float yPos, int health) : base(size, xPos, yPos, 25.0f, 0.0f, 1.0f)
        {
            this.health = health;
        }
    }
}
