using System;
using System.Drawing;

using OpenTK;

namespace CircuitCrawlerEditor
{
	public static class ExtraMath
	{
		public static Vector4 Unproject(Matrix4 projection, Matrix4 view, Size viewport, Point controlPos)
		{
			Vector4 worldPos = new Vector4();

			//controlPos.X -= viewport.Width / 2;
			//controlPos.Y -= viewport.Height / 2;

			worldPos.X = (float)controlPos.X / (float)viewport.Width * 2f - 1f;
			worldPos.Y = -((float)controlPos.Y / (float)viewport.Height * 2f - 1f);
			//worldPos.Z = ((1f + (1.5f + 0.01f) / (1.5f - 0.01f)) * (1.5f - 0.01f)) / -2;
			worldPos.Z = (float)Math.Sqrt(1f + worldPos.Xy.Length);
			//worldPos.Z = 0.01f;
			worldPos.W = 1.0f;

			Matrix4 viewInv = Matrix4.Invert(view);
			Matrix4 projInv = Matrix4.Invert(projection);

			Vector4.Transform(ref worldPos, ref projInv, out worldPos);
			Vector4.Transform(ref worldPos, ref viewInv, out worldPos);

			//no dividing through by W, return a Vector4 instead.
			if (worldPos.W > float.Epsilon || worldPos.W < -float.Epsilon)
			{
				worldPos.X /= worldPos.W;
				worldPos.Y /= worldPos.W;
				worldPos.Z /= worldPos.W;
			}

			//worldPos.X *= 72f;
			//worldPos.Y *= 72f;
			worldPos.W = 1;


			return worldPos;
		}
	}
}
