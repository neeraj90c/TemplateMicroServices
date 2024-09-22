using ItemMaster.DTO;
using ItemMaster.Interface;
using MediatR;

namespace ItemMaster.Command
{
    public class ItemMasterReadByKitIdCommand : IRequest<ItemMasterList>
    {
        public ItemMasterReadByKitIdRequestDTO reqDTO { get; set; }
    }
    internal class ItemMasterReadByKitIdHandler : IRequestHandler<ItemMasterReadByKitIdCommand, ItemMasterList>
    {
        protected readonly IItemMaster _itemMaster;

        public ItemMasterReadByKitIdHandler(IItemMaster itemMaster)
        {
            _itemMaster = itemMaster;
        }
        public async Task<ItemMasterList> Handle(ItemMasterReadByKitIdCommand request, CancellationToken cancellationToken)
        {
            return await _itemMaster.ReadByKitId(request.reqDTO);
        }
    }
}
