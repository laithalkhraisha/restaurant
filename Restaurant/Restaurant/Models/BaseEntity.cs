using System;

namespace RESTAURANT.Models
{
    public class BaseEntity
    {
        public bool IsActive { get; set; }=true;
        public bool IsDelete { get; set; }=false;

        public string CreateUser { get; set; }
        public DateTime CreateDate { get; set; }=DateTime.Now;
        public string EditUser { get; set; }
        public DateTime EditeDate { get; set; } = DateTime.Now;

    }
}
