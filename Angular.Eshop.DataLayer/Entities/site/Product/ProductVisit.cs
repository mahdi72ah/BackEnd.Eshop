using Angular.Eshop.DataLayer.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Angular.Eshop.DataLayer.Entities.site.Product
{
    public class ProductVisit:BaseEntities
    {
        #region Properties
        [Display(Name = "IP")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(100, ErrorMessage = "تعداد کاراکتر های {0} نمیتواند بیشتر از {1} باشد")]
        public string UserIp { get; set; }
        public long ProductId { get; set; }
        #endregion

        #region Relation

        public Product Product { get; set; }

        #endregion

    }
}
