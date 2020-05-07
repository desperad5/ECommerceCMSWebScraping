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
using ECommerceCMS.Models;
using System.Data.Entity;


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
        public WebScraperController(ILogger<WebScraperController> logger, IProductCategoryRepository productCategoryRepository, IProductRepository productRepository, IBrandRepository brandRepository)
        {
            _logger = logger;
            _productCategoryRepository = productCategoryRepository;
            _productRepository = productRepository;
            _brandRepository = brandRepository;
        }
        public List<ProductCategoryTreeModel> GetProductCategoryTree()
        {
            var model = new List<ProductCategoryTreeModel>();
            //path: '/home/left-sidebar/collection/all', title: 'makeup', type: 'link'
            _productCategoryRepository.AsQueryable().Include(c => c.ChildCategories).Load();
            var categories = _productCategoryRepository.FindBy(t => !t.IsDeleted && t.IsActive);
                
            if (categories != null && categories.Count() > 0)
            {

                var parentCategories = categories.Where(t => !t.ParentCategoryId.HasValue).ToList();
                foreach (var parentCategory in parentCategories)
                {
                    var parentCategoryModel = new ProductCategoryTreeModel() { Id = parentCategory.Id, CategoryName = parentCategory.CategoryName };
                    model.Add(parentCategoryModel);
                    if (parentCategory.ChildCategories != null && parentCategory.ChildCategories.Count > 0)
                    {
                        parentCategoryModel.ChildCategories = new List<ProductCategoryTreeModel>();
                        foreach (var childCategory in parentCategory.ChildCategories)
                        {
                            var childCategoryModel = new ProductCategoryTreeModel() { Id = childCategory.Id, CategoryName = childCategory.CategoryName };
                            parentCategoryModel.ChildCategories.Add(childCategoryModel);
                            if (childCategory.ChildCategories != null && childCategory.ChildCategories.Count > 0)
                            {
                                childCategoryModel.ChildCategories = new List<ProductCategoryTreeModel>();
                                foreach (var childsChildCategory in childCategory.ChildCategories)
                                {
                                    var childschildCategoryModel = new ProductCategoryTreeModel() { Id = childsChildCategory.Id, CategoryName = childsChildCategory.CategoryName };
                                    childCategoryModel.ChildCategories.Add(childschildCategoryModel);
                                }
                            }
                        }
                    }
                }
            }
            return model;
        }
        [HttpGet]
        public async Task<string> Get()
        {




            try
            {
                //GetProductCategoryTree();
                //Load default configuration
                var config = Configuration.Default.WithDefaultLoader();
                // Create a new browsing context
                var context = BrowsingContext.New(config);
                //UpdateProductBrands();
                //IDocument document = await FillCategories(context);

                IDocument document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/kadin-tunik-c-3549954", 4);
                document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/kadin-gomlek-bluz-c-100102", 5);
                document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/kadin-elbise-modelleri-c-100101", 6);
                document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/kadin-pantolon-modelleri-c-100105", 7);
                document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/kadin-kazak-hirka-c-100104", 8);
                document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/kadin-etek-modelleri-c-100108", 9);
                document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/kadin-ceket-yelek-c-3392072", 10);
                document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/kadin-jean-c-100109", 11);
                document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/kadin-t-shirt-modelleri-c-100107", 12);
                document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/kadin-spor-esofman-c-500103", 15);
                document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/kadin-tshirt-c-500104", 16);
                document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/kadin-bra-c-500107", 17);
                document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/kadin-sweatshirt-c-500102", 18);
                document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/kadin-tayt-c-500105", 19);
                document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/gecelik-modelleri-c-3386581", 21);
                document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/jupon--kombinezon-c-3392074", 22);
                document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/kadin-atlet-c-3386605", 23);
                document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/kadin-corap-modelleri-c-3386599", 24);
                document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/kadin-korse-c-3392075", 26);
                document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/kadin-kulot-modelleri-c-3386598", 27);
                document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/kadin-pijama-c-3392071", 28);
                document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/sabahlik-c-3386597", 29);
                document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/sutyen--c-3386589", 30);
                document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/kadin-babet-c-3546780", 32);
                document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/kadin-bot-c-3546778", 33);
                document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/kadin-duz-ayakkabi-c-3546776", 34);
                document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/kadin-sandalet-terlikleri-c-3550125", 35);
                document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/kadin-topuklu-ayakkabi-c-3546777", 36);
                document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/kadin-spor-ayakkabi-c-100403", 37);
                document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/kadin-cuzdan-c-3546800", 40);
                document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/kadin-laptop-evrak-cantasi-c-100508", 41);
                document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/kadin-omuz-cantasi-c-3546782", 42);
                document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/kadin-el-cantasi-c-3546784", 43);
                document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/kadin-sirt-cantasi-c-3546783", 44);
                document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/kadin-diger-aksesuar-c-3392780", 48);
                document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/kadin-taki-modelleri-c-100601", 49);
                document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/kadin-saat-modelleri-c-100602", 50);
                document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/kadin-gozluk-modelleri-c-100603", 51);
                document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/kadin-sal-esarp-c-100604", 52);
                document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/kadin-bere-atki-eldiven-c-100605", 53);
                document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/kadin-kemer-modelleri-c-100606", 54);

                document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/erkek-kazak-hirka-modelleri-c-200101", 56);
                document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/erkek-ceket-yelek-modelleri-c-200103", 57);
                document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/erkek-gomlek-modelleri-c-200104", 58);
                document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/erkek-pantolon-modelleri-c-200105", 59);

                document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/erkek-t-shirt-modelleri-c-200107", 60);
                document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/erkek-takim-elbise-modelleri-c-200108", 61);
                document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/erkek-jean-c-200109", 62);
                document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/erkek-esofman-c-3392758", 64);
                document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/erkek-t-shirt-modelleri-c-200107", 65);
                document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/erkek-sweatshirt-modelleri-c-200106", 66);
                document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/erkek-sort-kapri-modelleri-c-3302071", 67);
                document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/erkek-kaban-c-3392751", 69);
                document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/erkek-palto-c-3546799", 70);
                document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/erkek-trenckot-pardosu-c-3392753", 71);
                document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/erkek-mont-kaban-modelleri-c-200102", 72);
                document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/erkek-atletfanila-c-3392756", 74);
                document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/erkek-boxer-c-3392727", 75);
                document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/erkek-corap-c-3386596", 76);
                document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/erkek-pijama-modelleri-c-3386592", 77);
                document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/erkek-slip-c-3392755", 78);
                document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/erkek-bot--cizme--c-3546793", 80);
                document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/erkek-gunluk-ayakkabi-c-3546791", 81);
                document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/erkek-klasik-ayakkabi-c-3546792", 82);
                document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/erkek-sandalet-terlikleri-c-3550126", 83);
                document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/erkek-spor-ayakkabi-c-3546790", 84);
                document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/erkek-cuzdan-kartvizitlik-c-200502", 86);
                document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/erkek-laptop--evrak-cantasi-c-3546798", 87);
                document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/erkek-postaci-canta-c-200501", 88);
                document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/erkek-sirt-cantasi-c-3546797", 89);
                document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/erkek-diger-aksesuar-c-3392778", 91);
                document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/erkek-sapka-kasket-c-3392760", 92);
                document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/erkek-saat-c-200601", 93);
                document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/erkek-gozluk-c-200602", 94);
                document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/erkek-kravat-kol-dugmesi-c-200603", 95);
                document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/erkek-kemer-c-200604", 96);
                document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/erkek-atki-bere-eldiven-c-200605", 97);
                document = await InsertProductByUrlandCategoryId(context, "https://www.boyner.com.tr/erkek-kaban-c-3392751", 102);


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

        private async Task<IDocument> InsertProductByUrlandCategoryId(IBrowsingContext context, string url, int categoryId)
        {
            var document = await context.OpenAsync(url);
            // Log the data to the console
            _logger.LogInformation(document.DocumentElement.OuterHtml);

            var items = document.Body.QuerySelectorAll("div.product-list-item");
            foreach (var item in items)
            {
                var image = item.QuerySelector("div.imgDepot");
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
            var document = await context.OpenAsync("https://www.boyner.com.tr/erkek-2-c-2");
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
                    ParentCategoryId = 1,
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
