using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace RESTAURANT.Models
{
    public partial class TransactionNewsletter : BaseEntity
    {
        public int TransactionNewsletterId { get; set; }
        
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string TransactionNewsletterEmail { get; set; }
    }
}
