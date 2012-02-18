using System.Collections.Generic;
using System.IO;
using System.Linq;
using HtmlAgilityPackTool.Core;
using HtmlAgilityPackTool.Data;

namespace HtmlAgilityPackTool.Service.Impl
{
    public class ShowService : IShowService
    {
        private readonly IRepository<Show> _showRepository;
        private readonly IRepository<ShowDetail> _showDetailRepository;

        public ShowService(
            IRepository<Show> showRepository,
            IRepository<ShowDetail> showDetailRepository)
        {
            _showRepository = showRepository;
            _showDetailRepository = showDetailRepository;
        }

        public IEnumerable<Show> GetAllShows()
        {
            return _showRepository.Query().ToList();
        }

        public Show GetShowsByName(string name)
        {
            return _showRepository.Query()
                .FirstOrDefault(x => x.Name == name);
        }
       
        public void PublishShow(string showName, string publisher, IEnumerable<string> details)
        {
            var show = this.GetShowsByName(showName);
            if (show == null)
                throw new InvalidDataException("无效的name");

            foreach (var detailName in details)
            {
                var detail = new ShowDetail
                {
                    Name = detailName,
                    ShowId = show.ShowId
                };

                _showDetailRepository.Create(detail);
            }

            show.Publisher = publisher;
            //show.PublishedDate = DateTime.Now;

            _showRepository.Update(show);
        }

        public IEnumerable<Show> GetPage(int pageIndex, ref int totalCount)
        {
            var result = _showRepository.Query();
            var shows = (from p in result
                         orderby p.ShowId, p.CreateTime descending
                         select p).Skip((pageIndex - 1) * Contants.PageSize).Take(Contants.PageSize).ToList();

            totalCount = result.Count();

            return shows;
        }
    }
}
