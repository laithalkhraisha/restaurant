using Restaurant.Data;
using RESTAURANT.Models;
using System.Collections.Generic;
using System.Linq;

namespace Restaurant.Models.Repositories
{
    public class MasterPartnerRepository : IRepository<MasterPartner>
    {
        public AppDbContext Db { get; }
        public MasterPartnerRepository(AppDbContext _db)
        {
            Db = _db;
        }

        

        public void Active(int Id, MasterPartner entity)
        {
            var data = Db.MasterPartners.Find(Id);
            if (data.IsActive == true)
            {
                data.IsActive = false;
            }
            else if (data.IsActive == false)

            {
                data.IsActive = true;
            }
            Db.MasterPartners.Update(data);
            Db.SaveChanges();
        }

        public void Add(MasterPartner entity)
        {
            Db.MasterPartners.Add(entity);
            Db.SaveChanges();
        }

        public void Delete(int Id, MasterPartner entity)
        {
            var data = Db.MasterPartners.Find(Id);
            if (data.IsDelete == false)
            {
                data.IsDelete = true;
            }
            Db.MasterPartners.Update(data);
            Db.SaveChanges();
        }

        public MasterPartner Find(int id)
        {
            return Db.MasterPartners.SingleOrDefault(x => x.MasterPartnerId == id);
        }

        public void Update(int Id, MasterPartner entity)
        {
            Db.MasterPartners.Update(entity);
            Db.SaveChanges();
        }

        public IList<MasterPartner> View()
        {
            return Db.MasterPartners.Where(x => x.IsDelete == false).ToList();
        }

        public IList<MasterPartner> ViewFrontClient()
        {
            return Db.MasterPartners.Where(x => x.IsDelete == false && x.IsActive == true).ToList();
        }
    }
}
