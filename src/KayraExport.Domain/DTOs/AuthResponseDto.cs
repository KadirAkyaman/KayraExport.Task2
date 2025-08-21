using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KayraExport.Domain.DTOs
{
    public class AuthResponseDto
    {
        public string Token { get; set; } = string.Empty;
        public DateTime ExpiresAt { get; set; }
        public string Email { get; set; } = string.Empty;
    }
}