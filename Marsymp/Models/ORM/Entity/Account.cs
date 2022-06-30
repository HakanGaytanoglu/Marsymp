using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Marsymp.Models.ORM.Entity
{
    [Table("Account")]
    public class Account
    {
        [Key]
        [Column(Order = 1)]
        public int ID { get; set; }
      
        [Column(Order = 2)]
        public int? CustID { get; set; }

        [Column(Order = 3)]
        [MaxLength(50)]
        public string Email_Address { get; set; }

        [MaxLength(50)]
        public string Password { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(50)]
        public string Last_Name { get; set; }

        [MaxLength(50)]
        public string Company_Name { get; set; }

        [MaxLength(50)]
        public string Newsletter { get; set; }


        public string Token { get; set; }
    }
}