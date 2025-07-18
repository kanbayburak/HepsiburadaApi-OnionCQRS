﻿using HepsiburadaApi.Application.Features.Products.Command.CreateProduct;
using HepsiburadaApi.Application.Features.Products.Command.DeleteProduct;
using HepsiburadaApi.Application.Features.Products.Command.UpdateProduct;
using HepsiburadaApi.Application.Features.Products.Queries.GetAllProducts;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HepsiburadaApi.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator mediator;
        public ProductController(IMediator mediator)
        {
            this.mediator = mediator;
        }


        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllProducts()
        {
            var response = await mediator.Send(new GetAllProductsQueryRequest());

            return Ok(response);
        }



        [HttpPost]
        public async Task<IActionResult> CreateProducts(CreateProductCommandRequest request)
        {
            await mediator.Send(request);

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProducts(UpdateProductCommandRequest request)
        {
            await mediator.Send(request);

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteProducts(DeleteProductCommandRequest request)
        {
            await mediator.Send(request);

            return Ok();
        }
    }
}
