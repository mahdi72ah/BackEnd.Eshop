using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Angular.Eshop.DataLayer.Entities.Common
{
  public class BaseEntities // کلاس پایه تمام مدلهای ان تی تی
  {
    [Key]
    public long id { get; set; }
    public Boolean IsDelete { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime LastUpdateDate { get; set; }
  }
}
