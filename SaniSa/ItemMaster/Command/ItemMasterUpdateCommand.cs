using MediatR;
using ItemMaster.DTO;
using ItemMaster.Interface;

namespace ItemMaster.Command
{
    public class ItemMasterUpdateCommand : IRequest<ItemMasterDTO>
    {
        public ItemMasterUpdateRequestDTO reqDTO { get; set; }
    }
    internal class ItemMasterUpdateHandler : IRequestHandler<ItemMasterUpdateCommand, ItemMasterDTO>
    {
        protected readonly IItemMaster _itemMaster;

        public ItemMasterUpdateHandler(IItemMaster itemMaster)
        {
            _itemMaster = itemMaster;
        }
        public async Task<ItemMasterDTO> Handle(ItemMasterUpdateCommand request, CancellationToken cancellationToken)
        {
            return await _itemMaster.Update(request.reqDTO);
        }
    }
}
