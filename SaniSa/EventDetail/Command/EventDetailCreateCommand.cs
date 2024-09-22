using EventDetail.DTO;
using EventDetail.Interface;
using MediatR;

namespace EventDetail.Command
{
    public class EventDetailCreateCommand : IRequest<EventDetailResponseDTO>
    {
        public EventDetailCreateRequestDTO reqDTO { get; set; }
    }
    internal class EventDetailCreateHandler : IRequestHandler<EventDetailCreateCommand, EventDetailResponseDTO>
    {
        protected readonly IEventDetail _eventDetail;
        public EventDetailCreateHandler(IEventDetail eventDetail)
        {
            _eventDetail = eventDetail;
        }
        public async Task<EventDetailResponseDTO> Handle(EventDetailCreateCommand request, CancellationToken cancellationToken)
        {
            return await _eventDetail.Create(request.reqDTO);
        }
    }
}
