using Angular.Eshop.DataLayer.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Angular.Eshop.DataLayer.Entities.site.Product
{
    public class ProductCategory:BaseEntities
    {

        #region Properties

        public string Title { get; set; }

        public long? ParentId { get; set; }
        #endregion


        #region Relation
        [ForeignKey("ParentId")]
        public ProductCategory productCategory { get; set; }

        public ICollection<ProductSelectedCategory> ProductSelectedCategories { get; set; }

        #endregion

    }
}
