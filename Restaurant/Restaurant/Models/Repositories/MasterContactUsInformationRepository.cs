using Restaurant.Data;
using RESTAURANT.Models;
using System.Collections.Generic;
using System.Linq;

namespace Restaurant.Models.Repositories
{
    public class MasterContactUsInformationRepository : IRepository<MasterContactUsInformation>
    {
        public AppDbContext Db { get; }
        public MasterContactUsInformationRepository(AppDbContext _db)
        {
            Db = _db;
        }

       

        public void Active(int Id, MasterContactUsInformation entity)
        {
            var data = Db.MasterContactUsInformations.Find(Id);
            
            if (data.IsActive == true)
            {
                data.IsActive = false;
            }
            else if (data.IsActive == false)

            {
                data.IsActive = true;
            }

            Db.MasterContactUsInformations.Update(data);
            Db.SaveChanges();
        }

        public void Add(MasterContactUsInformation entity)
        {
            Db.MasterContactUsInformations.Add(entity);
            Db.SaveChanges();
        }

        public void Delete(int Id, MasterContactUsInformation entity)
        {
            var data = Db.MasterContactUsInformations.Find(Id);
            if (data.IsDelete==false)
            {
                data.IsDelete = true;
            }

            Db.MasterContactUsInformations.Update(data);
            Db.SaveChanges();
        }

        public MasterContactUsInformation Find(int id)
        {
           return Db.MasterContactUsInformations.SingleOrDefault(x=>x.MasterContactUsInformationId==id);
        }

        public void Update(int Id, MasterContactUsInformation entity)
        {
            Db.MasterContactUsInformations.Update(entity);
            Db.SaveChanges();
        }

        public IList<MasterContactUsInformation> View()
        {
            return Db.MasterContactUsInformations.Where(x=>x.IsDelete==false).ToList();
        }

        public IList<MasterContactUsInformation> ViewFrontClient()
        {
            return Db.MasterContactUsInformations.Where(x => x.IsDelete == false&&x.IsActive==true).ToList();
        }
    }
}
