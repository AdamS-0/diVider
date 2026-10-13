 /*
 * Created by SharpDevelop.
 * User: AdamS-0
 * Date: 11.03.2022
 * Time: 19:50
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace diVider
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.NotifyIcon notifyIcon1;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem tlStrpMnItActive;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem restartToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem tlStrpMnItClose;
		private System.Windows.Forms.ToolStripTextBox rowsTlStrpTxtBx;
		private System.Windows.Forms.ToolStripTextBox colsTlStrpTxtBx;
		private System.Windows.Forms.ToolStripMenuItem updateTlStrpMnItm;
		private System.Windows.Forms.ToolStripTextBox opacityTlStrpTxtBx;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripTextBox padWidthTlStrpTxtBx;
		private System.Windows.Forms.ToolStripTextBox padHeightTlStrpTxtBx;
		private System.Windows.Forms.ToolStripMenuItem UpdatePadSizeTlStrpMnItm;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
		    this.components = new System.ComponentModel.Container();
		    this.timer1 = new System.Windows.Forms.Timer(this.components);
		    this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
		    this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
		    this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		    this.rowsTlStrpTxtBx = new System.Windows.Forms.ToolStripTextBox();
		    this.colsTlStrpTxtBx = new System.Windows.Forms.ToolStripTextBox();
		    this.updateTlStrpMnItm = new System.Windows.Forms.ToolStripMenuItem();
		    this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
		    this.opacityTlStrpTxtBx = new System.Windows.Forms.ToolStripTextBox();
		    this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
		    this.padWidthTlStrpTxtBx = new System.Windows.Forms.ToolStripTextBox();
		    this.padHeightTlStrpTxtBx = new System.Windows.Forms.ToolStripTextBox();
		    this.UpdatePadSizeTlStrpMnItm = new System.Windows.Forms.ToolStripMenuItem();
		    this.tlStrpMnItActive = new System.Windows.Forms.ToolStripMenuItem();
		    this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
		    this.restartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		    this.tlStrpMnItClose = new System.Windows.Forms.ToolStripMenuItem();
		    this.contextMenuStrip1.SuspendLayout();
		    this.SuspendLayout();
		    // 
		    // timer1
		    // 
		    this.timer1.Interval = 10;
		    this.timer1.Tick += new System.EventHandler(this.Timer1Tick);
		    // 
		    // notifyIcon1
		    // 
		    this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
		    this.notifyIcon1.Icon = global::diVider.Resource1.icon1;
		    this.notifyIcon1.Text = "Screen diVider";
		    this.notifyIcon1.Visible = true;
		    // 
		    // contextMenuStrip1
		    // 
		    this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
		    this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem,
            this.tlStrpMnItActive,
            this.toolStripSeparator1,
            this.restartToolStripMenuItem,
            this.tlStrpMnItClose});
		    this.contextMenuStrip1.Name = "contextMenuStrip1";
		    this.contextMenuStrip1.Size = new System.Drawing.Size(117, 98);
		    // 
		    // settingsToolStripMenuItem
		    // 
		    this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rowsTlStrpTxtBx,
            this.colsTlStrpTxtBx,
            this.updateTlStrpMnItm,
            this.toolStripSeparator2,
            this.opacityTlStrpTxtBx,
            this.toolStripSeparator3,
            this.padWidthTlStrpTxtBx,
            this.padHeightTlStrpTxtBx,
            this.UpdatePadSizeTlStrpMnItm});
		    this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
		    this.settingsToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
		    this.settingsToolStripMenuItem.Text = "Settings";
		    // 
		    // rowsTlStrpTxtBx
		    // 
		    this.rowsTlStrpTxtBx.Name = "rowsTlStrpTxtBx";
		    this.rowsTlStrpTxtBx.Size = new System.Drawing.Size(100, 23);
		    this.rowsTlStrpTxtBx.Text = "20";
		    this.rowsTlStrpTxtBx.ToolTipText = "Number of rows";
		    // 
		    // colsTlStrpTxtBx
		    // 
		    this.colsTlStrpTxtBx.Name = "colsTlStrpTxtBx";
		    this.colsTlStrpTxtBx.Size = new System.Drawing.Size(100, 23);
		    this.colsTlStrpTxtBx.Text = "40";
		    this.colsTlStrpTxtBx.ToolTipText = "Number of cols";
		    // 
		    // updateTlStrpMnItm
		    // 
		    this.updateTlStrpMnItm.Name = "updateTlStrpMnItm";
		    this.updateTlStrpMnItm.Size = new System.Drawing.Size(160, 22);
		    this.updateTlStrpMnItm.Text = "Update";
		    this.updateTlStrpMnItm.Click += new System.EventHandler(this.UpdateTlStrpMnItmClick);
		    // 
		    // toolStripSeparator2
		    // 
		    this.toolStripSeparator2.Name = "toolStripSeparator2";
		    this.toolStripSeparator2.Size = new System.Drawing.Size(157, 6);
		    // 
		    // opacityTlStrpTxtBx
		    // 
		    this.opacityTlStrpTxtBx.Name = "opacityTlStrpTxtBx";
		    this.opacityTlStrpTxtBx.Size = new System.Drawing.Size(100, 23);
		    this.opacityTlStrpTxtBx.Text = "30%";
		    this.opacityTlStrpTxtBx.ToolTipText = "Opacity";
		    this.opacityTlStrpTxtBx.TextChanged += new System.EventHandler(this.OpacityTlStrpTxtBxTextChanged);
		    // 
		    // toolStripSeparator3
		    // 
		    this.toolStripSeparator3.Name = "toolStripSeparator3";
		    this.toolStripSeparator3.Size = new System.Drawing.Size(157, 6);
		    // 
		    // padWidthTlStrpTxtBx
		    // 
		    this.padWidthTlStrpTxtBx.Name = "padWidthTlStrpTxtBx";
		    this.padWidthTlStrpTxtBx.Size = new System.Drawing.Size(100, 23);
		    this.padWidthTlStrpTxtBx.Text = "27";
		    this.padWidthTlStrpTxtBx.ToolTipText = "Pad width";
		    // 
		    // padHeightTlStrpTxtBx
		    // 
		    this.padHeightTlStrpTxtBx.Name = "padHeightTlStrpTxtBx";
		    this.padHeightTlStrpTxtBx.Size = new System.Drawing.Size(100, 23);
		    this.padHeightTlStrpTxtBx.Text = "29";
		    this.padHeightTlStrpTxtBx.ToolTipText = "Pad height";
		    // 
		    // UpdatePadSizeTlStrpMnItm
		    // 
		    this.UpdatePadSizeTlStrpMnItm.Name = "UpdatePadSizeTlStrpMnItm";
		    this.UpdatePadSizeTlStrpMnItm.Size = new System.Drawing.Size(160, 22);
		    this.UpdatePadSizeTlStrpMnItm.Text = "Update pad size";
		    this.UpdatePadSizeTlStrpMnItm.Click += new System.EventHandler(this.UpdatePadSizeTlStrpMnItmClick);
		    // 
		    // tlStrpMnItActive
		    // 
		    this.tlStrpMnItActive.Checked = true;
		    this.tlStrpMnItActive.CheckOnClick = true;
		    this.tlStrpMnItActive.CheckState = System.Windows.Forms.CheckState.Checked;
		    this.tlStrpMnItActive.Name = "tlStrpMnItActive";
		    this.tlStrpMnItActive.Size = new System.Drawing.Size(116, 22);
		    this.tlStrpMnItActive.Text = "Active";
		    // 
		    // toolStripSeparator1
		    // 
		    this.toolStripSeparator1.Name = "toolStripSeparator1";
		    this.toolStripSeparator1.Size = new System.Drawing.Size(113, 6);
		    // 
		    // restartToolStripMenuItem
		    // 
		    this.restartToolStripMenuItem.Name = "restartToolStripMenuItem";
		    this.restartToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
		    this.restartToolStripMenuItem.Text = "Restart";
		    // 
		    // tlStrpMnItClose
		    // 
		    this.tlStrpMnItClose.Name = "tlStrpMnItClose";
		    this.tlStrpMnItClose.Size = new System.Drawing.Size(116, 22);
		    this.tlStrpMnItClose.Text = "Close";
		    this.tlStrpMnItClose.Click += new System.EventHandler(this.TlStrpMnItCloseClick);
		    // 
		    // MainForm
		    // 
		    this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
		    this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		    this.BackColor = System.Drawing.Color.Maroon;
		    this.ClientSize = new System.Drawing.Size(100, 100);
		    this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		    this.Icon = global::diVider.Resource1.icon1;
		    this.Name = "MainForm";
		    this.Opacity = 0.3D;
		    this.ShowIcon = false;
		    this.ShowInTaskbar = false;
		    this.Text = "diVider";
		    this.TopMost = true;
		    this.TransparencyKey = System.Drawing.Color.Maroon;
		    this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFormFormClosing);
		    this.Load += new System.EventHandler(this.MainFormLoad);
		    this.Paint += new System.Windows.Forms.PaintEventHandler(this.MainFormPaint);
		    this.contextMenuStrip1.ResumeLayout(false);
		    this.ResumeLayout(false);

		}
	}
}
