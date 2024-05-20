using Restaurant.Data;
using System.Collections.Generic;
using System.Linq;

namespace Restaurant.Models.Repositories
{
    public class MasterPeopleRepository : IRepository<MasterPeople>
    {
        public AppDbContext Db { get; }
        public MasterPeopleRepository(AppDbContext _db)
        {
            Db = _db;
        }

       

        public void Active(int Id, MasterPeople entity)
        {
            var data = Db.MasterPeople.Find(Id);
            if (data.IsActive == true)
            {
                data.IsActive = false;
            }
            else if (data.IsActive == false)

            {
                data.IsActive = true;
            }
            Db.MasterPeople.Update(data);
            Db.SaveChanges(); 
        }

        public void Add(MasterPeople entity)
        {
            Db.MasterPeople.Add(entity);
            Db.SaveChanges();
        }

        public void Delete(int Id, MasterPeople entity)
        {
            var data = Db.MasterPeople.Find(Id);
            if (data.IsDelete == false)
            {
                data.IsDelete = true;
            }
            Db.MasterPeople.Update(data);
            Db.SaveChanges();
        }

        public MasterPeople Find(int id)
        {
            return Db.MasterPeople.SingleOrDefault(x => x.MasterPeopleId == id);
        }

        public void Update(int Id, MasterPeople entity)
        {
            Db.MasterPeople.Update(entity);
            Db.SaveChanges();
        }

        public IList<MasterPeople> View()
        {
            return Db.MasterPeople.Where(x => x.IsDelete == false).ToList();
        }

        public IList<MasterPeople> ViewFrontClient()
        {
            return Db.MasterPeople.Where(x => x.IsDelete == false&&x.IsActive==true).ToList();
        }
    }
}
