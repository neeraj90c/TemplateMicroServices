using Common.DTO;
using ComboDetail.DTO;

namespace ComboDetail.Interface
{
    public interface IComboDetail
    {
        Task<ComboDetailDTO> Create(ComboDetailCreateRequestDTO reqDTO);
        Task<ComboDetailDTO> Update(ComboDetailUpdateRequestDTO reqDTO);
        Task Delete(ComboDetailDeleteRequestDTO reqDTO);
        Task<ComboDetailDTO> ReadById(ComboDetailReadByDetailIdRequestDTO reqDTO);
        Task<ComboDetailDTO> ReadByComboId(ComboDetailReadByComboIdRequestDTO reqDTO);
        Task<ComboDetailList> ReadAll();
    }
}
