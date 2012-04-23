using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CircuitCrawlerEditor.Entities
{
	public class BreakableDoor : Entity
	{
		private int maxHits;

		public BreakableDoor(float xPos, float yPos, int maxHits)
			: base(80, xPos, yPos)
		{
			this.maxHits = maxHits;
		}
	}
}
