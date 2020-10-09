using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
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
