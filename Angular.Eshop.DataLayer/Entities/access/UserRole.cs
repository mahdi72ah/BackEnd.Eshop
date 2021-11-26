using Angular.Eshop.DataLayer.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Angular.Eshop.DataLayer.Entities.access
{
    public class UserRole:BaseEntities
    {
        #region Properties
        public long UserId { get; set; }
        public long RoleId { get; set; }
        #endregion
        #region Ralations
        public long User { get; set; }
        public long Role { get; set; }
        #endregion
    }
}
