using Common.DTO;
using ProductCombo.DTO;

namespace ProductCombo.Interface
{
    public interface IProductCombo
    {
        Task<ProductComboDTO> Create(ProductComboCreateRequestDTO reqDTO);
        Task<ProductComboDTO> Update(ProductComboUpdateRequestDTO reqDTO);
        Task Delete(ProductComboDeleteRequestDTO reqDTO);
        Task<ProductComboDTO> ReadById(ProductComboReadByIdRequestDTO reqDTO);
        Task<ProductComboList> ReadAll();
    }
}
