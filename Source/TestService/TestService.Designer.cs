/**************************************************************************************************
* GPL v.2 License
* ---------------
* Service.Designer.cs
* 
* Copyright © 2006-2020 Phillip H. Blanton / Gort Technology (http://gort.co) All rights reserved.
*
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

namespace GortTestService
{
   partial class ServiceDebuggerTestService
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

      #region Component Designer generated code

      /// <summary> 
      /// Required method for Designer support - do not modify 
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
			this.components = new System.ComponentModel.Container();
			this.timer = new System.Windows.Forms.Timer(this.components);
			// 
			// timer
			// 
			this.timer.Interval = 1000;
			this.timer.Tick += new System.EventHandler(this.Timer_Tick);
			// 
			// ServiceDebuggerTestService
			// 
			this.ServiceName = "KlaatuTestService";
      }

      #endregion

      private System.Windows.Forms.Timer timer;
   }
}
