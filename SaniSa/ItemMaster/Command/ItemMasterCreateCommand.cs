using MediatR;
using ItemMaster.DTO;
using ItemMaster.Interface;

namespace ItemMaster.Command
{
    public class ItemMasterCreateCommand : IRequest<ItemMasterDTO>
    {
        public ItemMasterCreateRequestDTO reqDTO { get; set; }
    }
    internal class ItemMasterCreateHandler : IRequestHandler<ItemMasterCreateCommand, ItemMasterDTO>
    {
        protected readonly IItemMaster _itemMaster;

        public ItemMasterCreateHandler(IItemMaster itemMaster)
        {
            _itemMaster = itemMaster;
        }
        public async Task<ItemMasterDTO> Handle(ItemMasterCreateCommand request, CancellationToken cancellationToken)
        {
            return await _itemMaster.Create(request.reqDTO);
        }
    }
}
