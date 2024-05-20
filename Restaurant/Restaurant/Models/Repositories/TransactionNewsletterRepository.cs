using Restaurant.Data;
using RESTAURANT.Models;
using System.Collections.Generic;
using System.Linq;

namespace Restaurant.Models.Repositories
{
    public class TransactionNewsletterRepository : IRepository<TransactionNewsletter>
    {
        public AppDbContext Db { get; }

        public TransactionNewsletterRepository(AppDbContext _db)
        {
            Db = _db;
        }

        

        public void Active(int Id, TransactionNewsletter entity)
        {
            var data=Db.TransactionNewsletters.Find(Id);
            if (data.IsActive == true)
            {
                data.IsActive = false;
            }
            else if (data.IsActive==false)
            {
                data.IsActive = true;
            }
            Db.TransactionNewsletters.Update(data);
            Db.SaveChanges();
        }

        public void Add(TransactionNewsletter entity)
        {
            Db.TransactionNewsletters.Add(entity);
            Db.SaveChanges();
        }

        public void Delete(int Id, TransactionNewsletter entity)
        {
            var data = Db.TransactionNewsletters.Find(Id);
            if (data.IsDelete==false)
            {
                data.IsDelete = true;
            }
            Db.TransactionNewsletters.Update(data);
            Db.SaveChanges();
        }

        public TransactionNewsletter Find(int id)
        {
            return Db.TransactionNewsletters.SingleOrDefault(x=>x.TransactionNewsletterId==id);
        }

        public void Update(int Id, TransactionNewsletter entity)
        {
            Db.TransactionNewsletters.Update(entity);
            Db.SaveChanges();
        }

        public IList<TransactionNewsletter> View()
        {
            return Db.TransactionNewsletters.Where(x=>x.IsDelete==false).ToList();
        }

        public IList<TransactionNewsletter> ViewFrontClient()
        {
            return Db.TransactionNewsletters.Where(x => x.IsDelete == false&&x.IsActive==true).ToList();
        }
    }
}
