﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace KeithsFileMover {
	static class Program {
		/// <summary>
		/// The main entry point for the application.
		/// https://msdn.microsoft.com/en-us/library/zt39148a(v=vs.110).aspx
		/// </summary>
		static void Main() {
			ServiceBase[] ServicesToRun;
			ServicesToRun = new ServiceBase[]
			{
				new KeithsFileMover()
			};
			ServiceBase.Run(ServicesToRun);
		}
	}
}
