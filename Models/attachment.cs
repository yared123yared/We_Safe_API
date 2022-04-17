using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeSafe.Models
{
    public class Attachment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public ICollection<FilePath>?  Images  { get; set; }
        public ICollection<FilePath>?  Voices { get; set; }
        public ICollection<FilePath>? Videos { get; set; }

    }

}   