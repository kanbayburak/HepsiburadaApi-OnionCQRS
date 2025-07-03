using HepsiburadaApi.Application.Bases;

namespace HepsiburadaApi.Application.Features.Auth.Exception
{
    public class EmailOrPasswordShouldNotBeValidException : BaseException
    {
        public EmailOrPasswordShouldNotBeValidException() : base("Oturum açma süresi sona ermiştir. Lütfen tekrar giriş yağın.") { }
    }
}
