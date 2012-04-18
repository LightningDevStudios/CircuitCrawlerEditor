using System;
using System.Collections.Generic;
using System.ComponentModel;
using CircuitCrawlerEditor.Entities;

namespace CircuitCrawlerEditor.Triggers
{
    public class EffectRemoveEntity : Effect
    {
		[Category("Entities"), Description("The entity that will be removed.")]
		[Editor(typeof(UIEntListEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Entity Entity { get; set; }
    }
}
