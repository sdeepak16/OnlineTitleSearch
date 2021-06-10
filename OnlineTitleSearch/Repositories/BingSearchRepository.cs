using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineTitleSearch.Repositories
{
    public class BingSearchRepository : SearchRepoBase, ISearchRepository
    {
        // List of static pages to search from     
        // First 5 as only first 50 results need to be checked
        List<string> _URLList = new List<string>()
        {
            "https://infotrack-tests.infotrack.com.au/Bing/Page01.html",
            "https://infotrack-tests.infotrack.com.au/Bing/Page02.html",
            "https://infotrack-tests.infotrack.com.au/Bing/Page03.html",
            "https://infotrack-tests.infotrack.com.au/Bing/Page04.html",
            "https://infotrack-tests.infotrack.com.au/Bing/Page05.html"
        };

        public BingSearchRepository()
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
