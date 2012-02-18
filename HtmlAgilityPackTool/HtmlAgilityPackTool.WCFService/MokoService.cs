using System.Linq;
using HtmlAgilityPackTool.Service;
using HtmlAgilityPackTool.WCFService.Contract;

namespace HtmlAgilityPackTool.WCFService
{
    public class MokoService:IMokoService
    {
        public MokoService()
        {
            
        }
        private readonly IShowService _showService;

        public MokoService(IShowService showService)
        {
            _showService = showService;
        }

        public ShowList GetShows()
        {
            var showList = new ShowList();
            var shows =_showService.GetAllShows();
            showList.Shows.AddRange(shows.Select(x=>new Show
                {
                    ChildUrl = x.ChildUrl,
                    PublishedDate = x.PublishedDate,
                    CreateTime = x.CreateTime,
                    IsNew = x.IsNew,
                    Name = x.Name,
                    Url = x.Url,
                    Occupation = x.Occupation,
                    Publisher = x.Publisher,
                    ShowId = x.ShowId
                }));
            return showList;
        }
    }
}