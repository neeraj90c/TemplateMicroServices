using MediatR;
using ProductCombo.DTO;
using ProductCombo.Interface;

namespace ProductCombo.Command
{
    public class ProductComboReadAllCommand : IRequest<ProductComboList>
    {
    }
    internal class ProductComboReadAllHandler : IRequestHandler<ProductComboReadAllCommand, ProductComboList>
    {
        protected readonly IProductCombo _productCombo;

        public ProductComboReadAllHandler(IProductCombo productCombo)
        {
            _productCombo = productCombo;
        }
        public async Task<ProductComboList> Handle(ProductComboReadAllCommand request, CancellationToken cancellationToken)
        {
            return await _productCombo.ReadAll();
        }
    }
}
