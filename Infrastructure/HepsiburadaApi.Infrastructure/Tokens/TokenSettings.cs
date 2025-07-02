using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HepsiburadaApi.Infrastructure.Tokens
{
    public class TokenSettings
    {
        public string Auidence { get; set; }
        public string Issuer { get; set; }
        public string Secret { get; set; }
        public int TokenValidityInMunitues { get; set; }
    }
}
