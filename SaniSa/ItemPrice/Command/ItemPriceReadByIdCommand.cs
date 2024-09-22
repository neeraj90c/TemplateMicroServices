using MediatR;
using ItemPrice.DTO;
using ItemPrice.Interface;

namespace ItemPrice.Command
{
    public class ItemPriceReadByIdCommand : IRequest<ItemPriceDTO>
    {
        public ItemPriceReadByIdRequestDTO reqDTO { get; set; }
    }
    internal class ItemMasterReadByIdHandler : IRequestHandler<ItemPriceReadByIdCommand, ItemPriceDTO>
    {
        protected readonly IItemPrice _itemPrice;

        public ItemMasterReadByIdHandler(IItemPrice itemPrice)
        {
            _itemPrice = itemPrice;
        }
        public async Task<ItemPriceDTO> Handle(ItemPriceReadByIdCommand request, CancellationToken cancellationToken)
        {
            return await _itemPrice.ReadById(request.reqDTO);
        }
    }
}
