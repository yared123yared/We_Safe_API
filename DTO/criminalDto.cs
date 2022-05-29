

using WeSafe.Models;

namespace WeSafe.DTO
{
    public class CriminalDto
    {

        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public ICollection<FilePath>? Images { get; set; }
        public string? Description { get; set; }
    }
}
