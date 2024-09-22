using Common.DTO;
using PackagingMaster.DTO;

namespace PackagingMaster.Interface
{
    public interface IPackagingMaster
    {
        Task<PackagingMasterDTO> Create(PackagingMasterCreateRequestDTO reqDTO);
        Task<PackagingMasterDTO> Update(PackagingMasterUpdateRequestDTO reqDTO);
        Task Delete(PackagingMasterDeleteRequestDTO reqDTO);
        Task<PackagingMasterDTO> ReadById(PackagingMasterReadByIdRequestDTO reqDTO);
        Task<PackagingMasterList> ReadAll();
        Task<PackagingMasterList> ReadAllPaginated(PackagingMasterReadAllPaginatedRequestDTO reqDTO);
    }
}
