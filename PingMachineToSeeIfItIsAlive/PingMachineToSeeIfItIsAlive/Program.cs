using System;
using System.Net.NetworkInformation;

namespace PingMachineToSeeIfItIsAlive {
	class Program {
		static void Main(string[] args)
		{
			//https://msdn.microsoft.com/en-us/library/system.net.networkinformation.ping(v=vs.110).aspx
			String result = String.Empty;
			result = IsMachineAvailable("CoolDude");
			result = IsMachineAvailable("127.0.0.1");
			result = IsMachineAvailable("w0186700");

		}

		public static String IsMachineAvailable(String hostname)
		{
			Ping ping = new Ping();
			try {
				PingReply reply = ping.Send(hostname);
				return "Success";
			}
			catch (Exception ex) {
				return ex.InnerException.Message.ToString();
			}

		}
	}
}
