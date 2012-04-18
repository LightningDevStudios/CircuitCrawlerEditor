using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;

namespace CircuitCrawlerEditor.Triggers
{
	public class EffectList : Effect
	{
		[Category("Effects"), Description("The effects that triggers this cause.")]
		[Editor(typeof(UIFormEffectListEditor), typeof(UITypeEditor))]
		public List<Effect> List { get; set; }

		public EffectList() : base()
		{
			List = new List<Effect>();
		}
	}
}
