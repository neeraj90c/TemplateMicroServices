using Common.DTO;
using BrandMaster.DTO;

namespace BrandMaster.Interface
{
    public interface IBrandMaster
    {
        Task<BrandMasterDTO> Create(BrandMasterCreateRequestDTO reqDTO);
        Task<BrandMasterDTO> Update(BrandMasterUpdateRequestDTO reqDTO);
        Task Delete(BrandMasterDeleteRequestDTO reqDTO);
        Task<BrandMasterDTO> ReadById(BrandMasterReadByIdRequestDTO reqDTO);
        Task<BrandMasterList> ReadAll();
        Task<BrandMasterList> ReadAllPaginated(BrandMasterReadAllPaginatedRequestDTO reqDTO);
    }
}
