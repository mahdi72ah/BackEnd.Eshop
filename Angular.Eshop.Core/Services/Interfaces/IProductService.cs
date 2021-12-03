using Angular.Eshop.DataLayer.Entities.site.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Angular.Eshop.Core.Services.Interfaces
{
    public interface IProductService:IDisposable
    {
        #region PropertiesProduct

        Task AddProduct(Product product);
        Task UpdateProduct(Product product);

        #endregion
    }
}
