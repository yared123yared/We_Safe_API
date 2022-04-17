using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WeSafe.Models;

namespace WeSafe.DTO
{
    public class RoleDto
    {
        public int Id { get; set; }
        public string RoleName { get; set; }

    }

}