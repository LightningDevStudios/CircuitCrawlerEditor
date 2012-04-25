using System;
using System.ComponentModel;

using CircuitCrawlerEditor.Models;

namespace CircuitCrawlerEditor.Entities
{
	public class Block : HoldObject
	{
		[Category("Physics"), Description("The amount of speed lost over time and per bounce")]
		public float Friction { get; set; }

		public Block(float xPos, float yPos)
			: base(xPos, yPos)
		{
			vertVbo = BlockData.GetVertexBufferID();
			indVbo = BlockData.GetIndexBufferID();
			indCount = BlockData.GetIndexCount();
			tex = Resources.Textures["block.png"];
		}
	}
}
