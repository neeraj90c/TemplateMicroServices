using Common.DTO;
using KitMaster.DTO;

namespace KitMaster.Interface
{
    public interface IKitMaster
    {
        Task<KitMasterDTO> Create(KitMasterCreateRequestDTO reqDTO);
        Task<KitMasterDTO> Update(KitMasterUpdateRequestDTO reqDTO);
        Task Delete(KitMasterDeleteRequestDTO reqDTO);
        Task<KitMasterDTO> ReadById(KitMasterReadByIdRequestDTO reqDTO);
        Task<KitMasterList> ReadAll();
        Task<KitMasterList> ReadAllPaginated(KitMasterReadAllPaginatedRequestDTO reqDTO);
    }
}
