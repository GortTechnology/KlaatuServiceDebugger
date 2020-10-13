# Klaatu Windows Service Debugger
A debugging shim for developing, manual testing, and debugging Windows Services.

## How to use the Service Debugger.

The service debugger should be used in DEBUG mode only. When properly configured, hitting F5 in Visual Studio will launch a simple windows application with a list of available services...

<p align="center">
  <img width="460" height="300" src="Documentation/ServiceDebuggerForm.jpg">
</p>

You can start, stop and restart the services as necessary without stopping and re-launching your IDE's debugger. This is very helpful for setting breakpoints and stepping through code as necessary witout the need to kill and reload the entire IDE debugger.

* Click the [Start] button to start the service.
* Click the [Stop] button to stop the service.
* Click the [Restart] button to restart the service.

## Configuration

To configure the ServiceDebugger, add the ServiceDebugger.dll to your Windows Service project then modify the service's application entry point "static void Main()" - usually found in the service application's program.cs file - as follows...

	static class Program
	{
      static void Main()
      {
        ServiceBase[] ServicesToRun;
		ServicesToRun = new ServiceBase[]
		{
		  new ServiceDebuggerTestService()
		};
		#if (DEBUG)
   	        GortServiceDebugger.ServiceLoader.StartServices(ServicesToRun);
        #else
            ServiceBase.Run(ServicesToRun);
        #endif
      }
	}

Next, set Visual Studio's debugger to launch the service application as the default startup app and hit F5 like any normal Windows app. Instead of a warning about running a service, the service(s) will start like a normal Windows app. 

The form will load all available services into the grid. You can select the service you want to run and hit the start button to start it. If the service supports `CanPauseAndContinue` then the pause button will be active so that you can pause the service, otherwise it will be grayed out.

## Deployment

You DO NOT need to add the entire ServiceDebugger project code to your Service Solution. Just add the ServiceDebugger.dll assembly found in the [PrecompiledBinary](https://github.com/GortTechnology/KlaatuServiceDebugger/tree/main/PrecompiledBinary) folder, and modify the program.cs file as illustrated above. The source code is provided for you so that you can modify it if you desire but you only need the pre-compiled assembly to use the debugger shim with your service project.

The ServiceDebugger should NOT be deployed with the service compiled in release mode. It is compiled out and not required in release mode. Neither is it licensed, necessary, or useful for deployment to end-users.
