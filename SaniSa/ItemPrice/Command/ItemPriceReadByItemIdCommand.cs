using ItemPrice.DTO;
using ItemPrice.Interface;
using MediatR;

namespace ItemPrice.Command
{
    public class ItemPriceReadByItemIdCommand : IRequest<ItemPriceDTO>
    {
        public ItemPriceReadByItemIdRequestDTO reqDTO { get; set; }
    }

    internal class ItemPriceReadByItemIdCommandHandler : IRequestHandler<ItemPriceReadByItemIdCommand, ItemPriceDTO>
    {
        protected readonly IItemPrice _itemPrice;
        public ItemPriceReadByItemIdCommandHandler(IItemPrice itemPrice)
        {
            _itemPrice = itemPrice;
        }

        public async Task<ItemPriceDTO> Handle(ItemPriceReadByItemIdCommand request, CancellationToken cancellationToken)
        {
            return await _itemPrice.ReadByItemId(request.reqDTO);
        }
    }
}
