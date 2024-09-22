using EventDetail.DTO;
using EventDetail.Interface;
using MediatR;

namespace EventDetail.Command
{
    public class EventDetailReadByEventIdCommand : IRequest<EventDetailList>
    {
        public EventdetailReadByEventIdRequestDTO reqDTO { get; set; }
    }
    internal class EventDetailReadByEventIdHandler : IRequestHandler<EventDetailReadByEventIdCommand, EventDetailList>
    {
        protected readonly IEventDetail _eventDetail;
        public EventDetailReadByEventIdHandler(IEventDetail eventDetail)
        {
            _eventDetail = eventDetail;
        }
        public async Task<EventDetailList> Handle(EventDetailReadByEventIdCommand request, CancellationToken cancellationToken)
        {
            return await _eventDetail.ReadByEventId(request.reqDTO);
        }
    }
}
