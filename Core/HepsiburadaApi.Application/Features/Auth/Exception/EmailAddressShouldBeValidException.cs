using HepsiburadaApi.Application.Bases;

namespace HepsiburadaApi.Application.Features.Auth.Exception
{
    public class EmailAddressShouldBeValidException : BaseException
    {
        public EmailAddressShouldBeValidException() : base("Kullanıcı adı veya şifre yablıştır.") { }
    }
}
