using CompanyMaster.DTO;

namespace CompanyMaster.Interface
{
    public interface ICompanyMaster
    {
        Task<CompanyMasterDTO> Create(CompanyMasterCreateRequestDTO reqDTO);
        Task<CompanyMasterDTO> Update(CompanyMasterUpdateRequestDTO reqDTO);
        Task Delete(CompanyMasterDeleteRequestDTO reqDTO);
        Task<CompanyMasterDTO> ReadById(CompanyMasterReadByIdRequestDTO reqDTO);
        Task<CompanyMasterList> ReadAll();
    }
}
