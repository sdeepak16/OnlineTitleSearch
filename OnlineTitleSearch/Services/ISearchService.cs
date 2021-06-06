using System.Threading.Tasks;

namespace OnlineTitleSearch.Services
{
    public interface ISearchService
    {
        Task<string> GetSearchCount(string searchString, string searchURL);
    }
}
