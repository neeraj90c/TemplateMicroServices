using MediatR;
using ProductCombo.DTO;
using ProductCombo.Interface;

namespace ProductCombo.Command
{
    public class ProductComboReadAllPaginatedCommand : IRequest<ProductComboList>
    {
        public ProductComboReadAllPaginatedRequestDTO reqDTO {  get; set; }
    }
    internal class ProductComboReadAllPaginatedHandler : IRequestHandler<ProductComboReadAllPaginatedCommand, ProductComboList>
    {
        protected readonly IProductCombo _productCombo;

        public ProductComboReadAllPaginatedHandler(IProductCombo productCombo)
        {
            _productCombo = productCombo;
        }
        public async Task<ProductComboList> Handle(ProductComboReadAllPaginatedCommand request, CancellationToken cancellationToken)
        {
            return await _productCombo.ReadAllPaginated(request.reqDTO);
        }
    }
}


