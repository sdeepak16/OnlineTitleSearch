using System.Net.Http;
using System.Threading.Tasks;

namespace OnlineTitleSearch.Repositories
{
    public class SearchRepository : ISearchRepository
    {
        private static readonly HttpClient client = new HttpClient();
        public async Task<string> GetSearchPageText(string searchURL)
        {
            return await client.GetStringAsync(searchURL);            
        }
    }
}
