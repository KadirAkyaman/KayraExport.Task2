using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using KayraExport.Application.Interfaces;
using KayraExport.Domain.DTOs;
using KayraExport.Domain.Entities;
using KayraExport.Domain.Exceptions;
using KayraExport.Domain.Interfaces;

namespace KayraExport.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddProductAsync(CreateProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            await _unitOfWork.ProductRepository.AddAsync(product);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteProductAsync(int id)
        {
            var product = await _unitOfWork.ProductRepository.GetByIdAsync(id);

            if (product == null)
                throw new NotFoundException($"Product with Id {id} not found");

            _unitOfWork.ProductRepository.Delete(product);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<ProductDto>> GetAllProductsAsync()
        {
            var products = await _unitOfWork.ProductRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ProductDto>>(products);
        }

        public async Task<ProductDto?> GetProductByIdAsync(int id)
        {
            var product = await _unitOfWork.ProductRepository.GetByIdAsync(id);

            if (product == null)
                throw new NotFoundException($"Product with Id {id} not found");

            return _mapper.Map<ProductDto>(product);
        }

        public async Task UpdateProductAsync(int id, UpdateProductDto productDto)
        {
            var product = await _unitOfWork.ProductRepository.GetByIdAsync(id);

            if (product == null)
                throw new NotFoundException($"Product with Id {id} not found");

            _mapper.Map(productDto, product);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
