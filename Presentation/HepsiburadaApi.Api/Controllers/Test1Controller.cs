using HepsiburadaApi.Application.Interfaces.UnitOfWorks;
using HepsiburadaApi.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HepsiburadaApi.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class Test1Controller : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public Test1Controller(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await unitOfWork.GetReadRepository<Product>().GetAllAsync());
        }
    }
}
