using MediatR;
using ItemMaster.DTO;
using ItemMaster.Interface;

namespace ItemMaster.Command
{
    public class ItemMasterReadByIdCommand : IRequest<ItemMasterDTO>
    {
        public ItemMasterReadByIdRequestDTO reqDTO { get; set; }
    }
    internal class ItemMasterReadByIdHandler : IRequestHandler<ItemMasterReadByIdCommand, ItemMasterDTO>
    {
        protected readonly IItemMaster _itemMaster;

        public ItemMasterReadByIdHandler(IItemMaster itemMaster)
        {
            _itemMaster = itemMaster;
        }
        public async Task<ItemMasterDTO> Handle(ItemMasterReadByIdCommand request, CancellationToken cancellationToken)
        {
            return await _itemMaster.ReadById(request.reqDTO);
        }
    }
}
