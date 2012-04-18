using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;

namespace CircuitCrawlerEditor.Triggers
{
    public class EffectTriggerTimer : Effect
    {
		[Category("Causes"), Description("The CauseTimePassed that will be started.")]
		[Editor(typeof(UICauseListEditor), typeof(UITypeEditor))]
        public CauseTimePassed Cause { get; set; }
    }
}
