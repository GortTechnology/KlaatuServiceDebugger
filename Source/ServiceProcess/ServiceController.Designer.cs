/**************************************************************************************************
* GPL v.2 License
* ---------------
* ServiceController.Designer.cs
* 
* Copyright © 2006-2020 Phillip H. Blanton / Gort Technology (http://gort.co) All rights reserved.
*
* Copyright (C) ${Year} [name of author]
* This program is free software; you can redistribute it and/or modify it under the terms of the 
* GNU General Public License as published by the Free Software Foundation; either version 2 of 
* the License, or (at your option) any later version.
*
* This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; 
* without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See 
* the GNU General Public License for more details. You should have received a copy of the GNU 
* General Public License along with this program; if not, write to the Free Software Foundation, 
* Inc., 59 Temple Place, Suite 330, Boston, MA 02111-1307 USA
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
         
         btnExit = new System.Windows.Forms.Button();
         lvServices = new System.Windows.Forms.ListView();
         chName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         chStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         toolStrip1 = new System.Windows.Forms.ToolStrip();
         btnPlayPause = new System.Windows.Forms.ToolStripButton();
         btnStop = new System.Windows.Forms.ToolStripButton();
         btnRestart = new System.Windows.Forms.ToolStripButton();
         label1 = new System.Windows.Forms.Label();
         toolStrip1.SuspendLayout();
         SuspendLayout();
         // 
         // btnExit
         // 
         btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         btnExit.Location = new System.Drawing.Point(333, 220);
         btnExit.Name = "btnExit";
         btnExit.Size = new System.Drawing.Size(75, 23);
         btnExit.TabIndex = 2;
         btnExit.Text = "Exit";
         btnExit.UseVisualStyleBackColor = true;
         btnExit.Click += new System.EventHandler(BtnExit_Click);
         // 
         // lvServices
         // 
         lvServices.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
         | System.Windows.Forms.AnchorStyles.Left)
         | System.Windows.Forms.AnchorStyles.Right)));
         lvServices.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {chName, chStatus});
         lvServices.Location = new System.Drawing.Point(12, 41);
         lvServices.MultiSelect = false;
         lvServices.Name = "lvServices";
         lvServices.Size = new System.Drawing.Size(396, 173);
         lvServices.TabIndex = 3;
         lvServices.UseCompatibleStateImageBehavior = false;
         lvServices.View = System.Windows.Forms.View.Details;
         lvServices.SelectedIndexChanged += new System.EventHandler(LvServices_SelectedIndexChanged);
         // 
         // chName
         // 
         chName.Text = "Name";
         chName.Width = 282;
         // 
         // chStatus
         // 
         chStatus.Text = "Status";
         chStatus.Width = 90;
         // 
         // toolStrip1
         // 
         toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
         toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {btnPlayPause, btnStop, btnRestart});
         toolStrip1.Location = new System.Drawing.Point(0, 0);
         toolStrip1.Name = "toolStrip1";
         toolStrip1.Size = new System.Drawing.Size(420, 39);
         toolStrip1.TabIndex = 4;
         toolStrip1.Text = "toolStrip1";
         // 
         // btnPlayPause
         // 
         btnPlayPause.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         btnPlayPause.Enabled = false;
         btnPlayPause.Image = global::GortServiceDebugger.Resources.BtnPause;
         btnPlayPause.ImageTransparentColor = System.Drawing.Color.Magenta;
         btnPlayPause.Name = "btnPlayPause";
         btnPlayPause.Size = new System.Drawing.Size(36, 36);
         btnPlayPause.Text = "Pause";
         btnPlayPause.Click += new System.EventHandler(BtnPlayPause_Click);
         // 
         // btnStop
         // 
         btnStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         btnStop.Enabled = false;
         btnStop.Image = global::GortServiceDebugger.Resources.BtnStop;
         btnStop.ImageTransparentColor = System.Drawing.Color.Magenta;
         btnStop.Name = "btnStop";
         btnStop.Size = new System.Drawing.Size(36, 36);
         btnStop.Text = "Stop";
         btnStop.Click += new System.EventHandler(BtnStop_Click);
         // 
         // btnRestart
         // 
         btnRestart.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         btnRestart.Enabled = false;
         btnRestart.Image = global::GortServiceDebugger.Resources.BtnRestart;
         btnRestart.ImageTransparentColor = System.Drawing.Color.Black;
         btnRestart.Name = "btnRestart";
         btnRestart.Size = new System.Drawing.Size(36, 36);
         btnRestart.Text = "Restart";
         btnRestart.Click += new System.EventHandler(BtnRestart_Click);
         // 
         // label1
         // 
         label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
         label1.AutoSize = true;
         label1.Location = new System.Drawing.Point(9, 228);
         label1.Name = "label1";
         label1.Size = new System.Drawing.Size(119, 13);
         label1.TabIndex = 5;
         label1.Text = "Akanomi Softworks Inc.";
         // 
         // ServicesController
         // 
         AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         ClientSize = new System.Drawing.Size(420, 253);
         Controls.Add(label1);
         Controls.Add(toolStrip1);
         Controls.Add(lvServices);
         Controls.Add(btnExit);
         Name = "ServicesController";
         Text = "Service Debugger";
         Load += new System.EventHandler(ServicesController_Load);
         toolStrip1.ResumeLayout(false);
         toolStrip1.PerformLayout();
         ResumeLayout(false);
         PerformLayout();

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