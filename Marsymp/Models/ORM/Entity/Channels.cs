using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Marsymp.Models.ORM.Entity
{
    [Table("Channels")]
    public class Channels
    {
        [Key]
        [Column(Order = 1)]
        public int ID { get; set; }

        [Column(Order = 2)]
        public int? CustID { get; set; }

        [Column(Order = 4)]
        [MaxLength(50)]
        public string Email_Address { get; set; }

        [MaxLength(50)]
        public string Brand_Awareness { get; set; }

        [MaxLength(50)]
        public string Lead_Generation { get; set; }

        [MaxLength(50)]
        public string Sales_Generation { get; set; }

        [MaxLength(50)]
        public string Traffic_Generation { get; set; }


    }
}