using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WeSafe.Models;

namespace WeSafe.DTO
{
    public class UserCreatDto
    {

        public int UserId { get; set; }
        public string IdentificationCard { get; set; }

        //   navigational element

        public PersonCreatDto PersonDto { get; set; }

    }
    public class PersonCreatDto{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
        
 
    }

}