using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineTitleSearch.Services;

namespace OnlineTitleSearch.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OnlineTitleSearch : ControllerBase
    {
        ISearchService _searchService;

        public OnlineTitleSearch(ISearchService searchService)
        {
            _searchService = searchService;
        }
                
        [HttpGet]
        public async Task<ActionResult<string>> GetSearchCount(string searchString, string searchURL)
        {
            return await _searchService.GetSearchCount(searchString, searchURL);
        }

    }
}
