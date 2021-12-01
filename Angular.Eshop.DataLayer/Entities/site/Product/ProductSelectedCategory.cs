using Angular.Eshop.DataLayer.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Angular.Eshop.DataLayer.Entities.site.Product
{
    public class ProductSelectedCategory:BaseEntities
    {
        #region Properties

        public long CategoryId { get; set; }
        public long ProductId { get; set; }

        #endregion

        #region Relations

        public Product product { get; set; }
        public ProductCategory ProductCategory { get; set; }

        #endregion
    }
}
