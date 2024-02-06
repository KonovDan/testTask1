

namespace testTask1.Models
{
    public class Link
    {
        public int Id { get; set; }
        public string baseUrl { get; set; }
        public string shortUrl { get; set; }

        public Link(string baseUrl, string shortUrl)
        {
            this.baseUrl = baseUrl;
            this.shortUrl = shortUrl;

        }
    }
}
