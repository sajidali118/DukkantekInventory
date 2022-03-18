using Dukkantek.Repo.Interfaces.Products;
using Dukkantek.ViewModel.Products.Sell;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;

namespace DukkantekInventory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class ProductController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IProductsRepository _productsRepo;
        public ProductController(ILoggerFactory _logger, IProductsRepository productsRepo)
        {
            this._logger = _logger.CreateLogger<ProductController>();
            this._productsRepo = productsRepo;
        }

        [HttpGet, Route("GetCategories")]
        public async Task<IActionResult> Categories()
        {

            var categories = await _productsRepo.GetAllCategories();

            if (categories != null && categories.Count() > 0)
            {
                _logger.LogInformation($"Product Service : Categories: {categories.Count()} record found.");
                return Ok(categories);
            }
            else
            {
                _logger.LogWarning($"Product Service : Categories: No record found.");
                return NotFound();
            }

        }

        [HttpGet, Route("GetProductStatuses")]
        public async Task<IActionResult> Statuses()
        {
            var productStatuses = await _productsRepo.GetProductStatuses();

            if (productStatuses != null && productStatuses.Count() > 0)
            {
                _logger.LogInformation($"Product Service : Statuses: {productStatuses.Count()} record found.");
                return Ok(productStatuses);
            }
            else
            {
                _logger.LogWarning($"Product Service : Statuses: No record found.");
                return NotFound();
            }
        }

        [HttpGet, Route("GetAllProducts")]
        public async Task<IActionResult> Products()
        {
            var products = await _productsRepo.GetAllProducts();

            if (products != null && products.Count() > 0)
            {
                _logger.LogInformation($"Product Service : Products: {products.Count()} record found.");
                return Ok(products);
            }
            else
            {
                _logger.LogWarning($"Product Service : Products: No record found.");
                return NotFound();
            }
        }

        [HttpGet, Route("GetProductCounts")]
        public async Task<IActionResult> ProductCounts()
        {
            var productCounts = await _productsRepo.GetProductsCount();

            if (productCounts != null)
            {
                _logger.LogInformation($"Product Service : ProductCounts: Products record found.");
                return Ok(productCounts);
            }
            else
            {
                _logger.LogWarning($"Product Service : ProductCounts: No record found.");
                return NotFound();
            }
        }

        [HttpPost, Route("SellProduct")]
        public async Task<IActionResult> SellProduct(ProductSellViewModel product)
        {
            if (product != null && product.ProductId > 0 && product.Price > 0 && !string.IsNullOrEmpty(product.CustomerName))
            {
                var productSell = await _productsRepo.SellProduct(product);

                if (productSell == 200)
                {
                    _logger.LogInformation($"Product Service : SellProduct: Product sold successfully.");
                    return Ok("Product sold successfully.");
                }
                else
                {
                    _logger.LogWarning($"Product Service : SellProduct: Fail to sell product : {product.ProductId}");
                    return BadRequest($"Fail to sell product : {product.ProductId}");
                }
            }
            else
            {
                return BadRequest("Mandatory parameters are required.");
            }
        }

        [HttpPost, Route("UpdateProductStatus")]
        public async Task<IActionResult> UpdateProductStatus(ProductStatusChangeViewModel productStatus)
        {
            if (productStatus != null && productStatus.ProductId > 0 && productStatus.StatusId > 0)
            {
                var productSell = await _productsRepo.UpdateProductStatus(productStatus);

                if (productSell == 200)
                {
                    _logger.LogInformation($"Product Service : UpdateProductStatus: Product status updated successfully.");
                    return Ok("Product status updated successfully.");
                }
                else
                {
                    _logger.LogWarning($"Product Service : UpdateProductStatus: Fail to update product {productStatus.ProductId} status");
                    return BadRequest($"Fail to update product {productStatus.ProductId} status");
                }
            }
            else
            {
                return BadRequest("Mandatory parameters are required.");
            }
        }
    }
}
