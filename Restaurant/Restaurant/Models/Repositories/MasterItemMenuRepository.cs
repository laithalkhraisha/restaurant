using Microsoft.EntityFrameworkCore;
using Restaurant.Data;
using RESTAURANT.Models;
using System.Collections.Generic;
using System.Linq;

namespace Restaurant.Models.Repositories
{
    public class MasterItemMenuRepository : IRepository<MasterItemMenu>
    {
        public AppDbContext Db { get; }
        public MasterItemMenuRepository(AppDbContext _db)
        {
            Db = _db;
        }

        

        public void Active(int Id, MasterItemMenu entity)
        {
            var data = Db.MasterItemMenus.Find(Id);
            if (data.IsActive == true)
            {
                data.IsActive = false;
            }
            else if (data.IsActive == false)

            {
                data.IsActive = true;
            }
            Db.MasterItemMenus.Update(data);
            Db.SaveChanges();
        }

        public void Add(MasterItemMenu entity)
        {
        
          Db.MasterItemMenus.Add(entity);
            Db.SaveChanges();
        }

        public void Delete(int Id, MasterItemMenu entity)
        {
            var data=Db.MasterItemMenus.Find(Id);
            if (data.IsDelete==false)
            {
                data.IsDelete = true;
            }
            Db.MasterItemMenus.Update(data);
            Db.SaveChanges();
        }

        public MasterItemMenu Find(int id)
        {
            return Db.MasterItemMenus.SingleOrDefault(x=>x.MasterItemMenuId==id);
        }

        public void Update(int Id, MasterItemMenu entity)
        {
            Db.MasterItemMenus.Update(entity);
            Db.SaveChanges();
        }

        public IList<MasterItemMenu> View()
        {
            
            return Db.MasterItemMenus.Include(x => x.MasterCategoryMenu).Where(x=>x.IsDelete==false).ToList();
        }

        public IList<MasterItemMenu> ViewFrontClient()
        {
            return Db.MasterItemMenus.Where(x => x.IsDelete == false&&x.IsActive==true).ToList();
        }
    }
}
