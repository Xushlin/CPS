using System.Collections.Generic;
using HtmlAgilityPackTool.Data;

namespace HtmlAgilityPackTool.Service
{
    public interface IShowService
    {
        IEnumerable<Show> GetAllShows();
        Show GetShowsByName(string name);
        void PublishShow(string showName, string publisher, IEnumerable<string> details);
        IEnumerable<Show> GetPage(int pageIndex, ref int totalCount);
    }
}
