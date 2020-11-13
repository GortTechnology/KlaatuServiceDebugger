/**************************************************************************************************
* SPDX-License-Identifier: GPL-2.0
* GPL v.2 License
* ---------------
* TestService.cs
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
using System.ServiceProcess;
using NLog;
using System.Configuration;

namespace GortTestService
{
	public partial class ServiceDebuggerTestService : ServiceBase
	{
		private static readonly Logger logger = LogManager.GetCurrentClassLogger();

		public ServiceDebuggerTestService()
		{
			InitializeComponent();
		}

		protected override void OnStart(string[] args)
		{
			logger.Log(LogLevel.Trace, "System Start");

			if (int.TryParse(ReadAppSetting("LoggingInterval"), out int interval))
			{
				logger.Log(LogLevel.Trace, string.Format("Read the value of {0} for the 'LoggingInterval' configuration setting.", interval));
			}
			else
			{
				logger.Log(LogLevel.Error, "Failed to read a valid setting value for 'LoggingInterval'. Defaulting to 1000.");
				// set default value.
				interval = 1000;
			}
			timer.Interval = interval;
			timer.Start();
		}

		protected override void OnStop()
		{
			timer.Stop();
		}

		private void Timer_Tick(object sender, EventArgs e)
		{
			// The resulting logging will be based on the LogLevel set in the NLog.config file.
			logger.Log(LogLevel.Trace, string.Format("ServiceDebuggerLog : {0}", DateTime.Now.ToString()));
		}

		static string ReadAppSetting(string key)
		{
			try
			{
				var appSettings = ConfigurationManager.AppSettings;
				string result = appSettings[key] ?? "Not Found";
				return result;
			}
			catch (ConfigurationException)
			{
				Console.WriteLine("Error reading app settings");
			}
			return string.Empty;
		}
	}
}
