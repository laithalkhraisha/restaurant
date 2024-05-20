using Restaurant.Data;
using RESTAURANT.Models;
using System.Collections.Generic;
using System.Linq;

namespace Restaurant.Models.Repositories
{
    public class MasterCategoryMenuRepositories : IRepository<MasterCategoryMenu>
    {
        public AppDbContext Db { get; }
        public MasterCategoryMenuRepositories(AppDbContext _db)
        {
            Db = _db;
        }

      

        public void Add(MasterCategoryMenu entity)
        {
          Db.MasterCategoryMenus.Add(entity);
            Db.SaveChanges();   
        }

        public void Delete(int Id, MasterCategoryMenu entity)
        {
            var data= Db.MasterCategoryMenus.Find(Id);
            data.IsDelete = true;
            
            Db.MasterCategoryMenus.Update(data);
            Db.SaveChanges();
        }

        public MasterCategoryMenu Find(int id)
        {
           return Db.MasterCategoryMenus.SingleOrDefault(x=>x.MasterCategoryMenuId==id);
        }

        public void Update(int Id, MasterCategoryMenu entity)
        {
            Db.MasterCategoryMenus.Update(entity);
            Db.SaveChanges();
        }

        public IList<MasterCategoryMenu> View()
        {
            return Db.MasterCategoryMenus.Where(x=>x.IsDelete==false).ToList();
        }

        public IList<MasterCategoryMenu> ViewFrontClient()
        {
            return Db.MasterCategoryMenus.Where(x => x.IsActive == true&&x.IsDelete==false).ToList();
        }

        public void Active(int Id, MasterCategoryMenu entity)
        {
            var data = Db.MasterCategoryMenus.Find(Id);
            if (data.IsActive == true)
            {
               data.IsActive = false;
            }
            else if (data.IsActive==false)

            {
                data.IsActive = true;
            }
            
            Db.MasterCategoryMenus.Update(data);
            Db.SaveChanges();
        }
    }
}
