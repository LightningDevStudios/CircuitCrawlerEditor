namespace CircuitCrawlerEditor
{
	public partial class FormEffectListEditor : System.Windows.Forms.Form
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.OKButton = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.btnToList = new System.Windows.Forms.Button();
			this.btnToAll = new System.Windows.Forms.Button();
			this.listAll = new System.Windows.Forms.ListBox();
			this.listCurrent = new System.Windows.Forms.ListBox();
			this.SuspendLayout();
			// 
			// OKButton
			// 
			this.OKButton.Location = new System.Drawing.Point(330, 256);
			this.OKButton.Name = "OKButton";
			this.OKButton.Size = new System.Drawing.Size(75, 23);
			this.OKButton.TabIndex = 13;
			this.OKButton.Text = "OK";
			this.OKButton.UseVisualStyleBackColor = true;
			this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(236, 9);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(54, 13);
			this.label2.TabIndex = 12;
			this.label2.Text = "All Effects";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(51, 13);
			this.label1.TabIndex = 11;
			this.label1.Text = "EffectList";
			// 
			// btnToList
			// 
			this.btnToList.Location = new System.Drawing.Point(187, 131);
			this.btnToList.Name = "btnToList";
			this.btnToList.Size = new System.Drawing.Size(46, 46);
			this.btnToList.TabIndex = 10;
			this.btnToList.Text = "<--";
			this.btnToList.UseVisualStyleBackColor = true;
			this.btnToList.Click += new System.EventHandler(this.btnToList_Click);
			// 
			// btnToAll
			// 
			this.btnToAll.Location = new System.Drawing.Point(187, 79);
			this.btnToAll.Name = "btnToAll";
			this.btnToAll.Size = new System.Drawing.Size(46, 46);
			this.btnToAll.TabIndex = 9;
			this.btnToAll.Text = "-->";
			this.btnToAll.UseVisualStyleBackColor = true;
			this.btnToAll.Click += new System.EventHandler(this.btnToAll_Click);
			// 
			// listAll
			// 
			this.listAll.FormattingEnabled = true;
			this.listAll.Location = new System.Drawing.Point(239, 25);
			this.listAll.Name = "listAll";
			this.listAll.Size = new System.Drawing.Size(166, 225);
			this.listAll.TabIndex = 8;
			// 
			// listCurrent
			// 
			this.listCurrent.FormattingEnabled = true;
			this.listCurrent.Location = new System.Drawing.Point(15, 25);
			this.listCurrent.Name = "listCurrent";
			this.listCurrent.Size = new System.Drawing.Size(166, 225);
			this.listCurrent.TabIndex = 7;
			// 
			// FormEffectListEditor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(417, 291);
			this.Controls.Add(this.OKButton);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnToList);
			this.Controls.Add(this.btnToAll);
			this.Controls.Add(this.listAll);
			this.Controls.Add(this.listCurrent);
			this.Name = "FormEffectListEditor";
			this.Text = "FormEffectListEditor";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button OKButton;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnToList;
		private System.Windows.Forms.Button btnToAll;
		private System.Windows.Forms.ListBox listAll;
		private System.Windows.Forms.ListBox listCurrent;
	}
}