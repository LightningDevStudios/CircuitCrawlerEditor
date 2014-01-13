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
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using System.ComponentModel;

namespace CircuitCrawlerEditor.Entities
{
	[DefaultProperty("ID")]
	public abstract class Entity
	{
		public const float DefaultSize = 64.0f;
		protected bool isSolid, circular, willCollide;

		protected float xPos, yPos, angle;
		protected Texture tex;

		private int entID;
		public static int entCount = 0;

		private string id;

		protected int vertVbo, indVbo, indCount;

		private bool isSelected = false;

		[Category("\n"), Description("The type of entity this is.")]
		public String Type { get { return GetType().ToString().Substring(30); } }

		[Category("\n"), Description("A unique ID for each entity")]
		public String ID { get { return id; } set { id = value; } }

		[Category("Basic Properties"), Description("The x position of the entity")]
		public virtual float XPos { get { return xPos; } set { xPos = value; } }

		[Category("Basic Properties"), Description("The y position of the entity")]
		public virtual float YPos { get { return yPos; } set { yPos = value; } }

		[Category("Basic Properties"), Description("The angle of the entity")]
		public virtual float Angle { get { return angle; } set { angle = value; } }

		[Browsable(false)]
		public Texture Tex { get { return tex; } set { tex = value; } }

		[Browsable(false)]
		public bool Selected
		{
			get
			{
				return isSelected;
			}
			set
			{
				isSelected = value;
			}
		}

		public Entity(float xPos, float yPos)
		{
			entID = entCount;
			entCount++;
			this.xPos = xPos;
			this.yPos = yPos;
			this.angle = 0;
		}

		public void Draw()
		{
			if (tex != null)
				GL.BindTexture(TextureTarget.Texture2D, tex.TexturePtr);

			Matrix4 model = Matrix4.CreateRotationZ(angle * (float)Math.PI / 180f) * Matrix4.CreateTranslation(new Vector3(xPos, yPos, 0));

			GL.MultMatrix(ref model);

			GL.BindBuffer(BufferTarget.ArrayBuffer, vertVbo);
			GL.VertexPointer(3, VertexPointerType.Float, 32, 0);
			GL.TexCoordPointer(2, TexCoordPointerType.Float, 32, 12);
			GL.NormalPointer(NormalPointerType.Float, 32, 20);
			GL.BindBuffer(BufferTarget.ArrayBuffer, 0);

			GL.BindBuffer(BufferTarget.ElementArrayBuffer, indVbo);
			GL.DrawElements(BeginMode.Triangles, indCount, DrawElementsType.UnsignedShort, 0);
			GL.BindBuffer(BufferTarget.ElementArrayBuffer, 0);
		}

		public override string ToString()
		{
			if (String.IsNullOrEmpty(ID))
				return this.GetType().Name;

			return ID;
		}
	}
}
