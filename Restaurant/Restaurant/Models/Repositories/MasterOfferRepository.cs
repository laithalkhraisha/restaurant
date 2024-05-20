using Restaurant.Data;
using RESTAURANT.Models;
using System.Collections.Generic;
using System.Linq;

namespace Restaurant.Models.Repositories
{
    public class MasterOfferRepository : IRepository<MasterOffer>
    {
        public AppDbContext Db { get; }
        public MasterOfferRepository(AppDbContext _db)
        {
            Db = _db;
        }

       

        public void Active(int Id, MasterOffer entity)
        {
            var data = Db.MasterOffers.Find(Id);
            if (data.IsActive == true)
            {
                data.IsActive = false;
            }
            else if (data.IsActive == false)

            {
                data.IsActive = true;
            }
            Db.MasterOffers.Update(data);
            Db.SaveChanges();
        }

        public void Add(MasterOffer entity)
        {
            Db.MasterOffers.Add(entity);
            Db.SaveChanges();
        }

        public void Delete(int Id, MasterOffer entity)
        {
            var data = Db.MasterOffers.Find(Id);
            if (data.IsDelete == false)
            {
                data.IsDelete = true;
            }
            Db.MasterOffers.Update(data);
            Db.SaveChanges();
        }

        public MasterOffer Find(int id)
        {
            return Db.MasterOffers.SingleOrDefault(x => x.MasterOfferId == id);
        }

        public void Update(int Id, MasterOffer entity)
        {
            Db.MasterOffers.Update(entity);
            Db.SaveChanges();
        }

        public IList<MasterOffer> View()
        {
            return Db.MasterOffers.Where(x => x.IsDelete == false).ToList();
        }

        public IList<MasterOffer> ViewFrontClient()
        {
            return Db.MasterOffers.Where(x => x.IsDelete == false&&x.IsActive==true).ToList();
        }
    }
}
