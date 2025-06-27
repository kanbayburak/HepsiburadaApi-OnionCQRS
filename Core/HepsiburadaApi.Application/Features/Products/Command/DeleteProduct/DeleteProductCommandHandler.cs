using HepsiburadaApi.Application.Interfaces.UnitOfWorks;
using HepsiburadaApi.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Xsl;

namespace HepsiburadaApi.Application.Features.Products.Command.DeleteProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommandRequest>
    {
        private readonly IUnitOfWork unitOfWork;

        public DeleteProductCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
        {
            var product = await unitOfWork.GetReadRepository<Product>().GetAsync(x => x.Id == request.Id && !x.IsDeleted); //işlemdeki requestten product bulma
            product.IsDeleted = true;  //harddelete kullanmıyorum bu sayede

            await unitOfWork.GetWriteRepository<Product>().UpdateAsync(product);
            await unitOfWork.SaveAsync();
        }
    }
}
