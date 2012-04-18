using System;
using System.ComponentModel;
using System.Drawing.Design;

using CircuitCrawlerEditor.Entities;

namespace CircuitCrawlerEditor.Triggers
{
	public class CauseEntityDestruction : Cause
	{
		[Category("Entities"), Description("The entity that triggers this cause.")]
		[Editor(typeof(UIEntListEditor), typeof(UITypeEditor))]
		public Entity Entity { get; set; }
	}
}
