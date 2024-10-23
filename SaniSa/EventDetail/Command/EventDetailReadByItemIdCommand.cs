using EventDetail.DTO;
using EventDetail.Interface;
using MediatR;

namespace EventDetail.Command
{
    public class EventDetailReadByItemIdCommand : IRequest<EventDetailList>
    {
        public EventdetailReadByItemIdRequestDTO reqDTO { get; set; }
    }
    internal class EventDetailReadByItemIdHandler : IRequestHandler<EventDetailReadByItemIdCommand, EventDetailList>
    {
        protected readonly IEventDetail _eventDetail;
        public EventDetailReadByItemIdHandler(IEventDetail eventDetail)
        {
            _eventDetail = eventDetail;
        }
        public async Task<EventDetailList> Handle(EventDetailReadByItemIdCommand request, CancellationToken cancellationToken)
        {
            return await _eventDetail.ReadByItemId(request.reqDTO);
        }
    }
}
