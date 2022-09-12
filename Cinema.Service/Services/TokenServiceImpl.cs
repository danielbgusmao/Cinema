using Cinema.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cinema.Domain.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Cinema.Domain.Models;

namespace Cinema.Service.Services
{
    public class TokenServiceImpl : ITokenService
    {
        private readonly IFilmeRepository _baseRepository;
        private readonly IMapper _mapper;

        public TokenServiceImpl(IFilmeRepository baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }

        public async Task<TokenResponse> GenerateToken(Usuario usuario)
        {              
            var claim = new List<Claim>
                {
                    new Claim("UsuarioId", usuario.Id.ToString()),
                    new Claim(ClaimTypes.Name, usuario.Nome),
                    new Claim(ClaimTypes.Email, usuario.Email)
                };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Settings.Secret));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken
                (
                    issuer: "localhost:7103",
                    audience: "localhost:7103",
                    expires: DateTime.Now.AddHours(8),
                    signingCredentials: creds
                );

            return new TokenResponse
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token)
            };

        }
    }
}
