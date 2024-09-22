using CategoryMaster.DTO;

namespace CategoryMaster.Interface
{
    public interface ICategoryMaster
    {
        Task<CategoryMasterDTO> Create(CategoryMasterCreateRequestDTO reqDTO);
        Task<CategoryMasterDTO> Update(CategoryMasterUpdateRequestDTO reqDTO);
        Task Delete(CategoryMasterDeleteRequestDTO reqDTO);
        Task<CategoryMasterDTO> ReadById(CategoryMasterReadByIdRequestDTO reqDTO);
        Task<CategoryMasterList> ReadAll();
    }
}
