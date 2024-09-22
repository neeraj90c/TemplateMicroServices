using Common.DTO;
using ItemMaster.DTO;

namespace ItemMaster.Interface
{
    public interface IItemMaster
    {
        Task<ItemMasterDTO> Create(ItemMasterCreateRequestDTO reqDTO);
        Task<ItemMasterDTO> Update(ItemMasterUpdateRequestDTO reqDTO);
        Task Delete(ItemMasterrDeleteRequestDTO reqDTO);
        Task<ItemMasterDTO> ReadById(ItemMasterReadByIdRequestDTO reqDTO);
        Task<ItemMasterList> ReadAll();
        Task<ItemMasterList> ReadAllPaginated(ItemMasterReadAllPaginatedRequestDTO reqDTO);
        Task<ItemMasterList> ReadByKitId(ItemMasterReadByKitIdRequestDTO reqDTO);
    }
}
