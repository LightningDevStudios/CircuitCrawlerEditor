using System;
using System.ComponentModel;

namespace CircuitCrawlerEditor.Triggers
{
	//[TypeConverter(typeof(ExpandableObjectConverter))]
	public abstract class Effect
	{
		[Category("\n"), Description("A unique identifier for this effect.")]
		public string ID { get; set; }

		[Category("\n"), Description("The type of Cause this is.")]
		public string Type { get { return GetType().ToString().Substring(24); } }

		public override string ToString()
		{
			if (String.IsNullOrEmpty(ID))
				return this.GetType().Name;

			return ID;
		}
	}
}
