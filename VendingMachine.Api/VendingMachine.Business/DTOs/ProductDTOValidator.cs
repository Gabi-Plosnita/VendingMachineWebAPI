namespace VendingMachine.Business.DTOs
{
    public static class ProductDTOValidator
    {
        public static bool IsValid(ProductDTO productDTO)
        {
            if(productDTO == null || string.Equals(productDTO.Name, "") || string.Equals(productDTO.Description, "")
                || productDTO.Quantity<0 || productDTO.Price<=0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
