using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace RESTAURANT.Models
{
    public partial class TransactionBookTable : BaseEntity
    {
        public int TransactionBookTableId { get; set; }
        
        [Display(Name = "Name")]
        public string TransactionBookTableFullName { get; set; }
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string TransactionBookTableEmail { get; set; }
        public string TransactionBookTableMobileNumber { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]

        public DateTime? TransactionBookTableDate { get; set; }
    }
}
