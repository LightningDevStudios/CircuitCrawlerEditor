using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;

using CircuitCrawlerEditor.Entities;
using CircuitCrawlerEditor.Triggers;

namespace CircuitCrawlerEditor
{
	public class UICauseListEditor : UITypeEditor
	{
		public static List<Cause> causeList;

		private IWindowsFormsEditorService service;

		public override object EditValue(System.ComponentModel.ITypeDescriptorContext context, IServiceProvider provider, object value)
		{
			if (provider != null)
			{
				service = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));

				if (service != null)
				{
					ListBox list = new ListBox();
					list.Click += new EventHandler(list_Click);
					foreach (Cause c in causeList)
					{
						list.Items.Add(c);
					}

					service.DropDownControl(list);

					if (list.SelectedItem != null && list.SelectedIndices.Count == 1)
					{
						value = list.SelectedItem;
					}
				}
			}
			return value;
		}

		void list_Click(object sender, EventArgs e)
		{
			if (service != null)
				service.CloseDropDown();
		}

		public override UITypeEditorEditStyle GetEditStyle(System.ComponentModel.ITypeDescriptorContext context)
		{
			return UITypeEditorEditStyle.DropDown;
		}
	}

	public class UIEffectListEditor : UITypeEditor
	{
		public static List<Effect> effectList;

		private IWindowsFormsEditorService service;

		public override object EditValue(System.ComponentModel.ITypeDescriptorContext context, IServiceProvider provider, object value)
		{
			if (provider != null)
			{
				service = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));

				if (service != null)
				{
					ListBox list = new ListBox();
					list.Click += new EventHandler(list_Click);
					foreach (Effect e in effectList)
					{
						list.Items.Add(e);
					}

					service.DropDownControl(list);

					if (list.SelectedItem != null && list.SelectedIndices.Count == 1)
					{
						value = list.SelectedItem;
					}
				}
			}
			return value;
		}

		void list_Click(object sender, EventArgs e)
		{
			if (service != null)
				service.CloseDropDown();
		}

		public override UITypeEditorEditStyle GetEditStyle(System.ComponentModel.ITypeDescriptorContext context)
		{
			return UITypeEditorEditStyle.DropDown;
		}
	}

	public class UIEntListEditor : UITypeEditor
	{
		public static List<Entity> entList;

		private IWindowsFormsEditorService service;

		public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
		{
			if (provider != null)
			{
				service = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));

				if (service != null)
				{
					ListBox list = new ListBox();
					list.Click += new EventHandler(list_Click);
					foreach (Entity ent in entList)
					{
						if (value == null)
							list.Items.Add(ent);
						else if (value != null && ent.GetType().Equals(value.GetType()))
							list.Items.Add(ent);
					}

					service.DropDownControl(list);

					if (list.SelectedItem != null && list.SelectedIndices.Count == 1)
					{
						value = list.SelectedItem;
					}
				}
			}
			return value;
		}

		void list_Click(object sender, EventArgs e)
		{
			if (service != null)
				service.CloseDropDown();
		}

		public override UITypeEditorEditStyle GetEditStyle(System.ComponentModel.ITypeDescriptorContext context)
		{
			return UITypeEditorEditStyle.DropDown;
		}
	}

	public class UITexListEditor : UITypeEditor
	{
		public static List<Texture> texList;

		private IWindowsFormsEditorService service;

		public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
		{
			if (provider != null)
			{
				service = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));

				if (service != null)
				{
					ListBox list = new ListBox();
					list.Click += new EventHandler(list_Click);
					foreach (Texture t in texList)
					{
						list.Items.Add(t);
					}

					service.DropDownControl(list);

					if (list.SelectedItem != null && list.SelectedIndices.Count == 1)
					{
						value = list.SelectedItem;
					}
				}
			}
			return value;
		}

		void list_Click(object sender, EventArgs e)
		{
			if (service != null)
				service.CloseDropDown();
		}

		public override UITypeEditorEditStyle GetEditStyle(System.ComponentModel.ITypeDescriptorContext context)
		{
			return UITypeEditorEditStyle.DropDown;
		}
	}

	public class UIFormEffectListEditor : UITypeEditor
	{
		public static List<Effect> effectList;

		public override UITypeEditorEditStyle GetEditStyle(System.ComponentModel.ITypeDescriptorContext context)
		{
			return UITypeEditorEditStyle.Modal;
		}

		public override object EditValue(System.ComponentModel.ITypeDescriptorContext context, IServiceProvider provider, object value)
		{
			IWindowsFormsEditorService svc = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
			if (svc != null)
			{
				FormEffectListEditor effectEdit = new FormEffectListEditor((List<Effect>)value, effectList);
				svc.ShowDialog(effectEdit);
				value = effectEdit.curList;
			}

			return value;
		}
	}
}
