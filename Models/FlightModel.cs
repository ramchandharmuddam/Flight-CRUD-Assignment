using System;
using System.ComponentModel.DataAnnotations;

namespace Flight.Models
{
    public class FlightModel
    {
        [Key]
        [Required(ErrorMessage = "Flight number is required.")]
        [StringLength(10, ErrorMessage = "Flight number cannot exceed 10 characters.")]
        [Display(Name = "Flight Number")]
        public string FlightNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "From city is required.")]
        [Display(Name = "From")]
        public string FromCity { get; set; } = string.Empty;

        [Required(ErrorMessage = "To city is required.")]
        [Display(Name = "To")]
        public string ToCity { get; set; } = string.Empty;

        [Required(ErrorMessage = "Date is required.")]
        [DataType(DataType.Date)]
        [Display(Name = "Date")]
        public DateTime Date { get; set; } = DateTime.Today;

        [Required(ErrorMessage = "Price is required.")]
        [Range(1, 100000, ErrorMessage = "Price must be greater than 0.")]
        [DataType(DataType.Currency)]
        [Display(Name = "Price")]
        public decimal Price { get; set; }
    }
}