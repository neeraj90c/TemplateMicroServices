using ItemMaster.DTO;
using ItemMaster.Interface;
using MediatR;

namespace ItemMaster.Command
{
    public class ItemMasterSearchByNameCommand : IRequest<ItemMasterList>
    {
        public ItemMasterSearchByNameRequestDTO reqDTO { get; set; }
    }
    internal class ItemMasterSearchByNameCommandHandler : IRequestHandler<ItemMasterSearchByNameCommand, ItemMasterList>
    {
        protected readonly IItemMaster _itemMaster;
        public ItemMasterSearchByNameCommandHandler(IItemMaster itemMaster)
        {
            _itemMaster = itemMaster;
        }

        public async Task<ItemMasterList> Handle(ItemMasterSearchByNameCommand request, CancellationToken cancellationToken)
        {
            return await _itemMaster.SearchByName(request.reqDTO);
        }
    }
}
