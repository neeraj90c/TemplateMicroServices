using EventDetail.DTO;
using EventDetail.Interface;
using MediatR;

namespace EventDetail.Command
{
    public class EventDetailDeleteCommand : IRequest<EventDetailResponseDTO>
    {
        public EventDetailDeleteRequestDTO? reqDTO { get; set; }
    }
    internal class EventDetailDeleteHandler : IRequestHandler<EventDetailDeleteCommand, EventDetailResponseDTO>
    {
        protected readonly IEventDetail _eventDetail;
        public EventDetailDeleteHandler(IEventDetail eventDetail)
        {
            _eventDetail = eventDetail;
        }
        public async Task<EventDetailResponseDTO> Handle(EventDetailDeleteCommand request, CancellationToken cancellationToken)
        {
            return await _eventDetail.Delete(request.reqDTO);
        }
    }
}
