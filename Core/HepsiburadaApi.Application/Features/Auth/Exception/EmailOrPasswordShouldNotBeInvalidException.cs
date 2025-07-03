using HepsiburadaApi.Application.Bases;

namespace HepsiburadaApi.Application.Features.Auth.Exception
{
    public class EmailOrPasswordShouldNotBeInvalidException : BaseException
    {
        public EmailOrPasswordShouldNotBeInvalidException() : base("Kullanıcı adı veya şifre yablıştır.") { }
    }
}
