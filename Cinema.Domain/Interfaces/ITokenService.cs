using Cinema.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cinema.Domain.Models;

namespace Cinema.Domain.Interfaces
{
    public interface ITokenService
    {
        Task<TokenResponse> GenerateToken(Usuario usuario);
    }
}
