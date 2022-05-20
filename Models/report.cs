using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeSafe.Models
{
    public class Report
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public DateTime ReportDate { get; set; }
        public string Status { get; set; }
        public int UserId { get; set; }
        public User? ReportedBy { get; set; }
        public Evidence Evidence { get; set; }

    }
}