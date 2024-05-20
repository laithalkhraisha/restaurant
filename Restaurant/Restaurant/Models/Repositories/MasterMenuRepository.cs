using Restaurant.Data;
using RESTAURANT.Models;
using System.Collections.Generic;
using System.Linq;

namespace Restaurant.Models.Repositories
{
    public class MasterMenuRepository : IRepository<MasterMenu>
    {
        public AppDbContext Db { get; }
        public MasterMenuRepository(AppDbContext _db)
        {
            Db = _db;
        }

        

        public void Active(int Id, MasterMenu entity)
        {
            var data = Db.MasterMenus.Find(Id);
            if (data.IsActive == true)
            {
                data.IsActive = false;
            }
            else if (data.IsActive == false)

            {
                data.IsActive = true;
            }
            Db.MasterMenus.Update(data);
            Db.SaveChanges();
        }

        public void Add(MasterMenu entity)
        {
            entity.IsActive = true;
            entity.IsDelete = false;
          
            Db.MasterMenus.Add(entity);
            Db.SaveChanges();
        }

        public void Delete(int Id, MasterMenu entity)
        {
            var data = Db.MasterMenus.Find(Id);
            if (data.IsDelete == false)
            {
                data.IsDelete = true;
            }
            Db.MasterMenus.Update(data);
            Db.SaveChanges();
        }

        public MasterMenu Find(int id)
        {
            return Db.MasterMenus.SingleOrDefault(x=>x.MasterMenuId==id);
        }

        public void Update(int Id, MasterMenu entity)
        {
            Db.MasterMenus.Update(entity);
            Db.SaveChanges();
        }

        public IList<MasterMenu> View()
        {
            return Db.MasterMenus.Where(x => x.IsDelete == false).ToList();
        }

        public IList<MasterMenu> ViewFrontClient()
        {
            return Db.MasterMenus.Where(x => x.IsDelete == false && x.IsActive == true).ToList();
        }
    }
}
