using System;
using System.Collections.Generic;
using System.ComponentModel;
using CircuitCrawlerEditor.Entities;

namespace CircuitCrawlerEditor.Triggers
{
    public class CauseLocation : Cause
    {
		[Editor(typeof(UIEntListEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Player Player { get; set; }

        public float MinimumX { get; set; }
        public float MinimumY { get; set; }
        public float MaximumX { get; set; }
        public float MaximumY { get; set; }
    }
}
