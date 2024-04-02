using VendingMachine.Business.DTOs;

namespace VendingMachine.Business.Services
{
    public interface IProductService
    {

        int CreateProduct(ProductDTO productDTO);

        List<ProductDTO> GetProducts();

        ProductDTO GetProduct(int id);

        void UpdateProduct(int id, ProductDTO productDTO);

        void DeleteProduct(int id);
    }
}
