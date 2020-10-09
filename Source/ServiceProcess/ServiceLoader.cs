/**************************************************************************************************
* GPL v.2 License
* ---------------
* ServiceLoader.cs
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


using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceProcess;
using System.Reflection;

namespace GortServiceDebugger
{
	public static class ServiceLoader
	{
		internal enum ServiceOperation { Stop, Start, Pause, Continue };
		internal enum ServiceState { Stopped, Running, Paused };
		internal class ServiceInfo
		{
			readonly ServiceBase _service;
			public ServiceBase Service
			{
				get { return _service; }
			}

			ServiceState _state;
			public ServiceState State
			{
				get { return _state; }
				set { _state = value; }
			}

			public ServiceInfo(ServiceBase sb, ServiceState ss)
			{
				_service = sb;
				_state = ss;
			}

		}

		public static void StartServices(ServiceBase[] ServicesToRun)
		{
			StartServices(ServicesToRun, false);
		}

		public static void StartServices(ServiceBase[] ServicesToRun,
		  bool AutoStartAll)
		{
			if (ServicesToRun == null || ServicesToRun.Length == 0)
			{
				throw new ArgumentException(
				  "servicesToStart cannot be null or empty", "servicesToStart");
			}

			if (System.Diagnostics.Debugger.IsAttached)
			{
				ShowInterface(ServicesToRun, AutoStartAll);
			}
			else
			{
				ServiceBase.Run(ServicesToRun);
			}

		}

		private static void ShowInterface(ServiceBase[] ServicesToRun,
		  bool AutoStartAll)
		{

			List<ServiceInfo> serviceInfos = new List<ServiceInfo>();
			for (int i = 0; i < ServicesToRun.Length; i++)
			{
				ServiceInfo si = new ServiceInfo(ServicesToRun[i],
				  ServiceState.Stopped);
				if (AutoStartAll)
				{
					CallMethodOnServiceInfo(ServiceOperation.Start, si);
				}
				serviceInfos.Add(si);
			}

			ServicesController controller = new ServicesController(serviceInfos);
			controller.ShowDialog();

		}

		internal static void CallMethodOnServiceInfo(ServiceOperation operation,
		  ServiceInfo info)
		{
			CallMethodOnService(operation, info.Service);
			switch (operation)
			{
				case ServiceOperation.Stop:
					info.State = ServiceState.Stopped;
					break;
				case ServiceOperation.Start:
					info.State = ServiceState.Running;
					break;
				case ServiceOperation.Pause:
					info.State = ServiceState.Paused;
					break;
				case ServiceOperation.Continue:
					info.State = ServiceState.Running;
					break;
				default:
					break;
			}
		}

		private static void CallMethodOnService(ServiceOperation operation,
		  ServiceBase serviceBase)
		{
			Type serviceBaseType = serviceBase.GetType();
			object[] parameters = null;
			if (operation == ServiceOperation.Start)
				parameters = new object[] { null };

			string methodName = "On" + Enum.GetName(typeof(ServiceOperation),
  operation);

			try
			{
				serviceBaseType.InvokeMember(methodName,
				  BindingFlags.Instance |
				  BindingFlags.Public |
				  BindingFlags.NonPublic |
				  BindingFlags.InvokeMethod, null, serviceBase, parameters);
			}
			catch (Exception ex)
			{
				throw new Exception(string.Format(
				  "An exception was thrown while trying to call the {0} of the "
				  + "{1} service.  Examine the inner exception for more informat"
				  + "ion.", methodName, serviceBase.ServiceName),
				  ex.InnerException);
			}
		}

	}
}
