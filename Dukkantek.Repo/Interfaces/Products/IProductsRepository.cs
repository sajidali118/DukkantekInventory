using Dukkantek.Repo.Data;
using Dukkantek.ViewModel.Categories;
using Dukkantek.ViewModel.MetaData;
using Dukkantek.ViewModel.Products;
using Dukkantek.ViewModel.Products.Sell;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dukkantek.Repo.Interfaces.Products
{
    public interface IProductsRepository : IAppRepository
    {
        Task<List<CategoryViewModel>> GetAllCategories();
        Task<List<MetaDataViewModel>> GetProductStatuses();
        Task<List<ProductViewModel>> GetAllProducts();
        Task<ProductCountViewModel> GetProductsCount();
        Task<int> UpdateProductStatus(ProductStatusChangeViewModel productStatus);
        Task<int> SellProduct(ProductSellViewModel productSell);

    }
}
