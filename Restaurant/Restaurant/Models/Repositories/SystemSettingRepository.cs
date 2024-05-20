using Restaurant.Data;
using RESTAURANT.Models;
using System.Collections.Generic;
using System.Linq;

namespace Restaurant.Models.Repositories
{
    public class SystemSettingRepository : IRepository<SystemSetting>
    {
        public AppDbContext Db { get; }
        public SystemSettingRepository(AppDbContext _db)
        {
            Db = _db;
        }

      

        public void Active(int Id, SystemSetting entity)
        {
            var data = Db.SystemSettings.Find(Id);
            if (data.IsActive == true)
            {
                data.IsActive = false;
            }
            else if (data.IsActive == false)

            {
                data.IsActive = true;
            }
            Db.SystemSettings.Update(data);
            Db.SaveChanges();
        }

        public void Add(SystemSetting entity)
        {
            Db.SystemSettings.Add(entity);
            Db.SaveChanges(); 
        }

        public void Delete(int Id, SystemSetting entity)
        {
            var data = Db.SystemSettings.Find(Id);
            if (data.IsDelete == false)
            {
                data.IsDelete = true;
            }
            Db.SystemSettings.Update(data);
            Db.SaveChanges(); 
        }

        public SystemSetting Find(int id)
        {
            return Db.SystemSettings.SingleOrDefault(x => x.SystemSettingId == id);
        }

        public void Update(int Id, SystemSetting entity)
        {
            Db.SystemSettings.Update(entity);
            Db.SaveChanges();
        }

        public IList<SystemSetting> View()
        {
            return Db.SystemSettings.Where(x => x.IsDelete == false).ToList();
        }

        public IList<SystemSetting> ViewFrontClient()
        {
            return Db.SystemSettings.Where(x => x.IsDelete == false&&x.IsActive==true).ToList();
        }
    }
}
