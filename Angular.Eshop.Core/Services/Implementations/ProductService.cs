using Angular.Eshop.Core.Services.Interfaces;
using Angular.Eshop.DataLayer.Entities.site.Product;
using Angular.Eshop.DataLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Angular.Eshop.Core.Services.Implementations
{
    public class ProductService : IProductService
    {
        private GenericRepository<ProductGllary> ProductGllaryRepository;
        private GenericRepository<Product> productRepository;
        private GenericRepository<ProductCategory> ProductCategoryRepository;
        private GenericRepository<ProductSelectedCategory> ProductSelectedCategoryRepository;
        private GenericRepository<ProductVisit> ProductVisitRepository;



        #region Product

        public async Task AddProduct(Product product)
        {
           productRepository.AddEntity(product);
           await productRepository.SaveChanges();
        }

        public async Task UpdateProduct(Product product)
        {
            productRepository.UpdateEntity(product);
            await productRepository.SaveChanges();

        }

        #endregion








        #region Dispose
        public void Dispose()
        {
            ProductSelectedCategoryRepository?.Dispose();
            ProductVisitRepository?.Dispose();
            productRepository?.Dispose();
            ProductGllaryRepository?.Dispose();
            ProductCategoryRepository?.Dispose();
        }
        #endregion
    }
}
