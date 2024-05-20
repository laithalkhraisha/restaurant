using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace RESTAURANT.Models
{
    public partial class TransactionContactUs : BaseEntity
    {
        public int TransactionContactUsId { get; set; }
        
        [Display(Name = "Name")]
        public string TransactionContactUsFullName { get; set; }
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string TransactionContactUsEmail { get; set; }
        [Display(Name = "Subject")]
        public string TransactionContactUsSubject { get; set; }
        [Display(Name = "Message")]
        public string TransactionContactUsMessage { get; set; }
    }
}
