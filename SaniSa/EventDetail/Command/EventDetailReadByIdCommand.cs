using EventDetail.DTO;
using EventDetail.Interface;
using MediatR;

namespace EventDetail.Command
{
    public class EventDetailReadByIdCommand : IRequest<EventDetailResponseDTO>
    {
        public EventDetailReadByIdRequestDTO reqDTO { get; set; }
    }
    internal class EventDetailReadByIdHandler : IRequestHandler<EventDetailReadByIdCommand, EventDetailResponseDTO>
    {
        protected readonly IEventDetail _eventDetail;
        public EventDetailReadByIdHandler(IEventDetail eventDetail)
        {
            _eventDetail = eventDetail;
        }
        public async Task<EventDetailResponseDTO> Handle(EventDetailReadByIdCommand request, CancellationToken cancellationToken)
        {
            return await _eventDetail.ReadById(request.reqDTO);
        }
    }
}
