using ItemMaster.DTO;
using ItemMaster.Interface;
using MediatR;

namespace ItemMaster.Command
{
    public class ItemMasterReadByCategoryIdCommand : IRequest<ItemMasterList>
    {
        public ItemMasterReadByCategoryIdRequestDTO reqDTO { get; set; }
    }
    internal class ItemMasterReadByCategoryIdHandler : IRequestHandler<ItemMasterReadByCategoryIdCommand, ItemMasterList>
    {
        protected readonly IItemMaster _itemMaster;

        public ItemMasterReadByCategoryIdHandler(IItemMaster itemMaster)
        {
            _itemMaster = itemMaster;
        }
        public async Task<ItemMasterList> Handle(ItemMasterReadByCategoryIdCommand request, CancellationToken cancellationToken)
        {
            return await _itemMaster.ReadByCategoryId(request.reqDTO);
        }
    }
}
