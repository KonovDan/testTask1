using Microsoft.AspNetCore.Mvc;

using testTask1.Models;

using System.Security.Cryptography;
using System.Text;

namespace testTask1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet,HttpPost]
        public IActionResult Index(string? url)
        {
            string shortURL = "http://localhost:7095/";
            SHA1 sha1 = SHA1.Create();
            if (url != null) {
                using (Context context = new Context()) {
                    do
                    {
                        string hash = Convert.ToHexString(sha1.ComputeHash(Encoding.ASCII.GetBytes(url)));
                        shortURL += hash.Remove(5, hash.Length - 5);
                        Link link = new Link(url, shortURL);
                        context.Links.Add(link);
                        context.SaveChanges();
                    } while (context.Links.Where((Link link) => link.shortUrl.Substring(22).Equals(shortURL)).Count() != 0);
                }
                return View((object?)shortURL);
            }

            return View();
        }

    }
}