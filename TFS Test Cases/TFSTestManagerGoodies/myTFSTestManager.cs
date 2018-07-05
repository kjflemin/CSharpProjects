using Microsoft.TeamFoundation;
using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.Common;
using Microsoft.TeamFoundation.TestManagement;
using Microsoft.TeamFoundation.TestManagement.Client;
using Microsoft.TeamFoundation.WorkItemTracking;
using Microsoft.TeamFoundation.Framework.Common;
using Microsoft.TeamFoundation.Framework.Client;

using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.Services.WebApi;
using Microsoft.VisualStudio.Services.Common;
using Microsoft.TeamFoundation.WorkItemTracking.WebApi;
using Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models;
using System.Net;

namespace TFSTestManagerGoodies {
	public class TFSTestManager {

		private Uri _uri;
		private String _projectName;

		public TFSTestManager()
		{
			_uri = new Uri(@"https://tfsqa.mmm.com/tfs");
			_projectName = "Alderaan";
		}

		public TFSTestManager(String uri)
		{
			_uri = new Uri(uri);
		}

		public String ProjectName {
			get { return this._projectName; }
			set { this._projectName = value; }
		}

		public void GetTestCasesFromProject()
		{
			string interestedFields = "[System.Id], [System.Title]"; // and more
			//string testCaseName = TestContext.FullyQualifiedTestClassName + "." + TestContext.TestName;
			//string storageName = Path.GetFileName(Assembly.GetExecutingAssembly().CodeBase);
			string query = string.Format("SELECT {0} FROM WorkItems", interestedFields);


			//TfsConfigurationServer configServer = GetTFSServerInformation();
			TfsTeamProjectCollection tfs = TfsTeamProjectCollectionFactory.GetTeamProjectCollection(_uri);

			ITestManagementService testService = tfs.GetService<ITestManagementService>();
			//copy the WitDataStore to the bin directory -- https://stackoverflow.com/questions/31031817/unable-to-load-dll-microsoft-witdatastore32-dll-teamfoundation-workitemtracki

			//http://geekswithblogs.net/BobHardister/archive/2014/09/30/microsoft.witdatastore.dll-not-found-nuget-nuspec-references.aspx
			//https://stackoverflow.com/questions/28235448/vsto-oneclick-deplyoment-missing-microsoft-witdatastore-dll

			ITestManagementTeamProject project = testService.GetTeamProject(@"https://tfsqa.mmm.com/tfs/Alderaan/Alderaan Team");

			ITestCase foundTestCase = null;
			IEnumerable<ITestCase> testCases = project.TestCases.Query(query);
			if (testCases.Count() == 1) {
				foundTestCase = testCases.First();
			}

			//ITestManagementService tms = configServer.GetService<ITestManagementService>();

			//ITestManagementTeamProject teamProject = configServer.GetService<ITestManagementService>().GetTeamProject("Alderaan");

			//IEnumerable<ITestCase> testCases = teamProject.TestCases.Query("SELECT * FROM WorkItems");


		}

		public void GetTestCaseValues()
		{

		}

		public void UpdateTestCaseValues()
		{

		}




		public TfsConfigurationServer GetTFSServerInformation()
		{
			TfsConfigurationServer configServer = TfsConfigurationServerFactory.GetConfigurationServer(_uri);
			return configServer;
		}

		public ReadOnlyCollection<CatalogNode> GetTFSCollectionNodes(TfsConfigurationServer configServer)
		{
			ReadOnlyCollection<CatalogNode> collectionNodes = configServer.CatalogNode.QueryChildren(new[] { CatalogResourceTypes.ProjectCollection }, false, CatalogQueryOptions.None);
			return collectionNodes;
		}

		public List<String> GetTFSProjects()
		{
			TfsConfigurationServer server = GetTFSServerInformation();
			ReadOnlyCollection<CatalogNode> catalog = GetTFSCollectionNodes(server);
			return GetTFSListOfProjects(server, catalog);

		}

