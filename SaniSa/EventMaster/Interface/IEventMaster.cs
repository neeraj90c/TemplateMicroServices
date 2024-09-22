using EventMaster.DTO;

namespace EventMaster.Interface
{
    public interface IEventMaster
    {
        Task<EventMasterResponseDTO> Create (EventMasterCreateRequestDTO request);
        Task<EventMasterResponseDTO> Update(EventMasterUpdateRequestDTO request);
        Task<EventMasterResponseDTO> Delete(EventMasterDeleteRequestDTO request);
        Task<EventList> ReadAll();
        Task<EventMasterResponseDTO> ReadByEventId(EventMasterReadByEventIdRequestDTO request);

    }
}
