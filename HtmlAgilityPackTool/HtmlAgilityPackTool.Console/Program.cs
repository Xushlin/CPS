using System;
using System.Collections.Generic;
using System.Linq;
using HtmlAgilityPackTool.Data;

namespace HtmlAgilityPackTool.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                System.Console.WriteLine("请输入适当的选项：");
                System.Console.WriteLine("1.解析主界面上的信息.");
                System.Console.WriteLine("2.解析子界面上的信息.");
                System.Console.WriteLine("3.解析新浪微博中国美腿群的图片");
                System.Console.WriteLine("exit.退出界面.");
                string input = System.Console.ReadLine();
                if (input == "exit")
                    break;
                switch (input)
                {
                    case "1":
                        DownloadHome();
                        break;
                    case "2":
                        DownloadDetails();
                        break;
                    case "3":
                        DownloadSinaImage();
                        break;
                }
            }
            System.Console.ReadKey();
        }

        private static void DownloadHome()
        {
            const string urls = "http://www.moko.cc/moko/post/{0}.html";
            var entites = new MokoEntities();
            var existe = entites.Shows.ToList();
            for (int i = 1; i <= 10; i++)
            {
                var nodes = Common.GetHtmlNodeFromLink(String.Format(urls, i)); ////div[@class='w970']/ul/div/a/img
                var shows = Common.GetGalleryInfo(nodes, "//div[@class='w970']/ul");
               
                foreach (var show in shows)
                {
                    if(existe.Any(x=>x.Url.Equals(show.Url)))
                        continue;

                    entites.Shows.Add(show);
                    entites.SaveChanges();
                    System.Console.WriteLine(show.Url);
                }
            }
        }

        private static void DownloadDetails()
        {
            var mokoEntities = new MokoEntities();
            var shows = mokoEntities.Shows.Where(x=>x.IsNew==1).ToList();
            foreach(Show show in shows)
            {
                var nodes = Common.GetHtmlNodeFromLink(show.ChildUrl); ////div[@class='w970']/ul/div/a/img
                var showDetail = Common.GetDetailsGalleryInfo(nodes, "//p[@class='picBox']/img",show.ShowId);
                foreach (var detail in showDetail)
                {
                    mokoEntities.ShowDetails.Add(detail);
                    mokoEntities.SaveChanges();
                    System.Console.WriteLine(detail.Url);
                }
            }
        }

        private static void DownloadSinaImage()
        {
            string url = "http://photo.weibo.com/2780152823/talbum/index?from=profile_wb#!/mode/1/page/{0}";
            //string url = "http://photo.weibo.com/2780152823/talbum/index#!/mode/1/page/{0}";
            var mokoEntities = new MokoEntities();
            for (int i = 1; i <= 35; i++)
            {
                var nodes = Common.GetHtmlNodeFromLink(String.Format(url, i)); ////div[@class='w970']/ul/div/a/img
                var showDetail = Common.GetWeiboGalleryInfo(nodes, "//dt[@class='photo']/img", 0);
                foreach (var detail in showDetail)
                {
                    mokoEntities.ShowDetails.Add(detail);
                    mokoEntities.SaveChanges();
                    System.Console.WriteLine(detail.Url);
                }
            }
           
        }
    }
}
