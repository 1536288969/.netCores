using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entity
{
   // [Table("Inforamtion")]
    public  class Information
    {
       [Key]
        public int ID { get; set; }
        [MaxLength(200)]
        public string Name { get; set; }
        public int WebMenuID { get; set; }
        public virtual WebMenu WebMenu { get; set; }


    }
}
