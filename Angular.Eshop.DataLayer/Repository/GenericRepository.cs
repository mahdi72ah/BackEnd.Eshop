using Angular.Eshop.DataLayer.Context;
using Angular.Eshop.DataLayer.Entities.Common;
using System;
using Microsoft.EntityFrameworkCore;//برای DbSet<TEntity> dbSet این باید یوز کنم
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Angular.Eshop.DataLayer.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntities
    {
        #region Constractor

        private AngularEshopdbContext context;// شمایی از کل دیتابیس من هستش
        private DbSet<TEntity> dbSet;// این اون مدلهای من هستند که داخل کلاس کانتکس کلاس که  از کانتکس ارث بری کرد اوردم که اگه اونها رو ست نمیکردم موقع مایگرشن مایگرشن من رو خالی میاوردن
        public GenericRepository(AngularEshopdbContext context)
        {
            this.context = context;
            this.dbSet = this.context.Set<TEntity>();
        }

        #endregion

        public IQueryable<TEntity> GetEntitiesQuery()
        {
            return dbSet.AsQueryable();
        }

        public async Task<TEntity> GetEntityById(long entityId)
        {
            return await dbSet.SingleOrDefaultAsync(e => e.id == entityId);
        }

        public async Task AddEntity(TEntity entity)
        {
            entity.CreateDate = DateTime.Now;
            entity.LastUpdateDate = entity.CreateDate;
            await dbSet.AddAsync(entity);
        }

        public void UpdateEntity(TEntity entity)
        {
            entity.LastUpdateDate = DateTime.Now;
            dbSet.Update(entity);
        }

        public void RemoveEntity(TEntity entity)
        {
            entity.IsDelete = true;
            UpdateEntity(entity);
        }

        public async Task RemoveEntity(long entityId)
        {
            var entity = await GetEntityById(entityId);//تابع فایند بر اساس ای دی رو از بالا صدا زده
            RemoveEntity(entity);// تابع حذف رو از بالا صدا زده
        }

        public async Task SaveChanges()
        {
            await context.SaveChangesAsync();
        }

        public void Dispose()
        {
            context?.Dispose();// اون علامت سوال میگه اگه کانتکس نال نبود بیا و ببندش
        }
    }
}