		public List<String> GetTFSCollections()
		{
			TfsConfigurationServer server = GetTFSServerInformation();
			ReadOnlyCollection<CatalogNode> catalog = GetTFSCollectionNodes(server);
			return GetTFSListOfCollections(server, catalog);
		}

		private List<String> GetTFSListOfProjects(TfsConfigurationServer configServer, ReadOnlyCollection<CatalogNode> collectionNodes)
		{
			List<String> projects = new List<string>();

			foreach (CatalogNode collectionNode in collectionNodes) {
				// Use the InstanceId property to get the team project collection
				Guid collectionId = new Guid(collectionNode.Resource.Properties["InstanceId"]);
				TfsTeamProjectCollection teamProjectCollection = configServer.GetTeamProjectCollection(collectionId);

				// Get a catalog of team projects for the collection
				ReadOnlyCollection<CatalogNode> projectNodes = collectionNode.QueryChildren(new[] { CatalogResourceTypes.TeamProject }, false, CatalogQueryOptions.None);

				// List the team projects in the collection
				foreach (CatalogNode projectNode in projectNodes) {
					projects.Add(projectNode.Resource.DisplayName);
				}
			}

			return projects;
		}

		private List<String> GetTFSListOfCollections(TfsConfigurationServer configServer, ReadOnlyCollection<CatalogNode> collectionNodes)
		{
			List<String> CollectionNodes = new List<string>();

			foreach (CatalogNode collectionNode in collectionNodes) {
				// Use the InstanceId property to get the team project collection
				Guid collectionId = new Guid(collectionNode.Resource.Properties["InstanceId"]);
				TfsTeamProjectCollection teamProjectCollection = configServer.GetTeamProjectCollection(collectionId);

				// Print the name of the team project collection
				CollectionNodes.Add(teamProjectCollection.Name);
			}

			return CollectionNodes;
		}






		public void TestMe()
		{
			Uri tfsUri = new Uri(@"https://tfsqa.mmm.com/tfs");
			string teamProjectName = "Alderaan";

			TfsConfigurationServer configServer = TfsConfigurationServerFactory.GetConfigurationServer(tfsUri);

			ReadOnlyCollection<CatalogNode> collectionNodes = configServer.CatalogNode.QueryChildren(new[] { CatalogResourceTypes.ProjectCollection }, false, CatalogQueryOptions.None);

			foreach (CatalogNode collectionNode in collectionNodes) {
				// Use the InstanceId property to get the team project collection
				Guid collectionId = new Guid(collectionNode.Resource.Properties["InstanceId"]);
				TfsTeamProjectCollection teamProjectCollection = configServer.GetTeamProjectCollection(collectionId);

				// Print the name of the team project collection
				Console.WriteLine("Collection: " + teamProjectCollection.Name);

				// Get a catalog of team projects for the collection
				ReadOnlyCollection<CatalogNode> projectNodes = collectionNode.QueryChildren(
					new[] { CatalogResourceTypes.TeamProject },
					false, CatalogQueryOptions.None);

				// List the team projects in the collection
				foreach (CatalogNode projectNode in projectNodes) {
					Console.WriteLine(" Team Project: " + projectNode.Resource.DisplayName);
				}
			}

		}

		public void KickMe()
		{
			//VssConnection connection = new VssConnection(new Uri(@"https://tfsqa.mmm.com/tfs"), new VssBasicCredential("",""));

			VssConnection connection = new VssConnection(new Uri(@"https://tfsqa.mmm.com/tfs"), new VssCredentials(new Microsoft.VisualStudio.Services.Common.WindowsCredential(new NetworkCredential("", ""))));
			bool ret = connection.HasAuthenticated;

			WorkItemTrackingHttpClient witClient = connection.GetClient<WorkItemTrackingHttpClient>();
			List<QueryHierarchyItem> items = witClient.GetQueriesAsync("Alderaan").Result;



		}

	}
}
