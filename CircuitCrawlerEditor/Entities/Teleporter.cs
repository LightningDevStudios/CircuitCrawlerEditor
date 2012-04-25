using System;
using System.ComponentModel;

using CircuitCrawlerEditor.Models;

namespace CircuitCrawlerEditor.Entities
{
	public class Teleporter : Entity
	{
		public Teleporter(float xPos, float yPos)
			: base(xPos, yPos)
		{
			vertVbo = BlockData.GetVertexBufferID();
			indVbo = BlockData.GetIndexBufferID();
			indCount = BlockData.GetIndexCount();
			tex = Resources.Textures["block.png"];
		}
	}
}
