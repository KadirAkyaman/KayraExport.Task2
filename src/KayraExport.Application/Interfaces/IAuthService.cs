using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KayraExport.Domain.DTOs;

namespace KayraExport.Application.Interfaces
{
    public interface IAuthService
    {
        Task<AuthResponseDto?> LoginUserAsync(LoginUserDto loginUserDto);
    }
}