using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFSTestManagerGoodies;

using Microsoft.TeamFoundation;
using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.Common;
using Microsoft.TeamFoundation.TestManagement;
using Microsoft.TeamFoundation.TestManagement.Client;
using Microsoft.TeamFoundation.WorkItemTracking;
using Microsoft.TeamFoundation.Framework.Common;
using Microsoft.TeamFoundation.Framework.Client;

namespace TFS_Test_Cases {
	class Program {
		static void Main(string[] args)
		{
			TFSTestManager t = new TFSTestManager();
			t.KickMe();

			//List<String> ret = t.GetTFSCollections();
			//ret.Clear();
			//ret = t.GetTFSProjects();
			//ret.Clear();
			//t.GetTestCasesFromProject();


			//TFSTestManager t2 = new TFSTestManager(@"https://tfs.mmm.com/tfs");
			//ret = t2.GetTFSProjects();

			string interestedFields = "[System.Id], [System.Title]"; // and more
																	 //string testCaseName = TestContext.FullyQualifiedTestClassName + "." + TestContext.TestName;
																	 //string storageName = Path.GetFileName(Assembly.GetExecutingAssembly().CodeBase);
			string query = string.Format("SELECT {0} FROM WorkItems", interestedFields);


			//TfsConfigurationServer configServer = GetTFSServerInformation();
			TfsTeamProjectCollection tfs = TfsTeamProjectCollectionFactory.GetTeamProjectCollection(new Uri(@"https://tfs.mmm.com/tfs"));

			ITestManagementService testService = (ITestManagementService)tfs.GetService(typeof(ITestManagementService));


			ITestManagementTeamProject project = testService.GetTeamProject("Alderaan");

		}
	}
}
