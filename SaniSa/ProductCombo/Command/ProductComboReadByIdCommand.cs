using MediatR;
using ProductCombo.DTO;
using ProductCombo.Interface;

namespace ProductCombo.Command
{
    public class ProductComboReadByIdCommand : IRequest<ProductComboDTO>
    {
        public ProductComboReadByIdRequestDTO reqDTO { get; set; }
    }
    internal class ProductComboReadByIdHandler : IRequestHandler<ProductComboReadByIdCommand, ProductComboDTO>
    {
        protected readonly IProductCombo _productCombo;

        public ProductComboReadByIdHandler(IProductCombo productCombo)
        {
            _productCombo = productCombo;
        }
        public async Task<ProductComboDTO> Handle(ProductComboReadByIdCommand request, CancellationToken cancellationToken)
        {
            return await _productCombo.ReadById(request.reqDTO);
        }
    }
}
