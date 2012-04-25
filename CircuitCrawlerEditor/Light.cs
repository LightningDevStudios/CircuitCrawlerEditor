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
