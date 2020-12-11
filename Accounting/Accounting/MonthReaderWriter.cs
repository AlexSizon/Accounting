using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting
{
    public class MonthReaderWriter
    {
        public static void WriteToJson(List<List<Order>> orders)
        {
            string jsonstr = JsonConvert.SerializeObject(orders);
            File.WriteAllText(Directory.GetCurrentDirectory() + "\\OrdersBase.json", jsonstr);
        }
        public static List<List<Order>> ReadJson()
        {
            string jsonpings = File.ReadAllText(Directory.GetCurrentDirectory() + "\\OrdersBase.json");
            return JsonConvert.DeserializeObject<List<List<Order>>>(jsonpings);
        }
    }
}
