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
