using System;
using System.Collections.Generic;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using System.ComponentModel;

namespace CircuitCrawlerEditor.Entities
{
	[DefaultPropertyAttribute("Basic Properties")]
	public abstract class Entity
	{
		public const float DefaultSize = 64.0f;
		protected bool isSolid, circular, willCollide;

		protected float xPos, yPos, angle, size, halfSize;
		protected Texture tex;

		protected float[] vertices, color, texture;
		protected byte[] indices;

		private int entID;
		public static int entCount = 0;

		private string id;

		//public bool idChanged = false;
		private bool isSelected = false;

		[Browsable(false)]
		public float[] VerticesArray { get { return vertices; } }

		[Browsable(false)]
		public float[] GradientCoordArray { get { return color; } }

		[Browsable(false)]
		public float[] TextureCoordArray { get { return texture; } }

		[Category("\n"), Description("The type of entity this is.")]
		public String Type { get { return GetType().ToString().Substring(24); } }

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

		[Category("Basic Properties"), Description("The size of the entity")]
		public virtual float Size
		{
			get
			{
				return size;
			}

			set
			{
				size = value;
				this.halfSize = size / 2;
				float[] initVertices = {halfSize, halfSize,
									halfSize, -halfSize,
								   -halfSize, halfSize,
								   -halfSize, -halfSize };
				vertices = initVertices;
			}
		}

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

		public Entity(float size, float xPos, float yPos)
		{
			entID = entCount;
			entCount++;
			this.size = size;
			this.halfSize = size / 2;
			this.xPos = xPos;
			this.yPos = yPos;

			this.angle = 0;

			float[] initVertices = {halfSize, halfSize,
									halfSize, -halfSize,
								   -halfSize, halfSize,
								   -halfSize, -halfSize };
			vertices = initVertices;

			byte[] initIndices = { 0, 1, 2, 3 };
			indices = initIndices;
		}

		public void Draw()
		{
			GL.BindTexture(TextureTarget.Texture2D, tex.TexturePtr);

			//Draw the entity
			GL.VertexPointer<float>(2, VertexPointerType.Float, 0, vertices);
			GL.TexCoordPointer<float>(2, TexCoordPointerType.Float, 0, texture);
			
			GL.DrawElements(BeginMode.TriangleStrip, indices.Length, DrawElementsType.UnsignedByte, indices);
		}

		public override string ToString()
		{
			if (String.IsNullOrEmpty(ID))
				return this.GetType().Name;

			return ID;
		}
	}
}
