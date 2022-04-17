using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeSafe.Models
{
    public class Station
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string StationName { get; set; }
        public string City { get; set; }
        public string Subcity { get; set; }
        public string Latitude { get; set; }
        public string Longtiude { get; set; }
    }

}