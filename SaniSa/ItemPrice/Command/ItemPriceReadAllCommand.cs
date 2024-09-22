using MediatR;
using ItemPrice.DTO;
using ItemPrice.Interface;

namespace ItemPrice.Command
{
    public class ItemPriceReadAllCommand : IRequest<ItemPriceList>
    {
    }
    internal class ItemPriceReadAllHandler : IRequestHandler<ItemPriceReadAllCommand, ItemPriceList>
    {
        protected readonly IItemPrice _itemPrice;

        public ItemPriceReadAllHandler(IItemPrice itemPrice)
        {
            _itemPrice = itemPrice;
        }
        public async Task<ItemPriceList> Handle(ItemPriceReadAllCommand request, CancellationToken cancellationToken)
        {
            return await _itemPrice.ReadAll();
        }
    }
}
