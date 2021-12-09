using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVCBOOK.Models
{
    public class CreateBookViewModel
    {
        [Required]
        public int BookId { get; set; }
        [Required]
        public string BookName { get; set; }
        [Required]
        public string BookAuthor { get; set; }
        [Required]
        public float BookPrice { get; set; }
    }
}