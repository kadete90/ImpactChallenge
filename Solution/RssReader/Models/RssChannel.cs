using System.Collections.Generic;

namespace RssReader.Models
{
    public class RssChannel
    {
        public RssChannel()
        {
            Feeds = new List<Feed>();
        }

        public string Title { get; set; }
        public string Description { get; set; }

        public List<Feed> Feeds { get; set; }

        public class Feed
        {
            public string Title { get; set; }
            public string PubDate { get; set; }
            public string Link { get; set; }
        }
    }
}