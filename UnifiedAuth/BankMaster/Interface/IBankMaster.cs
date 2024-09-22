using BankMaster.DTO;
using Common.DTO;

namespace BankMaster.Interface
{
    public interface IBankMaster
    {
        Task<BankMasterDTO> Create(BankMasterCreateRequestDTO reqDTO);
        Task<BankMasterDTO> Update(BankMasterUpdateRequestDTO reqDTO);
        Task Delete(BankMasterDeleteRequestDTO reqDTO);
        Task<BankMasterDTO> ReadById(BankMasterReadByIdRequestDTO reqDTO);
        Task<BankMasterList> ReadAll();
        Task<BankMasterList> ReadAllPaginated(PaginationDTO reqDTO);
    }
}
