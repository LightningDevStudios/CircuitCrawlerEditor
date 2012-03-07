using System;
using System.ComponentModel;

namespace CircuitCrawlerEditor.Entities
{
    public abstract class PhysEnt  : Entity
    {
        protected float moveSpeed, rotSpeed, sclSpeed;

        [Category("Physics"), Description("The speed at which the entity will move, in pixels per second (roughly).")]
        public float MoveSpeed { get { return moveSpeed; } set { moveSpeed = value; } }

        [Category("Physics"), Description("The speed at which the entity will rotate, in degrees per second (roughly).")]
        public float RotateSpeed { get { return rotSpeed; } set { rotSpeed = value; } }

        [Category("Physics"), Description("The speed at which the entity will scale.")]
        public float ScaleSpeed { get { return sclSpeed; } set { sclSpeed = value; } }

        public PhysEnt(float size, float xPos, float yPos, float moveSpeed, float rotSpeed, float sclSpeed) : base(size, xPos, yPos)
        {
            this.moveSpeed = moveSpeed;
            this.rotSpeed = rotSpeed;
            this.sclSpeed = sclSpeed;
        }
    }
}
