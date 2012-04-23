using System;
using System.Drawing;

using OpenTK;

namespace CircuitCrawlerEditor
{
	public static class ExtraMath
	{
		public static Vector4 UnProject(Matrix4 projection, Matrix4 view, Size viewport, Point controlPos)
		{
			Vector4 worldPos;

			worldPos.X = 2.0f * controlPos.X / (float)viewport.Width - 1;
			worldPos.Y = -(2.0f * controlPos.Y / (float)viewport.Height - 1);
			worldPos.Z = 0;
			worldPos.W = 1.0f;

			Matrix4 viewInv = Matrix4.Invert(view);
			Matrix4 projInv = Matrix4.Invert(projection);

			Vector4.Transform(ref worldPos, ref projInv, out worldPos);

			Vector4.Transform(ref worldPos, ref viewInv, out worldPos);

			if (worldPos.W > float.Epsilon || worldPos.W < float.Epsilon)
			{
				worldPos.X /= worldPos.W;
				worldPos.Y /= worldPos.W;
				worldPos.Z /= worldPos.W;
			}

			return worldPos;
		}
	}
}
