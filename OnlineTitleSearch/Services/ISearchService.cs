using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineTitleSearch.Services
{
    public interface ISearchService
    {
        Task<int> GetSearchCount(string searchString, string searchURL);
    }
}
