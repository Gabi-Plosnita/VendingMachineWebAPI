using VendingMachine.Business.DTOs;
using VendingMachine.Business.Exceptions;
using VendingMachine.DataAccess.Entities;
using VendingMachine.DataAccess.Exceptions;
using VendingMachine.DataAccess.Repository;
using AutoMapper;

namespace VendingMachine.Business.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public ProductService(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public int CreateProduct(ProductDTO productDTO)
        {
            Product product = _mapper.Map<Product>(productDTO);
            _repository.CreateProduct(product);
            return product.Id;
        }

        public List<ProductDTO> GetProducts()
        {
            List<ProductDTO> productDTOList = new List<ProductDTO>();
            foreach (Product product in _repository.GetProducts())
            {
                ProductDTO productDTO = _mapper.Map<ProductDTO>(product);
                productDTOList.Add(productDTO);
            }
            return productDTOList;
        }

        public ProductDTO GetProduct(int id)
        {
            try
            {
                Product product = _repository.GetProduct(id);
                ProductDTO productDTO = _mapper.Map<ProductDTO>(product);
                return productDTO;
            }
            catch (InvalidIdException ex)
            {
                throw new IdException(ex.Message);
            }
        }

        public void UpdateProduct(int id, ProductDTO productDTO)
        {
            try
            {
                Product product = _mapper.Map<Product>(productDTO);
                product.Id = id;
                _repository.UpdateProduct(id, product);
            }
            catch (InvalidIdException ex)
            {
                throw new IdException(ex.Message);
            }
        }

        public void DeleteProduct(int id)
        {
            try
            {
                _repository.DeleteProduct(id);
            }
            catch (InvalidIdException ex)
            {
                throw new IdException(ex.Message);
            }
        }

    }

}