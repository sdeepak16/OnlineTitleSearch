using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace OnlineTitleSearch.Repositories
{
    public class GoogleSearchRepository : SearchRepoBase
    {
        private static readonly HttpClient client = new HttpClient();

        // List of static pages to search from
        // First 5 as only first 50 results need to be checked
        List<string> _URLList = new List<string>()
        {
            "https://infotrack-tests.infotrack.com.au/Google/Page01.html",
            "https://infotrack-tests.infotrack.com.au/Google/Page02.html",
            "https://infotrack-tests.infotrack.com.au/Google/Page03.html",
            "https://infotrack-tests.infotrack.com.au/Google/Page04.html",
            "https://infotrack-tests.infotrack.com.au/Google/Page05.html"
        };
        
        public GoogleSearchRepository() 
        {
        }

        public async Task<List<string>> GetSearchPages(string searchString)
        {
            // get the List of strings from each of first 5 Static URLs
            // TODO add more smarts to look at the pages to see how many results return per page
            List<string> staticPages = new List<string>();
            foreach (string url in _URLList)
            {
                staticPages.Add(await GetSearchPageText(url));
            }

            return staticPages;
        }
    }
}
