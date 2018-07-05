using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceProcess;

namespace PlayingAround {
	class Program {
		static void Main(string[] args)
		{
			MyExceptionPlayground myEx = new MyExceptionPlayground();
			myEx.MyEx();

			String myString = String.Empty;//use str snippet!

			MyMachineProcesses p = new MyMachineProcesses();
			Boolean b = p.IsProcessActive("MSMQ");
			b = p.IsProcessActive("bingdesktopupdate");
			b = p.IsProcessActive("BingDesktopUpdate");
			myString = p.GetProcessStatus("BingDesktopUpdate");
		}
	}

	class MyExceptionPlayground {
		public void MyEx()
		{
			try {
				//throw new NotImplementedException();
				throw new FormatException();
			}
			catch (NotImplementedException ex) {

				throw new FormatException();
			}
			catch (Exception ex) {
				throw; 
			}
			Console.WriteLine("out");
		}
	}

	class MyMachineProcesses {

		public Boolean IsProcessActive(String processName)
		{
			List<ServiceController> services = ServiceController.GetServices().ToList();
			ServiceController sc = services.Find(o => o.ServiceName == processName);
			if (sc == null) {
				return false;
			}
			return true;
		}

		public String GetProcessStatus(String processName)
		{
			List<ServiceController> services = ServiceController.GetServices().ToList();
			ServiceController sc = services.Find(o => o.ServiceName == processName);
			return sc.Status.ToString();
		}

		public void StartProcess(String processName)
		{
			List<ServiceController> services = ServiceController.GetServices().ToList();
			ServiceController sc = services.Find(o => o.ServiceName == processName);
			sc.Start();
		}

		public void StopProcess(String processName)
		{
			List<ServiceController> services = ServiceController.GetServices().ToList();
			ServiceController sc = services.Find(o => o.ServiceName == processName);
			sc.Stop();
		}

	}

}
