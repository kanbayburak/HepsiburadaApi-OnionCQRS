using FluentValidation;
using HepsiburadaApi.Application.Bases;
using HepsiburadaApi.Application.Features.Auth.Rules;
using HepsiburadaApi.Application.Interfaces.AutoMapper;
using HepsiburadaApi.Application.Interfaces.UnitOfWorks;
using HepsiburadaApi.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HepsiburadaApi.Application.Features.Auth.Command.Revoke
{
    public class RevokeCommandHandler : BaseHandler, IRequestHandler<RevokeCommandRequest, Unit>
    {
        private readonly UserManager<User> userManager;
        private readonly AuthRules authRules;

        public RevokeCommandHandler(UserManager<User> userManager, AuthRules authRules, IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {
            this.userManager = userManager;
            this.authRules = authRules;
        }

        public async Task<Unit> Handle(RevokeCommandRequest request, CancellationToken cancellationToken)
        {
            User user = await userManager.FindByEmailAsync(request.Email);  //emailimi bul
            await authRules.EmailAddressShouldBeValid(user);  //eğer emaili bulamazsa  burada hata fırlatacak, bulursa aşağıdan devam edecek

            user.RefreshToken = null;  //burada refreshToken ı null yaptık
            await userManager.UpdateAsync(user);

            return Unit.Value;
        }
    }
}
