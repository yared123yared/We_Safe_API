

using WeSafe.Models;

namespace WeSafe.DTO
{
    public class CaseDto
    {

       public int Id { get; set; }
        public DateTime OpenedDate { get; set; }
        public DateTime ClosedDate { get; set; }
        public int PoliceId { get; set; }
        public Police? AssignedPolice { get; set; }

        public int ReporterId { get; set; }
        public Person? ReporterAdmin { get; set; }
        public Evidence? Evidence { get; set; }
        public string? Summary { get; set; }
        public string? Description { get; set; }
}
}

       
