#region License
/**
 * Copyright (c) 2010-2012 Lightning Development Studios <lightningdevelopmentstudios@gmail.com>
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy of
 * this software and associated documentation files (the "Software"), to deal in
 * the Software without restriction, including without limitation the rights to
 * use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies
 * of the Software, and to permit persons to whom the Software is furnished to do
 * so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 */
#endregion

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

			foreach (Entity ent in Entities)
			{
				GL.PushMatrix();
				ent.Draw();
				GL.PopMatrix();
			}

			foreach (Light l in Lights)
			{
				GL.Disable(EnableCap.Light0 + l.Index);
			}
		}
	}
}
