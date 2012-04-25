using System;
using System.ComponentModel;

using CircuitCrawlerEditor.Models;

namespace CircuitCrawlerEditor.Entities
{
    class PuzzleBox : Entity
    {
        public PuzzleBox(float xPos, float yPos)
            : base(xPos, yPos)
        {
			vertVbo = BlockData.GetVertexBufferID();
			indVbo = BlockData.GetIndexBufferID();
			indCount = BlockData.GetIndexCount();
			tex = Resources.Textures["block.png"];
        }
    }
}
