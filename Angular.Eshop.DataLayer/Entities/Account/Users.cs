using Angular.Eshop.DataLayer.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Angular.Eshop.DataLayer.Entities.Account
{
  public class Users:BaseEntities
  {
    #region Prperties
    [Display(Name="ایمیل")]
    [Required(ErrorMessage ="این فیلد اجباری می باشد")]
    [MaxLength(100,ErrorMessage ="")]
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string lastName { get; set; }
    public string Address { get; set; }
    public string EmailActiveCode { get; set; }
    public string IsActiveted { get; set; }
    #endregion
  }
}
