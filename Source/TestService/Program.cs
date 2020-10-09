/**************************************************************************************************
* GPL v.2 License
* ---------------
* Program.cs
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

using System.ServiceProcess;

namespace GortTestService
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		static void Main()
		{
			ServiceBase[] ServicesToRun;
			ServicesToRun = new ServiceBase[]
			{
				new ServiceDebuggerTestService()
			};

/* 
 This is where the Service Debugger hooks into your Windows Service.

 Debug:
 In debug mode, the application runs as a Windows application and the service debugger is shown so 
 that you can start and stop the service for debugging. 

 Release:
 In release mode, the Service Debugger is compiled out so that the Windows service behaves normally 
 and need not be deployed with the service. 

 Development:
 You DO NOT NEED TO include the code for the service debugger in the Windows service solution. 
 Just compile the service debugger in release mode, then add the resulting ServiceDebugger.dll to 
 your Windows Service as a design-time library.
*/

#if DEBUG
			GortServiceDebugger.ServiceLoader.StartServices(ServicesToRun);
#else
         ServiceBase.Run(ServicesToRun);
#endif

		}
	}
}
