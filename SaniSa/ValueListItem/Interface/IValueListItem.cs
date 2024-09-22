using ValueListItem.DTO;

namespace ValueListItem.Interface
{
    public interface IValueListItem
    {
        Task<ValueListItemDTO> Create(ValueListItemCreateRequestDTO reqDTO);
        Task Delete(ValueListItemDeleteRequestDTO reqDTO);
        Task<ValueListItemDTO> Update(ValueListItemUpdateRequestDTO reqDTO);
        Task<ValueListItemDTO> ReadById(ValueListItemReadByIdRequestDTO reqDTO);
        Task<ValueListItemList> ReadByValueListId(ValueListItemReadByValueListIdRequestDTO reqDTO);
        Task<ValueListItemList> ReadByVlCode(ValueListItemReadByVlCodeRequestDTO reqDTO);
        Task<ValueListItemList> ReadByVlName(ValueListItemReadByVlNameRequestDTO reqDTO);
    }
}
