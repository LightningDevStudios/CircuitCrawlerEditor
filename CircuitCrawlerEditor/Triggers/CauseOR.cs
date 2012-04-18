using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;

namespace CircuitCrawlerEditor.Triggers
{
    public class CauseOR : Cause
    {
		[Category("Causes"), Description("The first of two causes.")]
		[Editor(typeof(UICauseListEditor), typeof(UITypeEditor))]
        public Cause Cause1 { get; set; }

		[Category("Causes"), Description("The second of two causes.")]
		[Editor(typeof(UICauseListEditor), typeof(UITypeEditor))]
        public Cause Cause2 { get; set; }
    }
}
