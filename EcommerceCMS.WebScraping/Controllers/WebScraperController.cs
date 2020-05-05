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
        private IBrandRepository _brandRepository;
        // GET: /<controller>/
        public WebScraperController(ILogger<WebScraperController> logger, IProductCategoryRepository productCategoryRepository, IProductRepository productRepository,IBrandRepository brandRepository)
        {
            _logger = logger;
            _productCategoryRepository = productCategoryRepository;
            _productRepository = productRepository;
            _brandRepository = brandRepository;
        }
        [HttpGet]
        public async Task<string> Get()
        {
            
            

            
            try
            {
                //Load default configuration
                var config = Configuration.Default.WithDefaultLoader();
                // Create a new browsing context
                var context = BrowsingContext.New(config);
                //UpdateProductBrands();
                //IDocument document = await FillCategories(context);

                //IDocument document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/erkek-t-shirt-modelleri-c-200107",93);
                //document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/erkek-takim-elbise-modelleri-c-200108",94);
                //document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/erkek-jean-c-200109",95);
                //document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/erkek-esofman-c-3392758",97);
                //document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/erkek-t-shirt-modelleri-c-200107",98);         
                //document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/erkek-sweatshirt-modelleri-c-200106",99);
                //document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/erkek-sort-kapri-modelleri-c-3302071", 100);
                //IDocument document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/erkek-kaban-c-3392751", 102);
                //document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/erkek-palto-c-3546799", 103);
                //document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/erkek-trenckot-pardosu-c-3392753", 104);
                //document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/erkek-mont-kaban-modelleri-c-200102", 105);
                //document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/erkek-atletfanila-c-3392756", 107);
                //document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/erkek-boxer-c-3392727", 108);
                //document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/erkek-corap-c-3386596", 109);
                //document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/erkek-pijama-modelleri-c-3386592", 110);
                //document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/erkek-slip-c-3392755", 111);
                //document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/erkek-bot--cizme--c-3546793", 113);
                //document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/erkek-gunluk-ayakkabi-c-3546791", 114);
                //document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/erkek-klasik-ayakkabi-c-3546792", 115);
                //document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/erkek-sandalet-terlikleri-c-3550126", 116);
                //document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/erkek-spor-ayakkabi-c-3546790", 117);
                //document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/erkek-cuzdan-kartvizitlik-c-200502", 119);
                //document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/erkek-laptop--evrak-cantasi-c-3546798", 120);
                //document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/erkek-postaci-canta-c-200501", 121);
                //document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/erkek-sirt-cantasi-c-3546797", 122);
                //document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/erkek-diger-aksesuar-c-3392778", 124);
                //document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/erkek-sapka-kasket-c-3392760", 125);
                //document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/erkek-saat-c-200601", 126);
                //document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/erkek-gozluk-c-200602", 127);
                //document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/erkek-kravat-kol-dugmesi-c-200603", 128);
                //document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/erkek-kemer-c-200604", 129);
                //document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/erkek-atki-bere-eldiven-c-200605", 130);
                //document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/erkek-kaban-c-3392751", 102);
                //IDocument document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/kadin-tunik-c-3549954", 132);
                //document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/kadin-gomlek-bluz-c-100102", 133);
                //document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/kadin-elbise-modelleri-c-100101", 134);
                //document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/kadin-pantolon-modelleri-c-100105", 135);
                //document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/kadin-kazak-hirka-c-100104", 136);
                //document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/kadin-etek-modelleri-c-100108", 137);
                //document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/kadin-ceket-yelek-c-3392072", 138);
                //document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/kadin-jean-c-100109", 139);
                //document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/kadin-t-shirt-modelleri-c-100107", 140);
                //document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/kadin-spor-esofman-c-500103", 143);
                //document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/kadin-tshirt-c-500104", 144);
                //document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/kadin-bra-c-500107", 145);
                //document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/kadin-sweatshirt-c-500102", 146);
                //document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/kadin-tayt-c-500105", 147);
                //document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/gecelik-modelleri-c-3386581", 149);
                //document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/jupon--kombinezon-c-3392074", 150);
                //document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/kadin-atlet-c-3386605", 151);
                //document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/kadin-corap-modelleri-c-3386599", 152);
                //document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/kadin-korse-c-3392075", 154);
                //document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/kadin-kulot-modelleri-c-3386598", 155);
                //document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/kadin-pijama-c-3392071", 156);
                //document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/sabahlik-c-3386597", 157);
                //document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/sutyen--c-3386589", 158);
                //document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/kadin-babet-c-3546780", 160);
                //document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/kadin-bot-c-3546778", 161);
                //document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/kadin-duz-ayakkabi-c-3546776", 162);
                //document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/kadin-sandalet-terlikleri-c-3550125", 163);
                //document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/kadin-topuklu-ayakkabi-c-3546777", 164);
                //document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/kadin-spor-ayakkabi-c-100403", 165);
                //document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/kadin-cuzdan-c-3546800", 168);
                //document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/kadin-laptop-evrak-cantasi-c-100508", 169);
                //document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/kadin-omuz-cantasi-c-3546782", 170);
                //document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/kadin-el-cantasi-c-3546784", 171);
                //document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/kadin-sirt-cantasi-c-3546783", 172);
                //document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/kadin-diger-aksesuar-c-3392780", 176);
                //document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/kadin-taki-modelleri-c-100601", 177);
                //document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/kadin-saat-modelleri-c-100602", 178);
                //document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/kadin-gozluk-modelleri-c-100603", 179);
                //document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/kadin-sal-esarp-c-100604", 180);
                //document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/kadin-bere-atki-eldiven-c-100605", 181);
                //document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/kadin-kemer-modelleri-c-100606", 182);

            }
            catch (Exception ex)
            {
                var a = ex;
            }
            return "Hello";
        }

        private void UpdateProductBrands()
        {
            var products = _productRepository.GetAll().ToList();
            foreach (var product in products)
            {
                var brandName = product.Name.Split(" ")[0].ToLowerInvariant();
                var brand = _brandRepository.GetSingle(t => t.Name == brandName);
                if (brand == null)
                {
                    brand = _brandRepository.AddWithCommit(new ECommerceCMS.Data.Entity.Brand()
                    {
                        Name = brandName,
                        IsActive = true,
                        IsDeleted = false,

                    });
                }
                product.BrandId = brand.Id;
                _productRepository.Update(product);
                _productRepository.Commit();


            }
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
