using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WeSafe.Models;

namespace WeSafe.DTO
{
    public class PoliceDto
    {

        public int Id { get; set; }
        public int Experiance { get; set; }
        public int Level { get; set; }

        // Navigational element
        public int StationId { get; set; }
        public Station? Station { get; set; }
        public Person Person { get; set; }
        public int RoleId { get; set; }
    }

}