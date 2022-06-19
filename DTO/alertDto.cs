using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WeSafe.Models;

namespace WeSafe.DTO
{
    public class AlertDTO
    {
        public int Id { get; set; }
        public double Latitude { get; set; }
        public double Longtiude { get; set; }
        public double Distance { get; set; }
         public int UserId { get; set; }
        public User? AlertedBy { get; set; }

    }

}
