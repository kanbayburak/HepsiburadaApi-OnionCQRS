using HepsiburadaApi.Domain.Common;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HepsiburadaApi.Domain.Entities
{
    public class User : IdentityUser<Guid>   //burada userları hangi tür keyle tutacaksın diyor, hiçbir şey vermezsek default olarak int verir
    {
        public string FullName { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiryTime { get; set; }
    }
}
