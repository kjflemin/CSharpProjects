using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.TestManagement.Client;
using Microsoft.TeamFoundation.WorkItemTracking.Client;
using System.Collections.ObjectModel;
using Microsoft.TeamFoundation.Framework.Client;
using Microsoft.TeamFoundation.Framework.Common;

namespace TFSTestCases2015 {
	class Program {
		static void Main(string[] args)
		{

			//Uri tfsUri = new Uri(@"https://tfsqa.mmm.com/tfs");
			//string teamProjectName = "Alderaan";
			//TfsTeamProjectCollection myTfsTeamProjectCollection = new TfsTeamProjectCollection(tfsUri);
			//ITestManagementService service = (ITestManagementService)myTfsTeamProjectCollection.GetService(typeof(ITestManagementService));
			//ITestManagementTeamProject myTestManagementTeamProject = service.GetTeamProject(teamProjectName);

			Uri tfsUri = new Uri(@"https://tfsqa.mmm.com/tfs");
			string teamProjectName = "Alderaan";

			TfsConfigurationServer configServer = TfsConfigurationServerFactory.GetConfigurationServer(tfsUri);

			ReadOnlyCollection<CatalogNode> collectionNodes = configServer.CatalogNode.QueryChildren(new[] { CatalogResourceTypes.ProjectCollection }, false, CatalogQueryOptions.None);

			ITestManagementService testManagementService = (ITestManagementService)configServer.GetService(typeof(ITestManagementService));
			//ITestManagementTeamProject myTestManagementTeamProject = service.GetTeamProject(teamProjectName);

		}
	}
}
