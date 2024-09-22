using MediatR;
using ProductCombo.DTO;
using ProductCombo.Interface;

namespace ProductCombo.Command
{
    public class ProductComboDeleteCommand : IRequest
    {
        public ProductComboDeleteRequestDTO reqDTO { get; set; }
    }
    internal class ProductComboDeleteHandler : IRequestHandler<ProductComboDeleteCommand>
    {
        protected readonly IProductCombo _productCombo;

        public ProductComboDeleteHandler(IProductCombo productCombo)
        {
            _productCombo = productCombo;
        }
        public async Task Handle(ProductComboDeleteCommand request, CancellationToken cancellationToken)
        {
            await _productCombo.Delete(request.reqDTO);
        }
    }
}
