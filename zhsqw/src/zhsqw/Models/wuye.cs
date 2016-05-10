using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace zhsqw.Models
{
    public class wy_news
    {
        public string ID { get; set; }
        public string AreaID { get; set; }
        public string NewsClass { get; set; }
        public string NewsPic { get; set; }
        public string NewsTitle { get; set; }
        public string NewsContent { get; set; }
    }

    public class wy_ads
    {
        public string ID { get; set; }
        public string AdOrder { get; set; }
        public string AdPath { get; set; }
    }
}
