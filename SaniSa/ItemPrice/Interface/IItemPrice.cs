using Common.DTO;
using ItemPrice.DTO;

namespace ItemPrice.Interface
{
    public interface IItemPrice
    {
        Task<ItemPriceDTO> Create(ItemPriceCreateRequestDTO reqDTO);
        Task<ItemPriceDTO> Update(ItemPriceUpdateRequestDTO reqDTO);
        Task Delete(ItemPriceDeleteRequestDTO reqDTO);
        Task<ItemPriceDTO> ReadById(ItemPriceReadByIdRequestDTO reqDTO);
        Task<ItemPriceDTO> ReadByItemId(ItemPriceReadByItemIdRequestDTO reqDTO);
        Task<ItemPriceList> ReadAll();
    }
}
