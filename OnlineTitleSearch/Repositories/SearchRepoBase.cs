using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace OnlineTitleSearch.Repositories
{
    public class SearchRepoBase 
    {
        List<string> _staticURLList = null;
        private static readonly HttpClient client = new HttpClient();

        public SearchRepoBase()
        {
        }

        public async Task<string> GetSearchPageText(string searchURL)
        {
            return await client.GetStringAsync(searchURL);
        }
    }
}
