using System;
using System.Collections.Generic;

using CircuitCrawlerEditor.Entities;
using CircuitCrawlerEditor.Triggers;

using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace CircuitCrawlerEditor
{
	public class Level
	{
		public Level()
		{
			Lights = new List<Light>();
			Entities = new List<Entity>();
			Causes = new List<Cause>();
			Effects = new List<Effect>();
			Triggers = new List<Trigger>();
		}

		public List<Light> Lights { get; set; }
		public Tileset Tileset { get; set; }
		public List<Entity> Entities { get; set; }
		public List<Cause> Causes { get; set; }
		public List<Effect> Effects { get; set; }
		public List<Trigger> Triggers { get; set; }

		public void Update()
		{
			Tileset.Update();
		}

		public void Draw()
		{
			foreach (Light l in Lights)
			{
				GL.Enable(EnableCap.Light0 + l.Index);
				GL.Light(LightName.Light0 + l.Index, LightParameter.Ambient, l.Ambient);
				GL.Light(LightName.Light0 + l.Index, LightParameter.Diffuse, l.Diffuse);
				GL.Light(LightName.Light0 + l.Index, LightParameter.Position, l.Position);
				GL.Light(LightName.Light0 + l.Index, LightParameter.ConstantAttenuation, l.ConstantAttenuation);
				GL.Light(LightName.Light0 + l.Index, LightParameter.LinearAttenuation, l.LinearAttenuation);
				GL.Light(LightName.Light0 + l.Index, LightParameter.QuadraticAttenuation, l.QuadraticAttenuation);
			}

			Tileset.Draw();

			foreach (Light l in Lights)
			{
				GL.Disable(EnableCap.Light0 + l.Index);
			}
		}
	}
}
