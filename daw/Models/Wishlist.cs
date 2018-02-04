using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace daw.Models
{
    public class Wishlist
    {
        public int Id { get; set; }

        public Product Products { get; set; }
        public ApplicationUser User { get; set; }
    }
}