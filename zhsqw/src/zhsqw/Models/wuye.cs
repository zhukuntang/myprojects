using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace zhsqw.Models
{
    public class news
    {
        public string ID { get; set; }
        public string SQID { get; set; }
        public string NewsClass { get; set; }
        public string NewsPic { get; set; }
        public string NewsTitle { get; set; }
        public string NewsContent { get; set; }
    }

    public class w_areas
    {
        public string ID { get; set; }
        public string CityID { get; set; }
        public string AreaName { get; set; }
        public string Addr { get; set; }
    }
}
