using MediatR;
using ItemPrice.DTO;
using ItemPrice.Interface;

namespace ItemPrice.Command
{
    public class ItemPriceUpdateCommand : IRequest<ItemPriceDTO>
    {
        public ItemPriceUpdateRequestDTO reqDTO { get; set; }
    }
    internal class ItemMasterUpdateHandler : IRequestHandler<ItemPriceUpdateCommand, ItemPriceDTO>
    {
        protected readonly IItemPrice _itemPrice;

        public ItemMasterUpdateHandler(IItemPrice itemPrice)
        {
            _itemPrice = itemPrice;
        }
        public async Task<ItemPriceDTO> Handle(ItemPriceUpdateCommand request, CancellationToken cancellationToken)
        {
            return await _itemPrice.Update(request.reqDTO);
        }
    }
}
