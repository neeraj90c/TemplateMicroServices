using MediatR;
using ProductCombo.DTO;
using ProductCombo.Interface;

namespace ProductCombo.Command
{
    public class ProductComboCreateCommand : IRequest<ProductComboDTO>
    {
        public ProductComboCreateRequestDTO reqDTO { get; set; }
    }
    internal class KitMasterCreateHandler : IRequestHandler<ProductComboCreateCommand, ProductComboDTO>
    {
        protected readonly IProductCombo _productCombo;
        public KitMasterCreateHandler(IProductCombo productCombo)
        {
            _productCombo = productCombo;
        }
        public async Task<ProductComboDTO> Handle(ProductComboCreateCommand request, CancellationToken cancellationToken)
        {
            return await _productCombo.Create(request.reqDTO);
        }
    }
}
