using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace zhsqw.Models
{
    public class SysNews
    {
        public string ID { get; set; }
        public string SQID { get; set; }
        public string NewsClass { get; set; }
        public string NewsPic { get; set; }
        public string NewsTitle { get; set; }
        public string NewsContent { get; set; }
    }

    public class SysAds
    {
        public string ID { get; set; }
        public string AdOrder { get; set; }
        public string AdPath { get; set; }
    }
}
