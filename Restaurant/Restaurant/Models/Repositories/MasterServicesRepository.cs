using Restaurant.Data;
using RESTAURANT.Models;
using System.Collections.Generic;
using System.Linq;

namespace Restaurant.Models.Repositories
{
    public class MasterServicesRepository : IRepository<MasterServices>
    {
        public AppDbContext Db { get; }
        public MasterServicesRepository(AppDbContext _db)
        {
            Db = _db;
        }

        

        public void Active(int Id, MasterServices entity)
        {
            var data = Db.MasterServices.Find(Id);
            if (data.IsActive == true)
            {
                data.IsActive = false;
            }
            else if (data.IsActive == false)

            {
                data.IsActive = true;
            }
            Db.MasterServices.Update(data);
            Db.SaveChanges();
        }

        public void Add(MasterServices entity)
        {
            Db.MasterServices.Add(entity);
            Db.SaveChanges();
        }

        public void Delete(int Id, MasterServices entity)
        {
            var data = Db.MasterServices.Find(Id);
            if (data.IsDelete == false)
            {
                data.IsDelete = true;
            }
            Db.MasterServices.Update(data);
            Db.SaveChanges();      
        }

        public MasterServices Find(int id)
        {
            return Db.MasterServices.SingleOrDefault(x => x.MasterServicesId == id);
        }

        public void Update(int Id, MasterServices entity)
        {
            Db.MasterServices.Update(entity);
            Db.SaveChanges();
        }

        public IList<MasterServices> View()
        {
            return Db.MasterServices.Where(x => x.IsDelete == false).ToList();
        }

        public IList<MasterServices> ViewFrontClient()
        {
            return Db.MasterServices.Where(x => x.IsDelete == false && x.IsActive == true).ToList();
        }
    }
}
