using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetMachineInfo {
	class Program {
		static void Main(string[] args)
		{
			MachineInformation m = new MachineInformation();
			String ret;
			ret = m.GetHostname;
			ret = m.GetIPAddress;
			ret = m.GetTotalMemory;
			ret = m.GetOSInfo;
			ret = m.GetUserName;
			ret = m.GetUsedDiskSpacePercentage;
			ret = m.GetUsedMemory;
		}
	}
}
