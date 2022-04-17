using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeSafe.Models
{
    public class Police
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Experiance { get; set; }
        public int Level { get; set; }

        // Navigational element
        public int StationId { get; set; }
        public Station Station { get; set; }
        public Person Person { get; set; }
    }
}