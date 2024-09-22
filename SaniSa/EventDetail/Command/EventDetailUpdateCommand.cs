using EventDetail.DTO;
using EventDetail.Interface;
using MediatR;

namespace EventDetail.Command
{
    public class EventDetailUpdateCommand : IRequest<EventDetailResponseDTO>
    {
        public EventDetailUpdateRequestDTO reqDTO { get; set; }
    }
    internal class EventDetailUpdateHandler : IRequestHandler<EventDetailUpdateCommand, EventDetailResponseDTO>
    {
        protected readonly IEventDetail _eventDetail;
        public EventDetailUpdateHandler(IEventDetail eventDetail)
        {
            _eventDetail = eventDetail;
        }
        public async Task<EventDetailResponseDTO> Handle(EventDetailUpdateCommand request, CancellationToken cancellationToken)
        {
            return await _eventDetail.Update(request.reqDTO);
        }
    }
}
