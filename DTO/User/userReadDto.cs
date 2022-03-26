using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AutoMapper;
using WeSafe.Models;

namespace WeSafe.DTO
{
    public class UserReadDto
    {
        
         private readonly IMapper _mapper;
        public UserReadDto(IMapper mapper)
        {

            _mapper = mapper;
        }


        public int UserId { get; set; }
        public string IdentificationCard { get; set; }

        //   navigational element

        public Person PersonReadDto { get; set; }

    }
  

}