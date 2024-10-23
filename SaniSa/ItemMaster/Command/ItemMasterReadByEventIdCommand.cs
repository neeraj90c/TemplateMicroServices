using ItemMaster.DTO;
using ItemMaster.Interface;
using MediatR;

namespace ItemMaster.Command
{
    public class ItemMasterReadByEventIdCommand : IRequest<ItemMasterList>
    {
        public ItemMasterReadByEventIdRequestDTO reqDTO { get; set; }
    }
    internal class ItemMasterReadByEventIdHandler : IRequestHandler<ItemMasterReadByEventIdCommand, ItemMasterList>
    {
        protected readonly IItemMaster _itemMaster;

        public ItemMasterReadByEventIdHandler(IItemMaster itemMaster)
        {
            _itemMaster = itemMaster;
        }
        public async Task<ItemMasterList> Handle(ItemMasterReadByEventIdCommand request, CancellationToken cancellationToken)
        {
            return await _itemMaster.ReadByEventId(request.reqDTO);
        }
    }
}
