using System.Threading.Tasks;
using System.Web.Mvc;
using RssReader.Models;
using RssReader.Utils;

namespace RssReader.Controllers
{
    public class RssReaderController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View("RssReader");
        }

        [HttpGet]
        public async Task<ActionResult> GetFeed(string url)
        {
            //const string url = "http://blog.aweber.com/feed";
            //const string url = "https://techcrunch.com/feed/";

            var xmlResult = await XMLDownloader.GetRssFeedAsync<RssXml>(url);

            return PartialView("_Feed", xmlResult.GetFeed());
        }
    }
}