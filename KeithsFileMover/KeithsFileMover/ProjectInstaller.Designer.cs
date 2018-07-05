namespace KeithsFileMover {
	partial class ProjectInstaller {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Component Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.KeithsFileMover = new System.ServiceProcess.ServiceProcessInstaller();
			this.serviceInstaller1 = new System.ServiceProcess.ServiceInstaller();
			// 
			// KeithsFileMover
			// 
			this.KeithsFileMover.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
			this.KeithsFileMover.Password = null;
			this.KeithsFileMover.Username = null;
			// 
			// serviceInstaller1
			// 
			this.serviceInstaller1.Description = "My Simple File Mover Service";
			this.serviceInstaller1.DisplayName = "Keiths File Mover";
			this.serviceInstaller1.ServiceName = "KeithsFileMover";
			this.serviceInstaller1.StartType = System.ServiceProcess.ServiceStartMode.Automatic;
			// 
			// ProjectInstaller
			// 
			this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.KeithsFileMover,
            this.serviceInstaller1});

		}

		#endregion

		private System.ServiceProcess.ServiceProcessInstaller KeithsFileMover;
		private System.ServiceProcess.ServiceInstaller serviceInstaller1;
	}
}