using RssReader.Models;

namespace RssReader.Utils
{
    public static class Extensions
    {
        public static RssChannel GetFeed(this RssXml rssXml)
        {
            var rssChannel = new RssChannel
            {
                Title = rssXml.channel.title,
                Description = rssXml.channel.description
            };

            foreach (var item in rssXml.channel.item)
            {
                rssChannel.Feeds.Add(new RssChannel.Feed
                {
                    Title = item.title,
                    PubDate = item.pubDate,
                    Link = item.link
                });
            }
            return rssChannel;
        }
    }
}