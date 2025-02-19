using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace persontracker.Models
{
    public class Expense
    {
        public int Id { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Please enter valid amount higer than 0")]
        public double Amount { get; set; }
        [Required]
        public string? Catagory { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
    }
}