using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WeSafe.DTO.Read;

namespace WeSafe.DTO
{
    public class UserCreatDto
    {

        public int UserId { get; set; }
        public string IdentificationCard { get; set; }

        //   navigational element
        public Person Person { get; set; }

    }
}