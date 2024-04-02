using System.ComponentModel.DataAnnotations;

namespace VendingMachine.Business.DTOs
{
    public class ProductDTO
    {
        [MinLength(1,ErrorMessage = "Name must have at least 1 character!")]
        public string Name { get; set; }

        [MinLength(1, ErrorMessage = "Description must have at least 1 character!")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Quantity is required!")]
        [Range(0, int.MaxValue, ErrorMessage = "Quantity must be greater than or equal to 0!")]     
        public int? Quantity { get; set; }

        [Required(ErrorMessage = "Price is required!")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0!")]
        public double? Price { get; set; }
    }
}
