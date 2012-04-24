using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;

namespace CircuitCrawlerEditor.Triggers
{
	public class Trigger
	{
		[Editor(typeof(UICauseListEditor), typeof(UITypeEditor))]
		[Category("Basic Information"), Description("This trigger's cause, has to be a subclass of Cause")]
		public Cause Cause { get; set; }

		[Editor(typeof(UIEffectListEditor), typeof(UITypeEditor))]
		[Category("Basic Information"), Description("This trigger's effect, has to be a subclass of Effect")]
		public Effect Effect { get; set; }

		public override string ToString()
		{
			return "Trigger: " + Cause + " / " + Effect;
		}
	}
}
