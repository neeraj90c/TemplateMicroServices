using MediatR;
using ItemPrice.DTO;
using ItemPrice.Interface;

namespace ItemPrice.Command
{
    public class ItemPriceCreateCommand : IRequest<ItemPriceDTO>
    {
        public ItemPriceCreateRequestDTO reqDTO { get; set; }
    }
    internal class ItemPriceCreateHandler : IRequestHandler<ItemPriceCreateCommand, ItemPriceDTO>
    {
        protected readonly IItemPrice _itemPrice;

        public ItemPriceCreateHandler(IItemPrice itemPrice)
        {
            _itemPrice = itemPrice;
        }
        public async Task<ItemPriceDTO> Handle(ItemPriceCreateCommand request, CancellationToken cancellationToken)
        {
            return await _itemPrice.Create(request.reqDTO);
        }
    }
}
