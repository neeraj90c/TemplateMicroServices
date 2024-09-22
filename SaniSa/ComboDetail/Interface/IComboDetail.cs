using Common.DTO;
using ComboDetail.DTO;

namespace ComboDetail.Interface
{
    public interface IComboDetail
    {
        Task<ComboDetailDTO> Create(ComboDetailCreateRequestDTO reqDTO);
        Task<ComboDetailDTO> ReadByItemId(ComboDetailReadByItemIdRequestDTO reqDTO);
        Task Delete(ComboDetailDeleteRequestDTO reqDTO);
        Task<ComboDetailDTO> ReadById(ComboDetailReadByIdRequestDTO reqDTO);
        Task<ComboDetailDTO> ReadByComboId(ComboDetailReadByComboIdRequestDTO reqDTO);
        Task<ComboDetailList> ReadAll();
    }
}
