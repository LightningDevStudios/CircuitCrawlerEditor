using System;
using System.Collections.Generic;
using System.ComponentModel;
using CircuitCrawlerEditor.Entities;

namespace CircuitCrawlerEditor.Triggers
{
    public class EffectDoor : Effect
    {
		[Category("Entities"), Description("The entity that triggers this cause.")]
		[Editor(typeof(UIEntListEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Door Door { get; set; }
    }
}
