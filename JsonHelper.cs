using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WxTest
{
    public class JsonHelper
    {
        public static Info getInfo(string json)
        {
            return JsonConvert.DeserializeObject<Info>(json);
        }
    }
     public class Info
{
        public string errcode { get; set; }
        public string errmsg { get; set; }
        public string url { get; set; }
        public string token { get; set; }
        public string authorization { get; set; }
        public string file_id { get; set; }
        public string cos_file_id { get; set; }
    }
}
