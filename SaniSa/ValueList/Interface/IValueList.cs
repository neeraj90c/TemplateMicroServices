using ValueList.DTO;

namespace ValueList.Interface
{
    public interface IValueList
    {
        Task<ValueListDTO> Create(ValueListCreateRequestDTO reqDTO);
        Task Delete(ValueListDeleteRequestDTO reqDTO);
        Task<ValueListDTO> Update(ValueListUpdateRequestDTO reqDTO);
        Task<ValueListDTO> ReadById(ValueListReadByIdRequestDTO reqDTO);
        Task<ValueListList> ReadAll();
    }
}
