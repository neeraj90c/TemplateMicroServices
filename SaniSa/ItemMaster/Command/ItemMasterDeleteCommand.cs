using MediatR;
using ItemMaster.DTO;
using ItemMaster.Interface;

namespace ItemMaster.Command
{
    public class ItemMasterDeleteCommand : IRequest
    {
        public ItemMasterrDeleteRequestDTO reqDTO { get; set; }
    }
    internal class ItemMasterDeleteHandler : IRequestHandler<ItemMasterDeleteCommand>
    {
        protected readonly IItemMaster _itemMaster;

        public ItemMasterDeleteHandler(IItemMaster itemMaster)
        {
            _itemMaster = itemMaster;
        }
        public async Task Handle(ItemMasterDeleteCommand request, CancellationToken cancellationToken)
        {
            await _itemMaster.Delete(request.reqDTO);
        }
    }
}
