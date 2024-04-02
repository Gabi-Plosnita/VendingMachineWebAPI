using VendingMachine.DataAccess.Entities;

namespace VendingMachine.DataAccess.Repository
{
    public interface IRepository
    {

        int CreateProduct(Product product);

        List<Product> GetProducts();

        Product GetProduct(int id);

        void UpdateProduct(int id, Product updatedProduct);

        void DeleteProduct(int id);

    }
}
