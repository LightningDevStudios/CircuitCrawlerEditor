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
    public partial class SnapSize : Form
    {
        public float snapSize { get; set; }

        public SnapSize()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            snapSize = (float)numericUpDown1.Value;
            Close();
        }
    }
}
