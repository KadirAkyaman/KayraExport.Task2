using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KayraExport.Domain.DTOs;
using KayraExport.Domain.Entities;

namespace KayraExport.Application.Interfaces
{
    public interface IUserService
    {
        Task<UserDto?> GetUserByIdAsync(int id);
        Task<User?> GetUserByEmailAsync(string email);
        Task AddUserAsync(RegisterUserDto registerUserDto);
        Task DeleteUserAsync(int id);
    }
}