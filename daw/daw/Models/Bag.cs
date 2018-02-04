using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace daw.Models
{
    public class Bag
    {
        public int Id { get; set; }

        public ICollection<Product> Products { get; set; }
        public ApplicationUser User { get; set; }
    }
}