using HepsiburadaApi.Application.Bases;

namespace HepsiburadaApi.Application.Features.Auth.Exception
{
    public class UserAlreadyExistException : BaseException
    {
        public UserAlreadyExistException() : base("Böyle bir kullanıcı zaten var!") { }
    }
}
