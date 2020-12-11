using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting
{
    class PropertiesReaderWriter
    {
        public static void WriteToJson(ProcentProperties prop)
        {
            string jsonstr = JsonConvert.SerializeObject(prop);
            File.WriteAllText(Directory.GetCurrentDirectory() + "\\Properties.json", jsonstr);

        }
        public static ProcentProperties ReadJson()
        {
            string jsonpings = File.ReadAllText(Directory.GetCurrentDirectory() + "\\Properties.json");
            return JsonConvert.DeserializeObject<ProcentProperties>(jsonpings);
        }
    }
}
