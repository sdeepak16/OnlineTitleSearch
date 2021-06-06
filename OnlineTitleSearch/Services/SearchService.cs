using OnlineTitleSearch.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace OnlineTitleSearch.Services
{
    public class SearchService : ISearchService
    {
        ISearchRepository _searchRepo;
        
        // List of static pages to search from
        List<string> _staticURLList = new List<string>()
        {
            "https://infotrack-tests.infotrack.com.au/Google/Page01.html",
            "https://infotrack-tests.infotrack.com.au/Google/Page02.html",
            "https://infotrack-tests.infotrack.com.au/Google/Page03.html",
            "https://infotrack-tests.infotrack.com.au/Google/Page04.html",
            "https://infotrack-tests.infotrack.com.au/Google/Page05.html",
            "https://infotrack-tests.infotrack.com.au/Google/Page06.html",
            "https://infotrack-tests.infotrack.com.au/Google/Page07.html",
            "https://infotrack-tests.infotrack.com.au/Google/Page08.html",
            "https://infotrack-tests.infotrack.com.au/Google/Page09.html",
            "https://infotrack-tests.infotrack.com.au/Google/Page10.html"
        };

        string _searchString = "<a href=\"https://www.infotrack.com.au";

        public SearchService(ISearchRepository searchRepo)
        {
            _searchRepo = searchRepo;
        }

        public async Task<string> GetSearchCount(string searchString, string searchURL)
        {
            // get the List of strings from each of first 5 Static URLs 
            // TODO add more smarts to look at the pages to see how many results return per page
            List<string> staticPages = new List<string>();
            foreach(string url in _staticURLList)
            {
                staticPages.Add(await _searchRepo.GetSearchPageText(url));
            }

            // using hardcoded search string for searching 
            return GetCountOfSearchStringOccurenceInString(_searchString, staticPages).ToString();
        }
        
        private int GetCountOfSearchStringOccurenceInString(string searchString, List<string> staticPages)
        {
            int count = 0;
            foreach(string staticPage in staticPages)
            {
                count += Regex.Matches(staticPage, searchString).Count;
            }
            return count;
        }
    }
}
