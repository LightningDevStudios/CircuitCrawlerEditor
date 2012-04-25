using System;
using System.ComponentModel;

using CircuitCrawlerEditor.Models;

namespace CircuitCrawlerEditor.Entities
{
    public class Player : Entity
    {
        public Player(float xPos, float yPos)
            : base(xPos, yPos)
        {
			vertVbo = BallData.GetVertexBufferID();
			indVbo = BallData.GetIndexBufferID();
			indCount = BallData.GetIndexCount();
			tex = Resources.Textures["ball.png"];
        }
    }
}
