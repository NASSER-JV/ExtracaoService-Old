using System.Collections.Generic;

namespace ExtracaoService.Data.Entities
{
    public class NewsModel
    {
        public List<News> news { get; set; }
    }

    public class News
    {
        public string symbol { get; set; }
        public string publishedDate { get; set; }
        public string title { get; set; }
        public string image { get; set; }
        public string site { get; set; }
        public string text { get; set; }
        public string url { get; set; }
    }
}