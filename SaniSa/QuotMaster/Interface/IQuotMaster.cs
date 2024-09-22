using Common.DTO;
using QuotMaster.DTO;

namespace QuotMaster.Interface
{
    public interface IQuotMaster
    {
        Task<QuotMasterDTO> Create(QuotMasterCreateRequestDTO reqDTO);
        Task<QuotMasterDTO> Update(QuotMasterUpdateRequestDTO reqDTO);
        Task Delete(QuotMasterDeleteRequestDTO reqDTO);
        Task<QuotMasterDTO> ReadById(QuotMasterReadByIdRequestDTO reqDTO);
        Task<QuotMasterList> ReadAll();
        Task<QuotMasterList> ReadAllPaginated(QuotMasterReadAllPaginatedRequestDTO reqDTO);
    }
}
