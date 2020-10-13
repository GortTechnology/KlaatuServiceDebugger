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
	        public ServiceBase Service { get; }

	        public ServiceState State { get; set; }

            public ServiceInfo(ServiceBase sb, ServiceState ss)
            {
                Service = sb;
                State = ss;
            }

        }

        public static void StartServices(ServiceBase[] servicesToRun)
        {
            StartServices(servicesToRun, false);
        }

        public static void StartServices(ServiceBase[] servicesToRun,
          bool autoStartAll)
        {
            if (servicesToRun == null || servicesToRun.Length == 0)
            {
                throw new ArgumentException(@"servicesToStart cannot be null or empty", nameof(servicesToRun));
            }

            if (System.Diagnostics.Debugger.IsAttached)
            {
                ShowInterface(servicesToRun, autoStartAll);
            }
            else
            {
                ServiceBase.Run(servicesToRun);
            }

        }

        private static void ShowInterface(ServiceBase[] servicesToRun,
          bool autoStartAll)
        {

            List<ServiceInfo> serviceInfos = new List<ServiceInfo>();
            foreach (var t in servicesToRun)
            {
	            ServiceInfo si = new ServiceInfo(t, ServiceState.Stopped);
	            if (autoStartAll)
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
            }
        }

        private static void CallMethodOnService(ServiceOperation operation,
          ServiceBase serviceBase)
        {
            Type serviceBaseType = serviceBase.GetType();
            object[] parameters = null;
            if (operation == ServiceOperation.Start)
                parameters = new object[] { null };

            string methodName = "On" + Enum.GetName(typeof(ServiceOperation), operation);

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
                throw new Exception($"An exception was thrown while trying to call the {methodName} of the {serviceBase.ServiceName} service.  Examine the inner exception for more information.",
                  ex.InnerException);
            }
        }
    }
}
