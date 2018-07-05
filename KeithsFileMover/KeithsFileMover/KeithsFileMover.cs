using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace KeithsFileMover {
	public partial class KeithsFileMover : ServiceBase {
		protected const string EventSource = "Keiths File Mover";
		protected const string EventLogName = "Keiths Mover Messages";

		public KeithsFileMover() {
			InitializeComponent();
			eventLog1 = new EventLog();
			if (!EventLog.SourceExists(EventSource)) {
				EventLog.CreateEventSource(EventSource, EventLogName);
			}
			eventLog1.Source = EventSource;
			eventLog1.Log = EventLogName;
		}

		protected override void OnStart(string[] args) {
			eventLog1.WriteEntry("Starting Logging for Keiths File Mover:" + DateTime.Now.ToString());
			
			// Set up a timer to trigger every period of time.
			int seconds = 10000;//get this from a config file?
			System.Timers.Timer timer = new System.Timers.Timer();
			timer.Interval = seconds; // n seconds
			timer.Elapsed += new System.Timers.ElapsedEventHandler(this.OnTimer);
			timer.Start();
		}

		protected override void OnStop() {
			eventLog1.WriteEntry("Logging stopped for Keiths File Mover:" + DateTime.Now.ToString());
		}

		public void OnTimer(object sender, System.Timers.ElapsedEventArgs args) {
			// TODO: Insert monitoring activities here.
			eventLog1.WriteEntry("Monitoring Keiths File Mover" + DateTime.Now.ToString(), EventLogEntryType.Information);
			//You might want to perform tasks by using background worker threads instead of running all your 
			//work on the main thread.For an example of this, see the System.ServiceProcess.ServiceBase reference page.
		}

		//after building, use instalutil.exe KeithsFileMover.exe to install
		//use installutil.exe /u KeithsFileMover.exe to uninstall
		//net start/stop KeithsFileMover to start and stop the util from commandline
		//Windows Key > Event Viewer to see event log
		//Windows Key > services.msc to see services running
	}
}
