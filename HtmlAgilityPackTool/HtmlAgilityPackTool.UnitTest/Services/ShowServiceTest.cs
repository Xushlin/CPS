using System.Collections.Generic;
using System.Linq;
using HtmlAgilityPackTool.Data;
using HtmlAgilityPackTool.Service;
using HtmlAgilityPackTool.Service.Impl;
using NUnit.Framework;
using Moq;

namespace HtmlAgilityPackTool.UnitTest.Services
{
    [TestFixture]
    public class ShowServiceTest
    {
        [Test]
        public void GetAllShows_return_all_shows()
        {
            var mockShowService = new Mock<IShowService>();
            var mockShowRespository = new Mock<IRepository<Show>>();
            var mockShowDetailRespository = new Mock<IRepository<ShowDetail>>();
           // mockShowRespository.Setup(x => x.Query()).Returns();
            var totalCount = 0;
            mockShowService.Setup(x => x.GetPage(1, ref totalCount)).Returns(new List<Show>
                {
                    new Show
                        {
                            ShowId = 5,
                            Name = "name",
                            Url = "url",
                            ChildUrl = "childurl"
                        },
                    new Show
                        {
                            ShowId = 6,
                            Name = "name",
                            Url = "url",
                            ChildUrl = "childurl"
                        },
                });
            var showService = new ShowService(mockShowRespository.Object, mockShowDetailRespository.Object);
           var show= showService.GetPage(1, ref totalCount);

           // Assert.Equals(show.Count(), 2);
        }
    }
}
