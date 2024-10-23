using EventDetail.DTO;

namespace EventDetail.Interface
{
    public interface IEventDetail
    {
        Task<EventDetailResponseDTO> Create (EventDetailCreateRequestDTO request);
        Task<EventDetailResponseDTO> Update(EventDetailUpdateRequestDTO request);
        Task<EventDetailResponseDTO> Delete(EventDetailDeleteRequestDTO request);
        Task<EventDetailList> ReadAll();
        Task<EventDetailResponseDTO> ReadById(EventDetailReadByIdRequestDTO request);
        Task<EventDetailList> ReadByEventId(EventdetailReadByEventIdRequestDTO request);
        Task<EventDetailList> ReadByItemId(EventdetailReadByItemIdRequestDTO request);

    }
}
