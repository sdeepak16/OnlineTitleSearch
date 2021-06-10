using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineTitleSearch.Services;

namespace OnlineTitleSearch.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OnlineTitleSearchController : ControllerBase
    {
        ISearchService _searchService;

        // hard coded, not dependent on the input data, even though the correct data is passsed
        string _searchString = "online title search";
        string _searchURL = "<a href=\"https://www.infotrack.com.au";

        public OnlineTitleSearchController(ISearchService searchService)
        {
            _searchService = searchService;
        }
                
        [HttpGet]
        public async Task<ActionResult<string>> GetSearchCount(string searchString, string searchURL)
        {
            int count = await _searchService.GetSearchCount(_searchString, _searchURL);          
            return count.ToString();
        }

    }
}
