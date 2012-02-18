using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace HtmlAgilityPackTool.WCFService.Contract
{
    [DataContract]
    public class Show
    {
        [DataMember]
        public int ShowId { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Url { get; set; }
        [DataMember]
        public string Occupation { get; set; }
        [DataMember]
        public string Publisher { get; set; }
        [DataMember]
        public DateTime? CreateTime { get; set; }
        [DataMember]
        public DateTime? PublishedDate { set; get; }
        [DataMember]
        public string ChildUrl { get; set; }
        [DataMember]
        public int? IsNew { get; set; }
    }

    [DataContract]
    public class ShowList
    {
        public List<Show> Shows { get; set; }
    }
}