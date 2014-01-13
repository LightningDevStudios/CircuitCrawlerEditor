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
using System.ComponentModel;

using OpenTK;
using OpenTK.Graphics;
using System.Windows.Forms;
using System.Drawing.Design;
using System.Windows.Forms.Design;

namespace CircuitCrawlerEditor
{
	public class Light
	{
		public int Index { get; set; }

		[Editor(typeof(ColorType), typeof(UITypeEditor))]
		[TypeConverter(typeof(ExpandableObjectConverter))]
        public Color4 Ambient
        {
            get
            {
                return new Color4(AmbientR, AmbientG, AmbientB, AmbientA);
            }
            set
            {
                AmbientR = value.R;
                AmbientG = value.G;
                AmbientB = value.B;
                AmbientA = value.A;
            }
        }
        public float AmbientR { get; set; }
        public float AmbientG { get; set; }
        public float AmbientB { get; set; }
        public float AmbientA { get; set; }

        [TypeConverter(typeof(ExpandableObjectConverter))]
        public Color4 Diffuse
        {
            get
            {
                return new Color4(DiffuseR, DiffuseG, DiffuseB, DiffuseA);
            }
            set
            {
                DiffuseR = value.R;
                DiffuseG = value.G;
                DiffuseB = value.B;
                DiffuseA = value.A;
            }
        }
        public float DiffuseR { get; set; }
        public float DiffuseG { get; set; }
        public float DiffuseB { get; set; }
        public float DiffuseA { get; set; }

        [TypeConverter(typeof(ExpandableObjectConverter))]
        public Vector4 Position
        {
            get
            {
                return new Vector4(PositionX, PositionY, PositionZ, PositionW);
            }
            set
            {
                PositionX = value.X;
                PositionY = value.Y;
                PositionZ = value.Z;
                PositionW = value.W;
            }
        }
        public float PositionX { get; set; }
        public float PositionY { get; set; }
        public float PositionZ { get; set; }
        public float PositionW { get; set; }

		public float ConstantAttenuation { get; set; }
		public float LinearAttenuation { get; set; }
		public float QuadraticAttenuation { get; set; }
	}

	class ColorType : UITypeEditor
	{
		public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
		{
			return UITypeEditorEditStyle.Modal;
		}
		public override object EditValue(ITypeDescriptorContext context, System.IServiceProvider provider, object value)
		{
			IWindowsFormsEditorService IFService = provider.GetService(typeof(IWindowsFormsEditorService)) as IWindowsFormsEditorService;
			Color4? color = value as Color4?;
			if (IFService != null)
			{
				using (ColorDialog form = new ColorDialog())
				{
					form.ShowDialog();
					color = form.Color;
				}
			}
			return color;
		}
	}
}
