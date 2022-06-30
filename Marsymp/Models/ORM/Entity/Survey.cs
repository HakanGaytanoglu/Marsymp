using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Marsymp.Models.ORM.Entity
{
  

    [Table("Survey")]
    public class Survey
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
        public string Brand_Awareness_Priority { get; set; }

        [MaxLength(50)]
        public string Lead_Generation { get; set; }

        [MaxLength(50)]
        public string Lead_Generation_Priority { get; set; }

        [MaxLength(50)]
        public string Sales_Generation { get; set; }

        [MaxLength(50)]
        public string Sales_Generation_Priority { get; set; }


        [MaxLength(50)]
        public string Traffic_Generation { get; set; }

        [MaxLength(50)]
        public string Traffic_Generation_Priority { get; set; }

        [MaxLength(50)]
        public string Visitors { get; set; }

        [MaxLength(50)]
        public string Subscribers { get; set; }

        [MaxLength(50)]
        public string Budget { get; set; }
      
        public float Budget1 { get; set; }

      

        public float Conversion_Rates { get; set; }

        public int Budget2 { get; set; }

        [MaxLength(50)]
        public string Currency { get; set; }

        [MaxLength(50)]
        public string Target_Audience { get; set; }
   
        public DateTime Start_Date { get; set; }

        public bool isLocked { get; set; }

        internal static Survey FirstOrDefault(Func<object, object> p)
        {
            throw new NotImplementedException();
        }
    }

  
}