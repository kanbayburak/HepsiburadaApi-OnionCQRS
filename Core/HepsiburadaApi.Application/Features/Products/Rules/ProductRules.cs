using HepsiburadaApi.Application.Bases;
using HepsiburadaApi.Application.Features.Products.Exceptions;
using HepsiburadaApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HepsiburadaApi.Application.Features.Products.Rules
{
    public class ProductRules :BaseRules
    {
        public Task ProductTitleMustNotBeSame(IList<Product> products, string requestTitle) 
        {
            if (products.Any(x => x.Title == requestTitle)) throw new ProductTitleMustNotBeSameException();
            return Task.CompletedTask;
        }
    }
}
