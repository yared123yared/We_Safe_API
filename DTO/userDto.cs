using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AutoMapper;
using WeSafe.Models;

namespace WeSafe.DTO
{
    public class UserDto
    {
        
         


        public int UserId { get; set; }
        public string IdentificationCard { get; set; }

        //   navigational element

        public Person Person { get; set; }
        public int RoleId { get; set; }

    }
  

}