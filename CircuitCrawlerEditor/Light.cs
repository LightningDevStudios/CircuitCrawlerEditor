using System;

using OpenTK;
using OpenTK.Graphics;

namespace CircuitCrawlerEditor
{
	public class Light
	{
		public int Index { get; set; }
		public Color4 Ambient { get; set; }
		public Color4 Diffuse { get; set; }
		public Vector4 Position { get; set; }
		public float ConstantAttenuation { get; set; }
		public float LinearAttenuation { get; set; }
		public float QuadraticAttenuation { get; set; }
	}
}
