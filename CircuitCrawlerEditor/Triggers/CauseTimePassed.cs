using System;
using System.ComponentModel;

namespace CircuitCrawlerEditor.Triggers
{
    public class CauseTimePassed : Cause
    {
		[Category("Values"), Description("The amount of time to pass before the cause is triggered.")]
        public int TriggerTime { get; set; }
    }
}
