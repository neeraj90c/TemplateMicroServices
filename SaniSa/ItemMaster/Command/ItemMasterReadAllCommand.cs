using MediatR;
using ItemMaster.DTO;
using ItemMaster.Interface;

namespace ItemMaster.Command
{
    public class ItemMasterReadAllCommand : IRequest<ItemMasterList>
    {
    }
    internal class ItemMasterReadAllHandler : IRequestHandler<ItemMasterReadAllCommand, ItemMasterList>
    {
        protected readonly IItemMaster _itemMaster;

        public ItemMasterReadAllHandler(IItemMaster itemMaster)
        {
            _itemMaster = itemMaster;
        }
        public async Task<ItemMasterList> Handle(ItemMasterReadAllCommand request, CancellationToken cancellationToken)
        {
            return await _itemMaster.ReadAll();
        }
    }
}
