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
