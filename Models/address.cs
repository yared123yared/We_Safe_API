using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeSafe.Models
{
    public class Address
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AdressId { get; set; }
        public string City { get; set; }
        public string Subcity { get; set; }
        public string Kebele { get; set; }
        public double Latitude { get; set; }
        public double Longtiude { get; set; }

    }

}