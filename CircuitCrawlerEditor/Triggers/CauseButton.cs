using System;
using System.Collections.Generic;
using System.ComponentModel;
using CircuitCrawlerEditor.Entities;

namespace CircuitCrawlerEditor.Triggers
{
    public class CauseButton : Cause
    {
		[Category("Entities"), Description("The entity that triggers this cause.")]
		[Editor(typeof(UIEntListEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Button Button { get; set; }
    }
}
