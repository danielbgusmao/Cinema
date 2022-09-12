using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Domain.Entities
{
    public class Token
    {
        public byte[] Chave { get; set; }
        
        public string Secret { get; set; }

        public SecurityTokenDescriptor TokenDescriptor { get; set; }

        public JwtSecurityTokenHandler TokenHandler { get; set; }

        public SigningCredentials SigningCredentials { get; set; }
    }
}
