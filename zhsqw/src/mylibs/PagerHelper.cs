using System;
using System.Linq;
using System.Text;

public class PagerHelper<T>
{
    public int PageIndex { set; get; }
    public int PageSize { set; get; }
    public int TotalPages { set; get; }

    public string PageNumberBar { set; get; }
    public IQueryable<T> PagedData { set; get; }

    public PagerHelper(IQueryable<T> datas, string url, int pagesize, int pageindex, int numspan, bool ispost)
    {
        string urlTemplate = string.Empty;
        if (ispost)
        {
            urlTemplate = "<a href=\"javascript:PagePostSubmit('{0}',{1})\">{2}</a>";
        }
        else
        {
            urlTemplate = "<a href=\"{0}?page={1}\">{2}</a>";
        }
        StringBuilder pageinfo = new StringBuilder();
        int records = datas.Count();
        int totalpages = 1;
        pageinfo.Append("<div class='numpage'>");
        if (records > pagesize)
        {
            totalpages = (int)Math.Ceiling(records / (double)pagesize);
            if (pageindex <= 1)
            {
                pageindex = 1;
            }
            else if (pageindex > totalpages)
            {
                pageindex = totalpages;
            }
            else
            {
                int prepageindex = pageindex - 1;
                pageinfo.AppendFormat(urlTemplate, url, prepageindex.ToString(), "<");
            }
            int startindex = pageindex - numspan;
            int endindex = pageindex + numspan;
            if (endindex > totalpages)
            {
                startindex -= endindex - totalpages + 1;
                endindex = totalpages;
            }
            if (startindex > 1)
            {
                pageinfo.AppendFormat(urlTemplate, url, "1", "1");
                pageinfo.Append("<span>...</span>");
            }
            else
            {
                startindex = 1;
                endindex = Math.Min(numspan * 2 + 2, totalpages);
            }
            for (int i = startindex; i <= endindex; i++)
            {
                if (i == pageindex)
                {
                    pageinfo.AppendFormat("<a style='background:#d4ecfc'>{0}</a>", i.ToString(), i.ToString());
                }
                else
                {
                    pageinfo.AppendFormat(urlTemplate, url, i.ToString(), i.ToString());
                }
            }
            if (endindex < totalpages)
            {
                pageinfo.Append("<span>...</span>");
                pageinfo.AppendFormat(urlTemplate, url, totalpages.ToString(), totalpages.ToString());
            }
            if (pageindex < totalpages)
            {
                int nextpageindex = pageindex + 1;
                pageinfo.AppendFormat(urlTemplate, url, nextpageindex.ToString(), ">");
            }
        }
        pageinfo.Append("</div>");

        //初始化公有变量
        PageIndex = pageindex;
        PageSize = pagesize;
        TotalPages = totalpages;
        PageNumberBar = pageinfo.ToString();
        PagedData = datas.Skip((pageindex - 1) * pagesize).Take(pagesize);
    }
}
