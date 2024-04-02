using System.ComponentModel.DataAnnotations;

namespace VendingMachine.DataAccess.Entities
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Quantity must be greater than or equal to zero.")]
        public int Quantity { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than zero.")]
        public double Price { get; set; }

    }
}
