using System;

using CircuitCrawlerEditor.Models;

namespace CircuitCrawlerEditor.Entities
{
	public class Button : Entity
	{
		
		public Button(float xPos, float yPos)
			: base(xPos, yPos)
		{
			vertVbo = ButtonUpData.GetVertexBufferID();
			indVbo = ButtonUpData.GetIndexBufferID();
			indCount = ButtonUpData.GetIndexCount();
			tex = Resources.Textures["button.png"];
		}
	}
}
