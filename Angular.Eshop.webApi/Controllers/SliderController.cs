using Angular.Eshop.Core.Services.Interfaces;
using Angular.Eshop.Core.Utilities.Common;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Angular.Eshop.webApi.Controllers
{
    public class SliderController : SiteBaseController
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
            Thread.Sleep(1000);
            var slider = await slidersevice.GetactiveSliders();
            return JsonResponseStatus.Success(slider);
        }

    }
}
