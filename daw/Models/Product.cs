using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace daw.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        public string LocationName { get; set; }

        [Required]
        public float Note { get; set; }

        [Required]
        public string Description { get; set; }

        public string Image { get; set; }

        [Display (Name = "National")]
        public bool Tip { get; set; }

    }
}
