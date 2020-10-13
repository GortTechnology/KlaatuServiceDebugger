/**************************************************************************************************
MIT License

Copyright ©2020 Phillip H. Blanton (http://www.Gort.co) All rights reserved.

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and 
associated documentation files (the "Software"), to deal in the Software without restriction, 
including without limitation the rights to use, copy, modify, merge, publish, distribute, 
sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is 
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or 
substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING 
BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND 
NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, 
DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, 
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
**************************************************************************************************/
namespace GortServiceDebugger
{
    partial class ServicesController
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServicesController));
			this.btnExit = new System.Windows.Forms.Button();
			this.lvServices = new System.Windows.Forms.ListView();
			this.chName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.chStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.btnPlayPause = new System.Windows.Forms.ToolStripButton();
			this.btnStop = new System.Windows.Forms.ToolStripButton();
			this.btnRestart = new System.Windows.Forms.ToolStripButton();
			this.label1 = new System.Windows.Forms.Label();
			this.toolStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnExit
			// 
			this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnExit.Location = new System.Drawing.Point(333, 220);
			this.btnExit.Name = "btnExit";
			this.btnExit.Size = new System.Drawing.Size(75, 23);
			this.btnExit.TabIndex = 2;
			this.btnExit.Text = "Exit";
			this.btnExit.UseVisualStyleBackColor = true;
			this.btnExit.Click += new System.EventHandler(this.BtnExit_Click);
			// 
			// lvServices
			// 
			this.lvServices.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lvServices.BackgroundImage = global::GortServiceDebugger.ImageResource.smallwatermark;
			this.lvServices.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chName,
            this.chStatus});
			this.lvServices.HideSelection = false;
			this.lvServices.Location = new System.Drawing.Point(12, 41);
			this.lvServices.MultiSelect = false;
			this.lvServices.Name = "lvServices";
			this.lvServices.Scrollable = false;
			this.lvServices.Size = new System.Drawing.Size(396, 173);
			this.lvServices.TabIndex = 3;
			this.lvServices.UseCompatibleStateImageBehavior = false;
			this.lvServices.View = System.Windows.Forms.View.Details;
			this.lvServices.SelectedIndexChanged += new System.EventHandler(this.LvServices_SelectedIndexChanged);
			// 
			// chName
			// 
			this.chName.Text = "Name";
			this.chName.Width = 302;
			// 
			// chStatus
			// 
			this.chStatus.Text = "Status";
			this.chStatus.Width = 90;
			// 
			// toolStrip1
			// 
			this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnPlayPause,
            this.btnStop,
            this.btnRestart});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(420, 38);
			this.toolStrip1.TabIndex = 4;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// btnPlayPause
			// 
			this.btnPlayPause.AutoSize = false;
			this.btnPlayPause.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnPlayPause.Enabled = false;
			this.btnPlayPause.Image = global::GortServiceDebugger.ImageResource.Play;
			this.btnPlayPause.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnPlayPause.Name = "btnPlayPause";
			this.btnPlayPause.Size = new System.Drawing.Size(35, 35);
			this.btnPlayPause.Text = "Pause";
			this.btnPlayPause.Click += new System.EventHandler(this.BtnPlayPause_Click);
			// 
			// btnStop
			// 
			this.btnStop.AutoSize = false;
			this.btnStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnStop.Enabled = false;
			this.btnStop.Image = global::GortServiceDebugger.ImageResource.Stop;
			this.btnStop.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnStop.Name = "btnStop";
			this.btnStop.Size = new System.Drawing.Size(35, 35);
			this.btnStop.Text = "Stop";
			this.btnStop.Click += new System.EventHandler(this.BtnStop_Click);
			// 
			// btnRestart
			// 
			this.btnRestart.AutoSize = false;
			this.btnRestart.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnRestart.Enabled = false;
			this.btnRestart.Image = global::GortServiceDebugger.ImageResource.Restart;
			this.btnRestart.ImageTransparentColor = System.Drawing.Color.Black;
			this.btnRestart.Name = "btnRestart";
			this.btnRestart.Size = new System.Drawing.Size(35, 35);
			this.btnRestart.Text = "Restart";
			this.btnRestart.Click += new System.EventHandler(this.BtnRestart_Click);
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(9, 228);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(161, 14);
			this.label1.TabIndex = 5;
			this.label1.Text = "Copyright © Gort Technology.";
			// 
			// ServicesController
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(420, 253);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.toolStrip1);
			this.Controls.Add(this.lvServices);
			this.Controls.Add(this.btnExit);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "ServicesController";
			this.Text = "Gort Klaatu Service Debugger";
			this.Load += new System.EventHandler(this.ServicesController_Load);
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.ListView lvServices;
        private System.Windows.Forms.ColumnHeader chName;
        private System.Windows.Forms.ColumnHeader chStatus;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnPlayPause;
        private System.Windows.Forms.ToolStripButton btnStop;
        private System.Windows.Forms.ToolStripButton btnRestart;
        private System.Windows.Forms.Label label1;
    }
}