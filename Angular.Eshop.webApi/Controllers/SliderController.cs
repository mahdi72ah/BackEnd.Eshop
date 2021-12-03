using Angular.Eshop.Core.Services.Interfaces;
using Angular.Eshop.Core.Utilities.Common;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Angular.Eshop.webApi.Controllers
{
    public class SliderController : Controller
    {
        #region Constractor

        private ISliderService slidersevice;

        public SliderController(ISliderService slidersevice)
        {
            this.slidersevice = slidersevice;
        }

        #endregion

        [HttpGet("GetActiveSliders")]
        public async Task<IActionResult>  GetActiveSliders()
        {
            //return new JsonResult(await slidersevice.GetactiveSliders());این برای زمانی بود که کلاس جیسون ریسپانس رو پیاده سازی نکرده بودم

            return JsonResponseStatus.Success(await slidersevice.GetactiveSliders());
        }
    }
}
