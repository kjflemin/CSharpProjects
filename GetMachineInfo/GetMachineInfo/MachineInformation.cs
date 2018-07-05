using System;
using System.Net;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace GetMachineInfo {
	public class MachineInformation {

		[DllImport("kernel32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		static extern bool GetPhysicallyInstalledSystemMemory(out long TotalMemoryInKilobytes);

		public String GetHostname {
			get { return Dns.GetHostName(); }
		}

		public String GetIPAddress {
			get {
				IPAddress[] addr = Dns.GetHostAddresses(GetHostname);
				return addr[0].ToString();
			}
		}

		public String GetTotalMemory {
			get {
				long memKb;
				GetPhysicallyInstalledSystemMemory(out memKb);
				return (memKb / 1024 / 1024).ToString() + " GB";
			}
		}

		public String GetUserName {
			get {
				return Environment.UserName;
			}
		}

		public String GetUsedMemory {
			get {
				Int64 phav = PerformanceInfo.GetPhysicalAvailableMemoryInMiB();
				Int64 tot = PerformanceInfo.GetTotalMemoryInMiB();
				decimal percentFree = ((decimal)phav / (decimal)tot) * 100;
				decimal percentOccupied = 100 - percentFree;


				return percentOccupied.ToString();
			}
		}

		public String GetUsedDiskSpacePercentage {
			get {
				DriveInfo drive = new System.IO.DriveInfo("c:");
				DriveInfo available = new DriveInfo(drive.Name);
				long HDPercentageUsed = 100 - (100 * available.AvailableFreeSpace / available.TotalSize);
				return HDPercentageUsed.ToString();
			}
		}

		public String GetOSInfo {
			get {
				var OperatingSystem = Environment.OSVersion;
				return
					OperatingSystem.VersionString + " " +
					OperatingSystem.ServicePack;
			}
		}
	}


	public class PerformanceInfo {
		[DllImport("psapi.dll", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetPerformanceInfo([Out] out PerformanceInformation PerformanceInformation, [In] int Size);

		[StructLayout(LayoutKind.Sequential)]
		public struct PerformanceInformation {
			public int Size;
			public IntPtr CommitTotal;
			public IntPtr CommitLimit;
			public IntPtr CommitPeak;
			public IntPtr PhysicalTotal;
			public IntPtr PhysicalAvailable;
			public IntPtr SystemCache;
			public IntPtr KernelTotal;
			public IntPtr KernelPaged;
			public IntPtr KernelNonPaged;
			public IntPtr PageSize;
			public int HandlesCount;
			public int ProcessCount;
			public int ThreadCount;
		}

		public static Int64 GetPhysicalAvailableMemoryInMiB()
		{
			PerformanceInformation pi = new PerformanceInformation();
			if (GetPerformanceInfo(out pi, Marshal.SizeOf(pi))) {
				return Convert.ToInt64((pi.PhysicalAvailable.ToInt64() * pi.PageSize.ToInt64() / 1048576));
			}
			else {
				return -1;
			}

		}

		public static Int64 GetTotalMemoryInMiB()
		{
			PerformanceInformation pi = new PerformanceInformation();
			if (GetPerformanceInfo(out pi, Marshal.SizeOf(pi))) {
				return Convert.ToInt64((pi.PhysicalTotal.ToInt64() * pi.PageSize.ToInt64() / 1048576));
			}
			else {
				return -1;
			}

		}
	}
}
