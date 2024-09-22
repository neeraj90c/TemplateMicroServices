using Common.DTO;
using MediatR;
using ItemMaster.DTO;
using ItemMaster.Interface;

namespace ItemMaster.Command
{
    public class ItemMasterReadAllPaginatedCommand : IRequest<ItemMasterList>
    {
        public ItemMasterReadAllPaginatedRequestDTO reqDTO { get; set; }
    }
    internal class ItemMasterReadAllPaginatedHandler : IRequestHandler<ItemMasterReadAllPaginatedCommand, ItemMasterList>
    {
        protected readonly IItemMaster _itemMaster;

        public ItemMasterReadAllPaginatedHandler(IItemMaster itemMaster)
        {
            _itemMaster = itemMaster;
        }
        public async Task<ItemMasterList> Handle(ItemMasterReadAllPaginatedCommand request, CancellationToken cancellationToken)
        {
            return await _itemMaster.ReadAllPaginated(request.reqDTO);
        }
    }
}
