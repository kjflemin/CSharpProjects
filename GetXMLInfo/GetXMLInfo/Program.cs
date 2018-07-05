using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;


namespace GetXMLInfo {
	class Program {
		static void Main(string[] args) {
			XMLObject xmlobj = new XMLObject();
			xmlobj.LoadDocument();
			XmlNode node = xmlobj.GetSpecificControl("TxtUsername");
			Dictionary<String, String> SearchProperties = xmlobj.SearchProperties(node);
		}
	}

	class XMLObject {

		public XmlDocument mydoc = new XmlDocument();

		public void LoadDocument() {
			mydoc.Load("C:\\Users\\a6mjhzz\\Documents\\Visual Studio 2015\\Projects\\GetXMLInfo\\GetXMLInfo\\Page.xml");

			//XmlNodeList Controls = mydoc.GetElementsByTagName("Control");
		}

		public XmlNodeList GetControls(String ControlName) {
			XmlNodeList Nodes = mydoc.GetElementsByTagName(ControlName);
			return Nodes;
		}

		public XmlNode GetSpecificControl(String ControlAttributeName, XmlNodeList ListOfNodes = null) {
			XmlElement element = mydoc.DocumentElement;
			XmlNode node = element.SelectSingleNode("Control[@name='"+ControlAttributeName +"']");
			return node;
		}

		public Dictionary<String, String> SearchProperties(XmlNode ControlNode) {
			Dictionary<String, String> SearchProperties = new Dictionary<string, string>();
			List<String> mylist = new List<string>();
			foreach (XmlNode child in ControlNode.ChildNodes) {
				mylist.Add(child.InnerText);
				String[] arr = child.InnerText.Split('=');
				SearchProperties.Add(arr[0], arr[1]);
			}
			return SearchProperties;
		}
	}

}
