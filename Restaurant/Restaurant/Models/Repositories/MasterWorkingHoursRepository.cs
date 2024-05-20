using Restaurant.Data;
using RESTAURANT.Models;
using System.Collections.Generic;
using System.Linq;

namespace Restaurant.Models.Repositories
{
    public class MasterWorkingHoursRepository : IRepository<MasterWorkingHours>
    {
        public AppDbContext Db { get; }
        public MasterWorkingHoursRepository(AppDbContext _db)
        {
            Db = _db;
        }

        

        public void Active(int Id, MasterWorkingHours entity)
        {
            var data = Db.MasterWorkingHours.Find(Id);
            if (data.IsActive == true)
            {
                data.IsActive = false;
            }
            else if (data.IsActive == false)

            {
                data.IsActive = true;
            }
            Db.MasterWorkingHours.Update(data);
            Db.SaveChanges();
        }

        public void Add(MasterWorkingHours entity)
        {
            Db.MasterWorkingHours.Add(entity);
            Db.SaveChanges(); ;
        }

        public void Delete(int Id, MasterWorkingHours entity)
        {
            var data = Db.MasterWorkingHours.Find(Id);
            if (data.IsDelete == false)
            {
                data.IsDelete = true;
            }
            Db.MasterWorkingHours.Update(data);
            Db.SaveChanges();
        }

        public MasterWorkingHours Find(int id)
        {
            return Db.MasterWorkingHours.SingleOrDefault(x => x.MasterWorkingHoursId == id);
        }

        public void Update(int Id, MasterWorkingHours entity)
        {
            Db.MasterWorkingHours.Update(entity);
            Db.SaveChanges();
        }

        public IList<MasterWorkingHours> View()
        {
            return Db.MasterWorkingHours.Where(x => x.IsDelete == false).ToList(); 
        }

        public IList<MasterWorkingHours> ViewFrontClient()
        {
            return Db.MasterWorkingHours.Where(x => x.IsDelete == false&&x.IsActive==true).ToList(); 
        }
    }
}
