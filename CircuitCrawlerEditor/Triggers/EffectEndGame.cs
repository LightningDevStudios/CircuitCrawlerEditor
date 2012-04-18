using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace CircuitCrawlerEditor.Triggers
{
    public class EffectEndGame : Effect
    {
        [Category("Values"), Description("Whether or not this effect ends the game as a successful win. (#WINNING)")]
        public bool CharlieSheen { get; set; }
    }
}
