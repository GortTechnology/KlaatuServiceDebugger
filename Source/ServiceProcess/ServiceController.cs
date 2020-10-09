/**************************************************************************************************
* GPL v.2 License
* ---------------
* ServiceLoader.cs
* 
* Copyright © 2006-2020 Gort Technology (http://gort.co) All rights reserved.
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

using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GortServiceDebugger
{
  internal partial class ServicesController : Form
  {
    private readonly List<ServiceLoader.ServiceInfo> _serviceInformation = null;
    public ServicesController(List<ServiceLoader.ServiceInfo> serviceInfos)
    {
      _serviceInformation = serviceInfos;
      InitializeComponent();

      RefreshList();
    }

    private void RefreshList()
    {
      for (int i = 0; i < _serviceInformation.Count; i++)
      {
        ListViewItem item = new ListViewItem(_serviceInformation[i].Service.ServiceName);
        item.SubItems.Add(Enum.GetName(typeof(ServiceLoader.ServiceState), _serviceInformation[i].State));
        lvServices.Items.Add(item);
      }
    }

    private void BtnExit_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void BtnPlayPause_Click(object sender, EventArgs e)
    {
      ServiceLoader.ServiceInfo info = GetCurrentServiceInfo();
      if (info != null)
      {
        if (info.State == ServiceLoader.ServiceState.Running)
        {
          ServiceLoader.CallMethodOnServiceInfo(ServiceLoader.ServiceOperation.Pause, info);
        }
        else if (info.State == ServiceLoader.ServiceState.Stopped)
        {
          ServiceLoader.CallMethodOnServiceInfo(ServiceLoader.ServiceOperation.Start, info);
        }
        else //Paused
        {
          ServiceLoader.CallMethodOnServiceInfo(ServiceLoader.ServiceOperation.Continue, info);
        }
      }

      UpdateItemInfo();
    }

    private void UpdateItemInfo()
    {
      ServiceLoader.ServiceInfo info = GetCurrentServiceInfo();
      lvServices.SelectedItems[0].SubItems[1].Text = Enum.GetName(typeof(ServiceLoader.ServiceState), info.State);
      RefreshToolbar();
    }

    private void BtnStop_Click(object sender, EventArgs e)
    {
      ServiceLoader.ServiceInfo info = GetCurrentServiceInfo();
      if (info != null)
      {
        ServiceLoader.CallMethodOnServiceInfo(ServiceLoader.ServiceOperation.Stop, info);
      }

      UpdateItemInfo();
    }

    private void BtnRestart_Click(object sender, EventArgs e)
    {
      ServiceLoader.ServiceInfo info = GetCurrentServiceInfo();
      if (info != null)
      {
        ServiceLoader.CallMethodOnServiceInfo(ServiceLoader.ServiceOperation.Stop, info);
        ServiceLoader.CallMethodOnServiceInfo(ServiceLoader.ServiceOperation.Start, info);
      }

      UpdateItemInfo();
    }

    private ServiceLoader.ServiceInfo GetCurrentServiceInfo()
    {
      if (lvServices.SelectedIndices.Count > 0)
      {
        int index = lvServices.SelectedIndices[0];
        return _serviceInformation[index];
      }
      return null;
    }

    private void LvServices_SelectedIndexChanged(object sender, EventArgs e)
    {
      RefreshToolbar();
    }

    private void RefreshToolbar()
    {
      ServiceLoader.ServiceInfo info = GetCurrentServiceInfo();
      if (info != null)
      {
        switch (info.State)
        {
          case ServiceLoader.ServiceState.Stopped:
            btnPlayPause.Image = GortServiceDebugger.Resources.BtnPlay;
            btnPlayPause.Text = "Start";
            btnPlayPause.Enabled = true;
            btnStop.Enabled = false;
            btnRestart.Enabled = false;
            break;
          case ServiceLoader.ServiceState.Running:
            btnPlayPause.Image = GortServiceDebugger.Resources.BtnPause;
            btnPlayPause.Text = "Pause";
            btnPlayPause.Enabled = info.Service.CanPauseAndContinue;
            btnStop.Enabled = true;
            btnRestart.Enabled = true;
            break;
          case ServiceLoader.ServiceState.Paused:
            btnPlayPause.Image = GortServiceDebugger.Resources.BtnPlay;
            btnPlayPause.Text = "Un-Pause, De-Pause, Play ... Go!";
            btnPlayPause.Enabled = true;
            btnStop.Enabled = true;
            btnRestart.Enabled = true;
            break;
          default:
            break;
        }
      }
    }

    private void ServicesController_Load(object sender, EventArgs e)
    {
        label1.Text = string.Format("Copyright ©{0} Akanomi Softworks Inc.", DateTime.Now.Year);
    }
  }
}