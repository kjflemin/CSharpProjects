using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace JsonToXMLConverter {
	class Program {
		static void Main(string[] args)
		{

			JXConverter jx = new JXConverter();
			string j = jx.XMLToJSON();
			Console.WriteLine(j);
			XmlDocument x = jx.JSONToXML(j);
			Console.WriteLine(x.InnerXml);

			string newstr = jx.ReturnValueFromJSON(j);
			jx.SetValueInJSON();
		}
	}
}
