using AzureAuth.DTO;

namespace AzureAuth.Interface
{
    public interface IAzureAuth
    {
        Task<AzureAuthDTO> Create(AzureAuthCreateRequestDTO reqDTO);
        Task<AzureAuthDTO> Update(AzureAuthUpdateRequestDTO reqDTO);
        Task Delete(AzureAuthDeleteRequestDTO reqDTO);
        Task<AzureAuthDTO> ReadById(AzureAuthReadByIdRequestDTO reqDTO);
        Task<AzureAuthDTO> ReadByAzureUUId(AzureAuthReadByAzureUUIdRequestDTO reqDTO);
        Task<AzureAuthList> ReadAll();
    }
}
