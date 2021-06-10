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
        GoogleSearchRepository _googleRepo = new GoogleSearchRepository();
        BingSearchRepository _bingRepo = new BingSearchRepository();

        public SearchService()
        {
        }

        public async Task<int> GetSearchCount(string searchString, string searchURL)
        {
            List<string> staticPages = await _googleRepo.GetSearchPages(searchString);            
            staticPages.AddRange(await _bingRepo.GetSearchPages(searchString));

            return GetCountOfSearchStringOccurenceInString(searchURL, staticPages);
        }

        private int GetCountOfSearchStringOccurenceInString(string searchURL, List<string> staticPages)
        {
            int count = 0;
            foreach (string staticPage in staticPages)
            {
                count += Regex.Matches(staticPage, searchURL).Count;
            }
            return count;
        }
    }
}
