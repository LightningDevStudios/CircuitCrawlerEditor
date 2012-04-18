using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CircuitCrawlerEditor.Triggers;

namespace CircuitCrawlerEditor
{
	public partial class FormEffectListEditor : Form
	{
		public List<Effect> curList;

		public FormEffectListEditor(List<Effect> curList, List<Effect> effectList)
		{
			InitializeComponent();

			List<Effect> tempEffectList = new List<Effect>(effectList.ToArray());
			if (curList != null)
			{
				listCurrent.Items.AddRange(curList.ToArray());

				foreach (Effect e in curList)
					tempEffectList.Remove(e);
			}

			listAll.Items.AddRange(tempEffectList.ToArray());
		}

		private void btnToAll_Click(object sender, EventArgs e)
		{
			if (listCurrent.SelectedItems != null)
			{
				listAll.Items.Add(listCurrent.SelectedItem);
				listCurrent.Items.Remove(listCurrent.SelectedItem);
			}
		}

		private void btnToList_Click(object sender, EventArgs e)
		{
			if (listAll.SelectedItems != null)
			{
				listCurrent.Items.Add(listAll.SelectedItem);
				listAll.Items.Remove(listAll.SelectedItem);
			}
		}

		private void OKButton_Click(object sender, EventArgs e)
		{
			curList = new List<Effect>();
			foreach (object o in listCurrent.Items)
			{
				curList.Add((Effect)o);
			}

			this.Close();
			return;
		}
	}
}
