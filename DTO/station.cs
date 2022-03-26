using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeSafe.DTO
{
    public class StationDto
    {

        public int StationId { get; set; }
        public string StationName { get; set; }
        public string City { get; set; }
        public string Subcity { get; set; }
        public string Latitude { get; set; }
        public string Longtiude { get; set; }
    }

}