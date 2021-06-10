using OnlineTitleSearch.Controllers;
using OnlineTitleSearch.Repositories;
using OnlineTitleSearch.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace OnlineTitleSearchTest
{
   
    public class OnlineTitleSearchControllerTest
    {
        [Theory]       
        [InlineData("online title search", "<a href=\"https://www.infotrack.com.au")]
        public async System.Threading.Tasks.Task Should_Return_NonZeroResultAsync(string searchString, string searchURL)
        {
            SearchService searchService = new SearchService();
            int count = await searchService.GetSearchCount(searchString, searchURL);
                        
            Assert.NotEqual(count, -1);
            Assert.Equal(count, 2);
        }
    }
}
