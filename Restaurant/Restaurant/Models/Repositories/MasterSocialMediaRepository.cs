using Restaurant.Data;
using RESTAURANT.Models;
using System.Collections.Generic;
using System.Linq;

namespace Restaurant.Models.Repositories
{
    
    public class MasterSocialMediaRepository : IRepository<MasterSocialMedia>
    {
        public AppDbContext Db { get; }
        public MasterSocialMediaRepository(AppDbContext _db)
        {
            Db = _db;
        }

      

        public void Active(int Id, MasterSocialMedia entity)
        {
            var data = Db.MasterSocialMedia.Find(Id);
            if (data.IsActive == true)
            {
                data.IsActive = false;
            }
            else if (data.IsActive == false)

            {
                data.IsActive = true;
            }
            Db.MasterSocialMedia.Update(data);
            Db.SaveChanges();
        }

        public void Add(MasterSocialMedia entity)
        {
            Db.MasterSocialMedia.Add(entity);
            Db.SaveChanges();
        }

        public void Delete(int Id, MasterSocialMedia entity)
        {
            var data = Db.MasterSocialMedia.Find(Id);
            if (data.IsDelete == false)
            {
                data.IsDelete = true;
            }
            Db.MasterSocialMedia.Update(data);
            Db.SaveChanges();
        }

        public MasterSocialMedia Find(int id)
        {
            return Db.MasterSocialMedia.SingleOrDefault(x => x.MasterSocialMediaId == id);
        }

        public void Update(int Id, MasterSocialMedia entity)
        {
            Db.MasterSocialMedia.Update(entity);
            Db.SaveChanges();
        }

        public IList<MasterSocialMedia> View()
        {
            return Db.MasterSocialMedia.Where(x => x.IsDelete == false).ToList();
        }

        public IList<MasterSocialMedia> ViewFrontClient()
        {
            return Db.MasterSocialMedia.Where(x => x.IsDelete == false && x.IsActive == true).ToList();
        }
    }
}
