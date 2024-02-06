using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using testTask1.Models;
namespace testTask1.Controllers
{
    public class DynamicController : Controller
    {
        public ActionResult Index(string shortURL)
        {
            using(Context context = new Context())
            {
                List<Link> URLs = context.Links.Where((Link link) => link.shortUrl.Substring(22).Equals(shortURL)).ToList();
                if(URLs.Count > 0) return Redirect(URLs[0].baseUrl);
            }
            return Redirect("http://google.com");
        }
    }
}
