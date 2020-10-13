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
						btnPlayPause.Image = ImageResource.Play;
						btnPlayPause.Text = "Start";
						btnPlayPause.Enabled = true;
						btnStop.Enabled = false;
						btnRestart.Enabled = false;
						break;
					case ServiceLoader.ServiceState.Running:
						btnPlayPause.Image = ImageResource.Pause;
						btnPlayPause.Text = "Pause";
						btnPlayPause.Enabled = info.Service.CanPauseAndContinue;
						btnStop.Enabled = true;
						btnRestart.Enabled = true;
						break;
					case ServiceLoader.ServiceState.Paused:
						btnPlayPause.Image = ImageResource.Play;
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
			label1.Text = string.Format("Copyright ©2006 - {0} Gort Technology", DateTime.Now.Year);
		}
	}
}