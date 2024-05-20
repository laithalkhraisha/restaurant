using Restaurant.Data;
using RESTAURANT.Models;
using System.Collections.Generic;
using System.Linq;

namespace Restaurant.Models.Repositories
{
    public class TransactionBookTableRepository : IRepository<TransactionBookTable>
    {
        public AppDbContext Db { get; }
        public TransactionBookTableRepository(AppDbContext _db)
        {
            Db = _db;
        }

       

        public void Active(int Id, TransactionBookTable entity)
        {
            var data = Db.TransactionBookTables.Find(Id);
            if (data.IsActive == true)
            {
                data.IsActive = false;
            }
            else if (data.IsActive == false)

            {
                data.IsActive = true;
            }
            Db.TransactionBookTables.Update(data);
            Db.SaveChanges();
        }

        public void Add(TransactionBookTable entity)
        {
           Db.TransactionBookTables.Add(entity);
            Db.SaveChanges();
        }

        public void Delete(int Id, TransactionBookTable entity)
        {
            var data = Db.TransactionBookTables.Find(Id);
            if (data.IsDelete==false)
            {
                data.IsDelete = true;
            }
            Db.TransactionBookTables.Update(data);
            Db.SaveChanges();
        }

        public TransactionBookTable Find(int id)
        {
            return Db.TransactionBookTables.SingleOrDefault(x=>x.TransactionBookTableId==id);
        }

        public void Update(int Id, TransactionBookTable entity)
        {
            Db.TransactionBookTables.Update(entity);
            Db.SaveChanges();

        }

        public IList<TransactionBookTable> View()
        {
            return Db.TransactionBookTables.Where(x=>x.IsDelete==false).ToList();
        }

        public IList<TransactionBookTable> ViewFrontClient()
        {
            return Db.TransactionBookTables.Where(x => x.IsDelete == false&&x.IsActive==true).ToList();
        }
    }
}
