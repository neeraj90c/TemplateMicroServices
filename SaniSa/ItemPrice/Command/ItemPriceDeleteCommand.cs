using MediatR;
using ItemPrice.DTO;
using ItemPrice.Interface;

namespace ItemPrice.Command
{
    public class ItemPriceDeleteCommand : IRequest
    {
        public ItemPriceDeleteRequestDTO reqDTO { get; set; }
    }
    internal class ItemPriceDeleteHandler : IRequestHandler<ItemPriceDeleteCommand>
    {
        protected readonly IItemPrice _itemPrice;

        public ItemPriceDeleteHandler(IItemPrice itemPrice)
        {
            _itemPrice = itemPrice;
        }
        public async Task Handle(ItemPriceDeleteCommand request, CancellationToken cancellationToken)
        {
            await _itemPrice.Delete(request.reqDTO);
        }
    }
}
