using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using HtmlAgilityPack;
using HtmlAgilityPackTool.Data;

namespace HtmlAgilityPackTool.Console
{
    public class Common
    {
        /// <summary>
        /// 根据输入的地址获取其文档节点对象
        /// </summary>
        /// <param name="url">地址</param>
        /// <returns></returns>
        public static HtmlAgilityPack.HtmlNode GetHtmlNodeFromLink(string url)
        {
            try{
                Uri uri = new Uri(url);

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
                WebResponse response = request.GetResponse();

                Stream stream = response.GetResponseStream();
                StreamReader read = new StreamReader(stream, Encoding.GetEncoding("utf-8"));
                string str = read.ReadToEnd();

                HtmlAgilityPack.HtmlDocument html = new HtmlAgilityPack.HtmlDocument();
                html.LoadHtml(str);
                return html.DocumentNode;
            }
            catch{return null;}
        }

        /// <summary>
        /// 根据输入的URL地址输出指定XPATH下的节点集合
        /// </summary>
        /// <param name="url">地址</param>
        /// <param name="xPath">过滤地址</param>
        /// <param name="imgs">过滤地址</param>
        /// <param name="links">过滤地址</param>
        /// <param name="title">标题</param>
        /// <returns></returns>
        public static  List<Show> GetGalleryInfo(HtmlAgilityPack.HtmlNode htmlNode,string xPath)
        {
            try
            {
                var shows = new List<Show>();
                HtmlNodeCollection hnc = htmlNode.SelectNodes(xPath);//"//div[@class='slideBannerA homeSlideAD1']"
                HtmlNodeCollection hnc2 = htmlNode.SelectNodes("//div/a/img");
                if (hnc.Count < 1)
                    return null;

                string cateDataRegex = @"background-image:url\((?<image>.+)\)";
                var re = new Regex(cateDataRegex, RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.IgnorePatternWhitespace);
                for (int i = 0; i < hnc.Count;i++ )
                {
                    var node1 = hnc2[i];
                    var node = hnc[i];
                    var show = new Show();
                    HtmlAttributeCollection hac = node1.Attributes;
                    String name = node.ChildNodes[1].Attributes["cover-text"].Value;
                    string childUrl = "http://www.moko.cc" + node.ChildNodes[1].ChildNodes[1].Attributes["href"].Value;
                    string href = hac["style"] == null ? hac["src2"].Value : re.Match(hac["style"].Value).Groups["image"].Value;

                    show.Url = href;
                    show.Name = name;
                    show.Publisher = node.ChildNodes[3].ChildNodes[1].InnerHtml;
                    show.Occupation = node.ChildNodes[5].ChildNodes[1].InnerHtml;
                    show.ChildUrl = childUrl;
                    show.CreateTime = DateTime.Now;
                    show.IsNew = 1;
                    shows.Add(show);
                    // string parentUrl = "http://www.moko.cc" + htc2["href"].Value;
                }
                return shows;
            }
            catch { return null; }
        }

        public static List<ShowDetail> GetDetailsGalleryInfo(HtmlAgilityPack.HtmlNode htmlNode, string xPath,int showId)
        {
            try
            {
                var shows = new List<ShowDetail>();
                HtmlNodeCollection hnc = htmlNode.SelectNodes(xPath);//"//div[@class='slideBannerA homeSlideAD1']"
               // HtmlNodeCollection hnc2 = htmlNode.SelectNodes("//div/a/img");
                if (hnc.Count < 1)
                    return null;

                string cateDataRegex = @"background-image:url\((?<image>.+)\)";
                var re = new Regex(cateDataRegex, RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.IgnorePatternWhitespace);
                for (int i = 0; i < hnc.Count; i++)
                {
                    //var node1 = hnc2[i];
                    var node = hnc[i];
                    var show = new ShowDetail();
                    HtmlAttributeCollection hac = node.Attributes;
                    String name = hac["title"].Value;
                    string href = hac["style"] == null ? hac["src2"].Value : re.Match(hac["style"].Value).Groups["image"].Value;

                    show.Url = href;
                    show.Name = name;
                    show.ShowId = showId;
                    show.CreateTime = DateTime.Now;
                    shows.Add(show);
                    // string parentUrl = "http://www.moko.cc" + htc2["href"].Value;
                }
                return shows;
            }
            catch { return null; }
        }

        public static List<ShowDetail> GetWeiboGalleryInfo(HtmlAgilityPack.HtmlNode htmlNode, string xPath, int showId)
        {
            try
            {
                var shows = new List<ShowDetail>();
                HtmlNodeCollection hnc = htmlNode.SelectNodes(xPath);//"//div[@class='slideBannerA homeSlideAD1']"
                // HtmlNodeCollection hnc2 = htmlNode.SelectNodes("//div/a/img");
                if (hnc.Count < 1)
                    return null;

                string cateDataRegex = @"background-image:url\((?<image>.+)\)";
                var re = new Regex(cateDataRegex, RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.IgnorePatternWhitespace);
                for (int i = 0; i < hnc.Count; i++)
                {
                    //var node1 = hnc2[i];
                    var node = hnc[i];
                    var show = new ShowDetail();
                    HtmlAttributeCollection hac = node.Attributes;
                   // String name = hac["alt"].Value;
                    string href = hac["style"] == null ? hac["src"].Value : re.Match(hac["style"].Value).Groups["image"].Value;

                    show.Url = href;
                    //show.Name = name;
                    show.ShowId = showId;
                    show.CreateTime = DateTime.Now;
                    shows.Add(show);
                    // string parentUrl = "http://www.moko.cc" + htc2["href"].Value;
                }
                return shows;
            }
            catch { return null; }
        }
    
    }
}
