

using WeSafe.Models;

namespace WeSafe.DTO
{
    public class PersonDto
    {

        public int PersonId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Picture { get; set; }
        public string Sex { get; set; }

        // Navigational Element
        public Address Address { get; set; }
        public int RoleId { get; set; }

        public Role? Role { get; set; }
    }
}