using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineTitleSearch.Repositories
{
    public interface ISearchRepository
    {
        Task<string> GetSearchPageText(string searchURL);
    }
}
