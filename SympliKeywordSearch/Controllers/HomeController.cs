using SympliKeywordSearch.Models;
using SympliKeywordSearch.Service;
using System.Linq;
using System.Web.Mvc;

namespace SympliKeywordSearch.Controllers
{
    public class HomeController : Controller
    {
        private const string SEARCH_TEXT_LINK_EMPTY = "Search Text or URL field is empty.";
        public ActionResult Index(KeywordSearchModel keywordSearchModel)
        {
            if (string.IsNullOrWhiteSpace(keywordSearchModel.Keywords) || string.IsNullOrWhiteSpace(keywordSearchModel.URL))
            {
                keywordSearchModel.Result = SEARCH_TEXT_LINK_EMPTY;
                return View(keywordSearchModel);
            }

            keywordSearchModel.Result = KeywordSearchService.Search(keywordSearchModel.Keywords, keywordSearchModel.URL);
            return View(keywordSearchModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}