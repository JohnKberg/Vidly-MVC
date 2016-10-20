using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Vidly.Models
{
    public class Genre
    {
        public byte Id { get; set; }
        [Required]
        [StringLength(255)]
        [Display(Name="Genre")]
        public string Name { get; set; }
    }
}
