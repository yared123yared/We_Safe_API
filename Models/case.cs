using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeSafe.Models
{
    public class Case
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime OpenedDate { get; set; }
        public DateTime ClosedDate { get; set; }
        public int? AssignedPoliceId { get; set; }
        public Police? AssignedPolice { get; set; }
        public int ReporterAdminId { get; set; }
        public Person? ReporterAdmin { get; set; }
        public Evidence? Evidence { get; set; }
        public string? Summary { get; set; }
        public string? Description { get; set; }

    }
}