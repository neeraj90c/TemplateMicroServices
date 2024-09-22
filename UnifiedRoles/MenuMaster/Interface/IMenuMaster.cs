using MenuMaster.DTO;

namespace MenuMaster.Interface
{
    public interface IMenuMaster
    {
        Task<MenuMasterDTO> Create(MenuMasterCreateRequestDTO reqDTO);
        Task<MenuMasterDTO> Update(MenuMasterUpdateRequestDTO reqDTO);
        Task Delete(MenuMasterDeleteRequestDTO reqDTO);
        Task<MenuMasterDTO> ReadById(MenuMasterReadByIdRequestDTO reqDTO);
        Task<MenuMasterList> ReadAll();
        Task<MenuMasterList> ReadByProjectId(MenuMasterReadByProjectIdRequestDTO reqDTO);
    }
}
