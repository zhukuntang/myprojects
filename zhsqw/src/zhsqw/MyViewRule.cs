using Microsoft.AspNet.Mvc.Razor;
using Microsoft.AspNet.Mvc.ViewEngines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace zhsqw
{
    public class MyViewRule : IViewLocationExpander
    {
        public void PopulateValues(ViewLocationExpanderContext context)
        {

        }

        public virtual IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context,
                                                                IEnumerable<string> viewLocations)
        {
            viewLocations = new[]
            {
                "~/Views/{1}/{0}.cshtml",
                "~/Views/Shared/{0}.cshtml",
                "~/Views/wuye/{1}/{0}.cshtml",
                "~/Views/sell/{1}/{0}.cshtml",
                "~/Views/admin/{1}/{0}.cshtml"
            };
            return viewLocations;
        }
    }
}
