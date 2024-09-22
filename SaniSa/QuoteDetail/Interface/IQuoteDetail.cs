using Common.DTO;
using QuoteDetail.DTO;

namespace QuoteDetail.Interface
{
    public interface IQuoteDetail
    {
        Task<QuoteDetailDTO> Create(QuoteDetailCreateRequestDTO reqDTO);
        Task<QuoteDetailDTO> Update(QuoteDetailUpdateRequestDTO reqDTO);
        Task Delete(QuoteDetailDeleteRequestDTO reqDTO);
        Task<QuoteDetailDTO> ReadById(QuoteDetailReadByIdRequestDTO reqDTO);
        Task<QuoteDetailDTO> ReadByQuotId(QuoteDetailReadByQuotIdRequestDTO reqDTO);
        Task<QuoteDetailList> ReadAll();
    }
}
