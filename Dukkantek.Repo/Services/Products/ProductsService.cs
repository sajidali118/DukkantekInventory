using Dukkantek.Domain.Models.Products;
using Dukkantek.Domain.Utilities;
using Dukkantek.Repo.Data;
using Dukkantek.Repo.Interfaces.Products;
using Dukkantek.ViewModel.Categories;
using Dukkantek.ViewModel.MetaData;
using Dukkantek.ViewModel.Products;
using Dukkantek.ViewModel.Products.Sell;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Dukkantek.Domain.Utilities.EnumsData;

namespace Dukkantek.Repo.Services.Products
{
    public class ProductsService : IProductsRepository
    {
        private readonly ILogger _logger;
        private readonly IRepository<Product> _productRepo;
        private readonly IRepository<ProductSell> _productSellRepo;
        private readonly IRepository<Category> _categoryRepo;

        public ProductsService(ILoggerFactory _logger, IRepository<Product> productRepo, IRepository<ProductSell> productSellRepo,
            IRepository<Category> categoryRepo
                               )
        {
            this._logger = _logger.CreateLogger<ProductsService>();
            this._productRepo = productRepo;
            this._productSellRepo = productSellRepo;
            this._categoryRepo = categoryRepo;
        }

        public async Task<List<CategoryViewModel>> GetAllCategories()
        {
            List<CategoryViewModel> allCategories = new List<CategoryViewModel>();
            var result = _categoryRepo.GetAll().Where(x => x.IsDeleted == false).ToList();

            if (result != null && result.Count() > 0)
            {
                foreach (var item in result)
                {
                    allCategories.Add(new CategoryViewModel()
                    {
                        Id = item.Id,
                        Name = item.Name,
                        ShortName = item.ShortName,
                    });
                }
            }
            return await Task.Run(() => allCategories);
        }

        public async Task<List<ProductViewModel>> GetAllProducts()
        {
            List<ProductViewModel> allProducts = new List<ProductViewModel>();
            var result = _productRepo.GetAll()
                .IncludeMultiple(x => x.Category).Where(x => x.IsDeleted == false).ToList();

            if (result != null && result.Count() > 0)
            {
                foreach (var item in result)
                {
                    allProducts.Add(new ProductViewModel()
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Barcode = item.Barcode,
                        Description = item.Description,
                        Weight = item.Weight,
                        CategoryId = item.CategoryId,
                        Category = item.Category != null && item.Category.Id > 0 ? item.Category.Name : null,
                        StatusId = (Int32)item.Status,
                        Status = Convert.ToInt32(item.Status) > 0 ? EnumExtensionsMethod.GetDisplay((ProductStatus)Enum.Parse(typeof(ProductStatus), item.Status.ToString())) : "",
                    });
                }
            }
            return await Task.Run(() => allProducts);
        }

        public async Task<ProductCountViewModel> GetProductsCount()
        {
            ProductCountViewModel productCount = new ProductCountViewModel();
            var result = _productRepo.GetAll().Where(x => x.IsDeleted == false).ToList();
            if (result != null && result.Count > 0)
            {
                productCount.InStock = result.Where(x => x.Status == ProductStatus.INSTOCK).Count();
                productCount.Sold = result.Where(x => x.Status == ProductStatus.SOLD).Count();
                productCount.Damaged = result.Where(x => x.Status == ProductStatus.DAMAGED).Count();
            }

            return await Task.Run(() => productCount);

        }

        public async Task<List<MetaDataViewModel>> GetProductStatuses()
        {

            List<MetaDataViewModel> productStatuses = ((ProductStatus[])Enum.GetValues(typeof(ProductStatus)))
                            .Select(c => new MetaDataViewModel()
                            {
                                Id = (int)c,
                                Name = EnumExtensionsMethod.GetDisplay((ProductStatus)Enum.Parse(typeof(ProductStatus), c.ToString())),
                            }).ToList();

            return await Task.Run(() => productStatuses);

        }

        public async Task<int> SellProduct(ProductSellViewModel productSell)
        {
            try
            {

                var productExists = await _productRepo.GetById(productSell.ProductId.Value);

                if (productExists == null || productExists.Id <= 0)
                {
                    _logger.LogError($"Error : No record found with product: ID: {productSell.ProductId}");
                    return 1001;
                }

                ProductSell sell = new ProductSell()
                {
                    ProductId = productSell.ProductId,
                    CustomerName = productSell.CustomerName,
                    Price = productSell.Price,
                    Description = productSell.Description

                };

                var newSellId = await _productSellRepo.Create(sell);
                if (newSellId > 0)
                {
                    productExists.Status = ProductStatus.SOLD;
                    await _productRepo.Update(productExists.Id, productExists);
                }
                return 200;

            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception : Fail to add product sell info: Message={ex.Message} Exception={ex.InnerException}", ex.Message, ex.InnerException);
                return 1005;
            }
        }

        public async Task<int> UpdateProductStatus(ProductStatusChangeViewModel productStatus)
        {
            try
            {

                var productExists = await _productRepo.GetById(productStatus.ProductId);

                if (productExists == null || productExists.Id <= 0)
                {
                    _logger.LogError($"Error : No record found with product: ID: {productStatus.ProductId}");
                    return 1001;
                }


                productExists.Status = (ProductStatus)productStatus.StatusId;
                await _productRepo.Update(productExists.Id, productExists);

                return 200;

            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception : Fail to update product status info: Message={ex.Message} Exception={ex.InnerException}", ex.Message, ex.InnerException);
                return 1005;
            }
        }

    }
}
