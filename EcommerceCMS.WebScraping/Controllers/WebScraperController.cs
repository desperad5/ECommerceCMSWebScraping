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
using AngleSharp.Dom;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EcommerceCMS.WebScraping.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class WebScraperController : ControllerBase
    {
        private readonly ILogger<WebScraperController> _logger;
        private IProductCategoryRepository _productCategoryRepository;
        private IProductRepository _productRepository;
        // GET: /<controller>/
        public WebScraperController(ILogger<WebScraperController> logger,IProductCategoryRepository productCategoryRepository,IProductRepository productRepository)
        {
            _logger = logger;
            _productCategoryRepository = productCategoryRepository;
            _productRepository = productRepository;
        }
        [HttpGet]
        public async Task<string> Get()
        {
            // Load default configuration
            var config = Configuration.Default.WithDefaultLoader();
            // Create a new browsing context
            var context = BrowsingContext.New(config);
            //https://www.boyner.com.tr/kadin-c-1

            //IDocument document = await FillCategories(context);
            //IDocument document=await FillGomleks(context);
            //IDocument document = await FillPants(context);
            IDocument document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/erkek-t-shirt-modelleri-c-200107",93);
            document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/erkek-takim-elbise-modelleri-c-200108",94);
            document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/erkek-jean-c-200109",95);
            document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/erkek-esofman-c-3392758",97);
            document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/erkek-t-shirt-modelleri-c-200107",98);         
            document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/erkek-sweatshirt-modelleri-c-200106",99);
            document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/erkek-sort-kapri-modelleri-c-3302071", 100);
            //document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/erkek-jean-c-200109", 95);
            //document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/erkek-jean-c-200109", 95);
            //document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/erkek-jean-c-200109", 95);
            //document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/erkek-jean-c-200109", 95);
            //document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/erkek-jean-c-200109", 95);
            //document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/erkek-jean-c-200109", 95);
            //document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/erkek-jean-c-200109", 95);
            //document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/erkek-jean-c-200109", 95);
            //document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/erkek-jean-c-200109", 95);
            //document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/erkek-jean-c-200109", 95);
            //document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/erkek-jean-c-200109", 95);
            //document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/erkek-jean-c-200109", 95);
            //document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/erkek-jean-c-200109", 95);
            //document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/erkek-jean-c-200109", 95);
            //document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/erkek-jean-c-200109", 95);

            return "Hello";
        }

        
        private async Task<IDocument> InsertProductByUrlandCategoryId(IBrowsingContext context,string url,int categoryId)
        {
            var document = await context.OpenAsync(url);
            // Log the data to the console
            _logger.LogInformation(document.DocumentElement.OuterHtml);

            var items = document.Body.QuerySelectorAll("div.product-list-item");
            foreach (var item in items)
            {
                var image = document.Body.QuerySelector("div.imgDepot");
                var imgUrl = image.QuerySelectorAll("div")[0].GetAttribute("data-imgitem").Trim();
                var name = item.QuerySelectorAll("div.product-info span.product-name")[0].TextContent;
                var price = Convert.ToDouble(item.QuerySelector("div.product-info div.price-container ins.price-payable").TextContent.Split(" ")[0]);
                _productRepository.AddWithCommit(new ECommerceCMS.Data.Entity.Product()
                {
                    BaseImageUrl = imgUrl,
                    TenantId = 1,
                    IsActive = true,
                    IsDeleted = false,
                    Name = name,
                    Price = price,
                    ProductCategoryId = categoryId,

                });
            }
            return document;
        }

        private async Task<IDocument> FillCategories(IBrowsingContext context)
        {
            var document = await context.OpenAsync("https://www.boyner.com.tr/kadin-c-1");
            // Log the data to the console
            _logger.LogInformation(document.DocumentElement.OuterHtml);
            var parentCategories = document.Body.QuerySelectorAll("div.sidebar-box h5 a.navLink");
            foreach (var parentCategory in parentCategories)
            {
                //insert into db
                var childCategories = parentCategory.ParentElement.ParentElement.QuerySelectorAll("ul li a.navLink");
                var parCategory = _productCategoryRepository.AddWithCommit(new ECommerceCMS.Data.Entity.ProductCategory()
                {
                    IsDeleted = false,
                    CategoryName = parentCategory.TextContent.Trim(),
                    ParentCategoryId = 40,
                    IsActive = true,
                    TenantId = 1
                });
                foreach (var childCategory in childCategories)
                {
                    var text = childCategory.TextContent;
                    _productCategoryRepository.AddWithCommit(new ECommerceCMS.Data.Entity.ProductCategory()
                    {
                        IsDeleted = false,
                        CategoryName = text.Trim(),
                        ParentCategoryId = parCategory.Id,
                        IsActive = true,
                        TenantId = 1
                    });
                }
            }

            return document;
        }
    }
}
