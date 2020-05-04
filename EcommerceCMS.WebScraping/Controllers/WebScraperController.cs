using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AngleSharp;
using AngleSharp.Html.Parser;
using ECommerceCMS.Service;
using ECommerceCMS.Service.Abstract;
using ECommerceCMS.Data.Abstract;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EcommerceCMS.WebScraping.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class WebScraperController : ControllerBase
    {
        private readonly ILogger<WebScraperController> _logger;
        private IProductCategoryRepository _productCategoryRepository;
        // GET: /<controller>/
        public WebScraperController(ILogger<WebScraperController> logger,IProductCategoryRepository productCategoryRepository)
        {
            _logger = logger;
            _productCategoryRepository = productCategoryRepository;
        }
        [HttpGet]
        public async Task<string> Get()
        {
            // Load default configuration
            var config =Configuration.Default.WithDefaultLoader();
            // Create a new browsing context
            var context = BrowsingContext.New(config);
            // This is where the HTTP request happens, returns <IDocument> that // we can query later
            var document = await context.OpenAsync("https://www.boyner.com.tr/erkek-2-c-2");
            // Log the data to the console
            _logger.LogInformation(document.DocumentElement.OuterHtml);
            var advertrows = document.Body.QuerySelectorAll("div.sidebar-box ul li a.navLink");
            foreach (var row in advertrows)
            {
                var text = row.TextContent;
                _productCategoryRepository.AddWithCommit(new ECommerceCMS.Data.Entity.ProductCategory()
                {
                    IsDeleted = false,
                    CategoryName = row.TextContent.Trim(),
                    ParentCategoryId=2,
                    IsActive=true,
                    TenantId=1
                }) ;
            }
                return "Hello";
        }
    }
}
