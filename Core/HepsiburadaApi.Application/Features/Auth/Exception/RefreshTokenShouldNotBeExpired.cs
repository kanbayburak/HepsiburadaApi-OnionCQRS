using HepsiburadaApi.Application.Bases;

namespace HepsiburadaApi.Application.Features.Auth.Exception
{
    public class RefreshTokenShouldNotBeExpired : BaseException
    {
        public RefreshTokenShouldNotBeExpired() : base("Oturum açma süresi sona ermiştir. Lütfen tekrar giriş yağın.") { }
    }
}
