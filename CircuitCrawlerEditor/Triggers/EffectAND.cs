using System;
using System.ComponentModel;
using System.Drawing.Design;

namespace CircuitCrawlerEditor.Triggers
{
	class EffectAND : Effect
	{
		[Category("Effects"), Description("The first of two effects.")]
		[Editor(typeof(UIEffectListEditor), typeof(UITypeEditor))]
		public Effect Effect1 { get; set; }

		[Category("Effects"), Description("The second of two effects.")]
		[Editor(typeof(UIEffectListEditor), typeof(UITypeEditor))]
		public Effect Effect2 { get; set; }
	}
}
