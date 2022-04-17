 using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WeSafe.Models;

namespace WeSafe.DTO
{
    public class AttachmentDto
    {
        public int AttachmentId { get; set; }
        public string Image { get; set; }
        public string Voice { get; set; }
        public string  video { get; set; }

    }

}
