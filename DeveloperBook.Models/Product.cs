using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperBook.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }

        [Required]
        public string ISBN { get; set; }
        [Required]
        public string Author { get;set; }
        [Required]
        [Range(0, 10000)]
        public double listPrice { get; set; }
        [Required]
        [Range(0, 10000)]
        public double price { get; set; }
        [Required]
        [Range(0, 10000)]
        public double price50 { get; set; }
        [Required]
        [Range(0, 10000)]
        public double price100 { get; set; }
        public string ImageUrl { get; set; }
        [Required]
        public int CategoryId { get; set; }         //Foreign Key
        //[ForeignKey("CategoryID")]
        public Category Category { get; set; }
        [Required]
        public int CoverTypeId { get; set; }         //Foreign Key
        public CoverType CoverType { get; set; }
    }
}
