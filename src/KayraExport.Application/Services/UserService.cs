using System.Threading.Tasks;
using AutoMapper;
using KayraExport.Application.Interfaces;
using KayraExport.Domain.DTOs;
using KayraExport.Domain.Entities;
using KayraExport.Domain.Exceptions;
using KayraExport.Domain.Interfaces;

namespace KayraExport.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddUserAsync(RegisterUserDto registerUserDto)
        {
            var user = _mapper.Map<User>(registerUserDto);
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(registerUserDto.Password);
            await _unitOfWork.UserRepository.AddAsync(user);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(int id)
        {
            var user = await _unitOfWork.UserRepository.GetByIdAsync(id);

            if (user is null)
                throw new NotFoundException($"User with Id {id} not found");

            _unitOfWork.UserRepository.Delete(user);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<User?> GetUserByEmailAsync(string email)
        {
            var user = await _unitOfWork.UserRepository.GetByEmailAsync(email);

            if (user is null)
                throw new NotFoundException($"User with Email: {email} not found");

            return user;
        }

        public async Task<UserDto?> GetUserByIdAsync(int id)
        {
            var user = await _unitOfWork.UserRepository.GetByIdAsync(id);

            if (user is null)
                throw new NotFoundException($"User with Id {id} not found");

            return _mapper.Map<UserDto>(user);
        }
    }
}
