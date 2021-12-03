using Angular.Eshop.DataLayer.Entities.site.slider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Angular.Eshop.Core.Services.Interfaces
{
    public interface ISliderService : IDisposable
    {
        Task<List<slider>> GetAllSliders();
        Task<List<slider>> GetactiveSliders();
        Task AddSlider(slider slider);
        Task UpdateSlider(slider slider);
        Task<slider> GetSliderById(long SliderId);
    }
}
