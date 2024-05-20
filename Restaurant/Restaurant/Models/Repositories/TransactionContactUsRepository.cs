using Restaurant.Data;
using RESTAURANT.Models;
using System.Collections.Generic;
using System.Linq;

namespace Restaurant.Models.Repositories
{
    public class TransactionContactUsRepository : IRepository<TransactionContactUs>
    {
        public AppDbContext Db { get; }
        public TransactionContactUsRepository(AppDbContext _db)
        {
            Db = _db;
        }

        

        public void Active(int Id, TransactionContactUs entity)
        {
            var data = Db.TransactionContactUs.Find(Id);
            if (data.IsActive == true)
            {
                data.IsActive = false;
            }
            else if (data.IsActive == false)

            {
                data.IsActive = true;
            }
            Db.TransactionContactUs.Update(data);
            Db.SaveChanges();
        }

        public void Add(TransactionContactUs entity)
        {
           Db.TransactionContactUs.Add(entity);
            Db.SaveChanges();
        }

        public void Delete(int Id, TransactionContactUs entity)
        {
            var data = Db.TransactionContactUs.Find(Id);
            if (data.IsDelete==false)
            {
                data.IsDelete = true;
            }
            Db.TransactionContactUs.Update(data);
            Db.SaveChanges();
        }

        public TransactionContactUs Find(int id)
        {
            return Db.TransactionContactUs.SingleOrDefault(x=>x.TransactionContactUsId==id);
        }

        public void Update(int Id, TransactionContactUs entity)
        {
            Db.TransactionContactUs.Update(entity);
            Db.SaveChanges();
        }

        public IList<TransactionContactUs> View()
        {
            return Db.TransactionContactUs.Where(x=>x.IsDelete==false).ToList();
        }

        public IList<TransactionContactUs> ViewFrontClient()
        {
            return Db.TransactionContactUs.Where(x => x.IsDelete == false&&x.IsActive==true).ToList();
        }
    }
}
