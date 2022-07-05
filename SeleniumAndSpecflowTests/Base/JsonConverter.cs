using Newtonsoft.Json;
using System;
using System.IO;

namespace SeleniumAndSpecflowTests.Base
{
    public class JsonConverter
    {
        public readonly string jsonSettings;
        public readonly dynamic jsonData;

        public JsonConverter(string jsonSettings)
        {
            this.jsonSettings = jsonSettings;
            jsonData = ReturnJsonData();
        }

        public string GetJson
        {
            get
            {
                string workingDirectory = Environment.CurrentDirectory;
                string currentDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
                string filePath = Path.Combine(currentDirectory, jsonSettings);
                
                StreamReader r = new StreamReader(filePath);

                string json = r.ReadToEnd();
                return json;
            }
        }

        public dynamic GetJsonData
        {
            get
            {
                return jsonData;
            }
        }

        private dynamic ReturnJsonData()
        {
            return JsonConvert.DeserializeObject<dynamic>(GetJson);
        }
    }
}
