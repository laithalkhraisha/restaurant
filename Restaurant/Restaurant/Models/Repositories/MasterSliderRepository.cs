using Restaurant.Data;
using RESTAURANT.Models;
using System.Collections.Generic;
using System.Linq;

namespace Restaurant.Models.Repositories
{
    public class MasterSliderRepository : IRepository<MasterSlider>
    {
        public AppDbContext Db { get; }
        public MasterSliderRepository(AppDbContext _db)
        {
            Db = _db;
        }

       

        public void Active(int Id, MasterSlider entity)
        {
            var data = Db.MasterSliders.Find(Id);
            if (data.IsActive == true)
            {
                data.IsActive = false;
            }
            else if (data.IsActive == false)

            {
                data.IsActive = true;
            }
            Db.MasterSliders.Update(data);
            Db.SaveChanges();
        }

        public void Add(MasterSlider entity)
        {
            Db.MasterSliders.Add(entity);
            Db.SaveChanges();
        }

        public void Delete(int Id, MasterSlider entity)
        {
            var data = Db.MasterSliders.Find(Id);
            if (data.IsDelete == false)
            {
                data.IsDelete = true;
            }
            Db.MasterSliders.Update(data);
            Db.SaveChanges();
        }

        public MasterSlider Find(int id)
        {
            return Db.MasterSliders.SingleOrDefault(x => x.MasterSliderId == id);
        }

        public void Update(int Id, MasterSlider entity)
        {
            Db.MasterSliders.Update(entity);
            Db.SaveChanges();
        }

        public IList<MasterSlider> View()
        {
            return Db.MasterSliders.Where(x => x.IsDelete == false).ToList();
        }

        public IList<MasterSlider> ViewFrontClient()
        {
            return Db.MasterSliders.Where(x => x.IsDelete == false && x.IsActive == true).ToList();
        }
    }
}
