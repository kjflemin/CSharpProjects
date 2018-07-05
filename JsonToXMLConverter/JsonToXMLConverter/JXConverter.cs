using System;
using System.Diagnostics;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Reflection;//for accessing the file

namespace JsonToXMLConverter {
	class JXConverter {

		Assembly _assembly;
		StreamReader _textStreamReader;

		public string XMLToJSON()
		{
			try {
				_assembly = Assembly.GetExecutingAssembly();
				_textStreamReader = new StreamReader(_assembly.GetManifestResourceStream("JsonToXMLConverter.myXML.xml"));
			}
			catch (Exception ex) {
				Console.WriteLine(ex.Message);
			}
			string s = _textStreamReader.ReadToEnd();
			XmlDocument doc = new XmlDocument();
			doc.LoadXml(s);

			string retval = JsonConvert.SerializeXmlNode(doc);
			return retval;
		}

		public XmlDocument JSONToXML(string jsonValue)
		{
			XmlDocument xmlvalue = JsonConvert.DeserializeXmlNode(jsonValue);
			return xmlvalue;
		}

		public void SetValueInJSON()
		{
			JObject jo = JsonConvert.DeserializeObject<JObject>(jsonString);
			string val = jo["ADDRESS_MAP"]["ADDRESS_LOCATION"]["FieldID"].ToString();
			jo["ADDRESS_MAP"]["ADDRESS_LOCATION"]["FieldID"] = "96";
			val = jo["ADDRESS_MAP"]["ADDRESS_LOCATION"]["FieldID"].ToString();

		}

		public string ReturnValueFromJSON(string JsonString)
		{
			JToken token = JObject.Parse(jsonString);
			//token = token.Last; //using this to get rid of the xml header

			JToken outer = JToken.Parse(jsonString);
			JObject inner = outer["ADDRESS_MAP"].Value<JObject>();

			List<string> keys = inner.Properties().Select(p => p.Name).ToList();

			foreach (string k in keys) {
				Console.WriteLine(k);
				JObject eachInner = inner[k].Value<JObject>();
				List<string> eachKey = eachInner.Properties().Select(p => p.Name).ToList();
				foreach (string eachK in eachKey) {
					Console.WriteLine(" " + eachK + " ");
				}
			}


			////// this works well //////
			Console.WriteLine("\n\n");
			JObject jo = JsonConvert.DeserializeObject<JObject>(jsonString);
			foreach (KeyValuePair<string, JToken> sub_obj in (JObject)jo["ADDRESS_MAP"]) {
				Console.WriteLine(sub_obj.Key /*+ sub_obj.Value*/);
			}

			string val = jo["ADDRESS_MAP"]["ADDRESS_LOCATION"]["FieldID"].ToString();
			Console.WriteLine(jo["ADDRESS_MAP"]["ADDRESS_LOCATION"]["FieldID"]);


			JObject jo1 = JsonConvert.DeserializeObject<JObject>(JsonString);
			string val1 = jo1["root"]["anothernode"].ToString();
			val1 = jo1["root"]["node"]["@label"].ToString();

			Debug.WriteLine(val1);

			return null;
		}

		public string jsonString =
	@"{
    ""ADDRESS_MAP"":{

        ""ADDRESS_LOCATION"":{
            ""type"":""separator"",
            ""name"":""Address"",
            ""value"":"""",
            ""FieldID"":40
        },
        ""LOCATION"":{
            ""type"":""locations"",
            ""name"":""Location"",
            ""keyword"":{
                ""1"":""LOCATION1""
            },
            ""value"":{
                ""1"":""United States""
            },
            ""FieldID"":41
        },
        ""FLOOR_NUMBER"":{
            ""type"":""number"",
            ""name"":""Floor Number"",
            ""value"":""0"",
            ""FieldID"":55
        },
        ""self"":{
            ""id"":""2"",
            ""name"":""Address Map""
        }
    }
}";


	}
}
