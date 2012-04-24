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

		protected float xPos, yPos, angle;
		protected Texture tex;

		private int entID;
		public static int entCount = 0;

		private string id;

		//public bool idChanged = false;
		private bool isSelected = false;

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
			//TODO: 3D and shit
		}

		public override string ToString()
		{
			if (String.IsNullOrEmpty(ID))
				return this.GetType().Name;

			return ID;
		}
	}
}
