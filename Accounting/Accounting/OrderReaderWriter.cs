using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace Accounting
{

    class OrderReaderWriter
    {
        //public static void WriteToJson(List<Order> orders)
        //{
        //    DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(List<Order>));

        //    using (FileStream fs = new FileStream("Orders.json", FileMode.OpenOrCreate))
        //    {
        //        jsonFormatter.WriteObject(fs, orders);
        //    }

        //}
        //public static List<Order> ReadJson()
        //{
        //    DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(List<Order>));
        //    using (FileStream fs = new FileStream("Orders.json", FileMode.OpenOrCreate))
        //    {
        //        List<Order> orders = (List<Order>)jsonFormatter.ReadObject(fs);
        //        return orders;
        //    }
        //}
        public static void WriteToJson(List<Order> orders)
        {
            string jsonstr = JsonConvert.SerializeObject(orders);
            File.WriteAllText(Directory.GetCurrentDirectory() + "\\Orders.json", jsonstr);
        }
        public static List<Order> ReadJson()
        {
            string jsonpings =  File.ReadAllText(Directory.GetCurrentDirectory() + "\\Orders.json");
            return JsonConvert.DeserializeObject<List<Order>>(jsonpings).ToList();
        }
    }
}
