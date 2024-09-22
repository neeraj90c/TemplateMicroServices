using Common.DTO;
using KitDetail.DTO;

namespace KitDetail.Interface
{
    public interface IKitDetail
    {
        Task<KitDetailDTO> Create(KitDetailCreateRequestDTO reqDTO);
        Task<KitDetailDTO> Update(KitDetailUpdateRequestDTO reqDTO);
        Task Delete(KitDetailDeleteRequestDTO reqDTO);
        Task<KitDetailDTO> ReadById(KitDetailReadByIdRequestDTO reqDTO);
        Task<KitDetailDTO> ReadByKitId(KitDetailReadByKitIdRequestDTO reqDTO);
        Task<KitDetailList> ReadAll();
    }
}
