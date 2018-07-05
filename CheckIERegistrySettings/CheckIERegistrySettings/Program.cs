using System;
using Microsoft.Win32;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIERegistrySettings {
	class Program {
		static void Main(string[] args)
		{

			

			Console.Clear();
			Console.WriteLine("Registry Settings");

			const string RegPathZone1 = "Software\\Microsoft\\Windows\\CurrentVersion\\Internet Settings\\Zones\\1";
			const string RegPathZone2 = "Software\\Microsoft\\Windows\\CurrentVersion\\Internet Settings\\Zones\\2";
			const string RegPathZone3 = "Software\\Microsoft\\Windows\\CurrentVersion\\Internet Settings\\Zones\\3";
			const string RegPathZone4 = "Software\\Microsoft\\Windows\\CurrentVersion\\Internet Settings\\Zones\\4";

			using (RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(RegPathZone1)) {
				Console.WriteLine("Number of Sub Keys {0}",registryKey.SubKeyCount);//registry is not null
				string[] myarray = registryKey.GetValueNames();
				var value = registryKey.GetValue("DisplayName");
				Console.WriteLine("Internet Settings\\Zones\\1 > DisplayName={0}", value);
				value = registryKey.GetValue("CurrentLevel");
				Console.WriteLine("Internet Settings\\Zones\\1 > CurrentLevel Setting={0}", value);

				List<string> mylist = new List<string>(myarray);
				mylist.Sort();
				foreach  (string name in mylist) {
					Console.WriteLine("Name = {0} Value = {1}", name, registryKey.GetValue(name));
				}
			}

			using (RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(RegPathZone2)) {
				Console.WriteLine("Number of Sub Keys {0}", registryKey.SubKeyCount);//registry is not null
				string[] myarray = registryKey.GetValueNames();
				var value = registryKey.GetValue("DisplayName");
				Console.WriteLine("Internet Settings\\Zones\\2 > DisplayName={0}", value);
				value = registryKey.GetValue("CurrentLevel");
				Console.WriteLine("Internet Settings\\Zones\\2 > CurrentLevel Setting={0}", value);
			}

			using (RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(RegPathZone3)) {
				Console.WriteLine("Number of Sub Keys {0}", registryKey.SubKeyCount);//registry is not null
				string[] myarray = registryKey.GetValueNames();
				var value = registryKey.GetValue("DisplayName");
				Console.WriteLine("Internet Settings\\Zones\\3 > DisplayName={0}", value);
				value = registryKey.GetValue("CurrentLevel");
				Console.WriteLine("Internet Settings\\Zones\\3 > CurrentLevel Setting={0}", value);
			}

			using (RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(RegPathZone4)) {
				Console.WriteLine("Number of Sub Keys {0}", registryKey.SubKeyCount);//registry is not null
				string[] myarray = registryKey.GetValueNames();
				var value = registryKey.GetValue("DisplayName");
				Console.WriteLine("Internet Settings\\Zones\\4 > DisplayName={0}", value);
				value = registryKey.GetValue("CurrentLevel");
				Console.WriteLine("Internet Settings\\Zones\\4 > CurrentLevel Setting={0}", value);
			}

			Console.ReadKey();

		}
	}

}
