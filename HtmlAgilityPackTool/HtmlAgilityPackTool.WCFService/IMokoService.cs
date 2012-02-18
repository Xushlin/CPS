using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using HtmlAgilityPackTool.WCFService.Contract;

namespace HtmlAgilityPackTool.WCFService
{
    
    [ServiceContract]
    public interface IMokoService
    {
         [WebInvoke(UriTemplate = "Shows", Method = "GET")]
        ShowList GetShows();
    }
}
