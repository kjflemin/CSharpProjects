using Microsoft.TeamFoundation;
using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.Common;
using Microsoft.TeamFoundation.TestManagement;
using Microsoft.TeamFoundation.TestManagement.Client;
using Microsoft.TeamFoundation.WorkItemTracking;
using Microsoft.TeamFoundation.WorkItemTracking.Client;
using Microsoft.TeamFoundation.Framework.Common;
using Microsoft.TeamFoundation.Framework.Client;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFSTestManagerGoodies {

	[Serializable]
	public class TFSTestCase {

		//[NonSerialized]
		//private TeamFoundationIdentityName teamFoundationIdentityName;
		//private int id;
		//private string title;
		//private string area;
		//private string createdBy;
		//private DateTime dateCreated;
		//private DateTime dateModified;
		//private Priority priority;
		//protected bool isInitialized;

		//public string OwnerDisplayName { get; set; }

		//public Guid TeamFoundationId { get; set; }

		//public int Id {
		//	get {
		//		return this.id;
		//	}

		//	set {
		//		this.id = value;
		//	}
		//}

		//public string Title {
		//	get {
		//		return this.title;
		//	}

		//	set {
		//		if (this.isInitialized) {
		//			UndoRedoManager.Instance().Push(t => this.Title = t, this.title, "Change the test case title");
		//		}
		//		this.title = value;
		//		this.NotifyPropertyChanged();
		//	}
		//}

		//public DateTime DateCreated {
		//	get {
		//		return this.dateCreated;
		//	}

		//	set {
		//		this.dateCreated = value;
		//		this.NotifyPropertyChanged();
		//	}
		//}

		//public string CreatedBy {
		//	get {
		//		return this.createdBy;
		//	}

		//	set {
		//		this.createdBy = value;
		//		this.NotifyPropertyChanged();
		//	}
		//}

		//public DateTime DateModified {
		//	get {
		//		return this.dateModified;
		//	}

		//	set {
		//		this.dateModified = value;
		//		this.NotifyPropertyChanged();
		//	}
		//}

		//public string Area {
		//	get {
		//		return this.area;
		//	}

		//	set {
		//		if (this.isInitialized) {
		//			UndoRedoManager.Instance().Push(a => this.Area = a, this.area, "Change the test case area");
		//		}
		//		this.area = value;
		//		this.NotifyPropertyChanged();
		//	}
		//}

		//public TeamFoundationIdentityName TeamFoundationIdentityName {
		//	get {
		//		return this.teamFoundationIdentityName;
		//	}

		//	set {
		//		if (this.isInitialized) {
		//			UndoRedoManager.Instance().Push(t => this.TeamFoundationIdentityName = t, this.teamFoundationIdentityName, "Change the test case owner");
		//		}
		//		this.teamFoundationIdentityName = value;
		//		this.NotifyPropertyChanged();
		//	}
		//}

		//public Priority Priority {
		//	get {
		//		return this.priority;
		//	}

		//	set {
		//		if (this.isInitialized) {
		//			UndoRedoManager.Instance().Push(p => this.Priority = p, this.priority, "Change the test case priority");
		//		}
		//		this.priority = value;
		//		this.NotifyPropertyChanged();
		//	}
		//}

	}
}
