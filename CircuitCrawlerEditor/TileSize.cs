using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CircuitCrawlerEditor
{
	public partial class TileSize : Form
	{
		public int X { get; set; }
		public int Y { get; set; }

		public TileSize()
		{
			InitializeComponent();

			label3.Text = "X: 4";
			label4.Text = "Y: 4";

			X = 4;
			Y = 4;
		}

		private void trackBar1_ValueChanged(object sender, EventArgs e)
		{
			X = trackBar1.Value;
			label3.Text = "X: " + X;
		}

		private void trackBar2_ValueChanged(object sender, EventArgs e)
		{
			Y = trackBar2.Value;
			label4.Text = "Y: " + Y;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}
