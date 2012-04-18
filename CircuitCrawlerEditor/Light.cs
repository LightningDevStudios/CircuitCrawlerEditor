using System;

using OpenTK;

namespace CircuitCrawlerEditor
{
	public class Light
	{
		public Vector4 Ambient { get; set; }
		public Vector4 Diffuse { get; set; }
		public Vector4 Position { get; set; }
		public float ConstantAttenuation { get; set; }
		public float LinearAttenuation { get; set; }
		public float QuadraticAttenuation { get; set; }
	}
}
