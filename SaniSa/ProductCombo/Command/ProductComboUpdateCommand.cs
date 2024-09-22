using MediatR;
using ProductCombo.DTO;
using ProductCombo.Interface;

namespace ProductCombo.Command
{
    public class ProductComboUpdateCommand : IRequest<ProductComboDTO>
    {
        public ProductComboUpdateRequestDTO reqDTO { get; set; }
    }
    internal class ProductComboUpdateHandler : IRequestHandler<ProductComboUpdateCommand, ProductComboDTO>
    {
        protected readonly IProductCombo _productCombo;

        public ProductComboUpdateHandler(IProductCombo productCombo)
        {
            _productCombo = productCombo;
        }
        public async Task<ProductComboDTO> Handle(ProductComboUpdateCommand request, CancellationToken cancellationToken)
        {
            return await _productCombo.Update(request.reqDTO);
        }
    }
}
