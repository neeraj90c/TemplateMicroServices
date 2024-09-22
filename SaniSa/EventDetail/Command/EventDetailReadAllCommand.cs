using EventDetail.DTO;
using EventDetail.Interface;
using MediatR;

namespace EventDetail.Command
{
    public class EventDetailReadAllCommand : IRequest<EventDetailList>
    {
    }
    internal class EventDetailReadAllHandler : IRequestHandler<EventDetailReadAllCommand, EventDetailList>
    {
        protected readonly IEventDetail _eventDetail;
        public EventDetailReadAllHandler(IEventDetail eventDetail)
        {
            _eventDetail = eventDetail;
        }
        public async Task<EventDetailList> Handle(EventDetailReadAllCommand request, CancellationToken cancellationToken)
        {
            return await _eventDetail.ReadAll();
        }
    }
}
