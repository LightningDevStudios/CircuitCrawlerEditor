using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;

namespace CircuitCrawlerEditor.Triggers
{
    public class CauseNOT : Cause
    {
		[Category("Causes"), Description("The cause that triggers this cause.")]
		[Editor(typeof(UICauseListEditor), typeof(UITypeEditor))]
        public Cause Cause { get; set; }
    }
}
