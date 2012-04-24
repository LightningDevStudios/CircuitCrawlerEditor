using System;
using System.ComponentModel;

using OpenTK;
using OpenTK.Graphics;

namespace CircuitCrawlerEditor
{
	public class Light
	{
		public int Index { get; set; }

		[TypeConverter(typeof(ExpandableObjectConverter))]
		public Color4 Ambient { get; set; }

		[TypeConverter(typeof(ExpandableObjectConverter))]
		public Color4 Diffuse { get; set; }

		[TypeConverter(typeof(ExpandableObjectConverter))]
		public Vector4 Position { get; set; }
		public float ConstantAttenuation { get; set; }
		public float LinearAttenuation { get; set; }
		public float QuadraticAttenuation { get; set; }
	}
}
