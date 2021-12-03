using Angular.Eshop.Core.Services.Interfaces;
using Angular.Eshop.DataLayer.Entities.site.slider;
using Angular.Eshop.DataLayer.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Angular.Eshop.Core.Services.Implementations
{
    public class SliderService : ISliderService
    {
        #region Constractor
        private IGenericRepository<slider> genericRepository;

        public SliderService(IGenericRepository<slider> genericRepository)
        {
            this.genericRepository = genericRepository;
        }
        #endregion



        #region Dispose
        public void Dispose()
        {
            genericRepository?.Dispose();
        }
        #endregion


        #region Function
        public async Task<List<slider>> GetactiveSliders()
        {
            return await genericRepository.GetEntitiesQuery().ToListAsync();
        }

        public async Task<List<slider>> GetAllSliders()
        {
            return await genericRepository.GetEntitiesQuery().Where(p => !p.IsDelete).ToListAsync();   
        }


        public async Task<slider> GetSliderById(long SliderId)
        {
            return await genericRepository.GetEntityById(SliderId);
        }

        public async Task AddSlider(slider slider)
        {
            await genericRepository.AddEntity(slider);
            await genericRepository.SaveChanges();
        }

        public async Task UpdateSlider(slider slider)
        {
            genericRepository.UpdateEntity(slider);
            await genericRepository.SaveChanges();
        }
        #endregion
    }
}
