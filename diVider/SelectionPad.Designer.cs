  /*
 * Created by SharpDevelop.
 * User: AdamS-0
 * Date: 12.03.2022
 * Time: 14:15
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace diVider
{
	partial class SelectionPad
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
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
		    this.SuspendLayout();
		    // 
		    // SelectionPad
		    // 
		    this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
		    this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		    this.BackColor = System.Drawing.Color.Gray;
		    this.ClientSize = new System.Drawing.Size(100, 100);
		    this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		    this.Name = "SelectionPad";
		    this.Opacity = 0.3D;
		    this.ShowIcon = false;
		    this.ShowInTaskbar = false;
		    this.Text = "SelectionPad";
		    this.TopMost = true;
		    this.ResumeLayout(false);

		}
	}
}
