using EventMaster.DTO;
using EventMaster.Interface;
using MediatR;

namespace EventMaster.Command
{
    public class EventMasterReadByEventIdCommand : IRequest<EventMasterResponseDTO>
    {
        public EventMasterReadByEventIdRequestDTO reqDTO { get; set; }
    }
    internal class EventMasterReadByEventIdHandler : IRequestHandler<EventMasterReadByEventIdCommand, EventMasterResponseDTO>
    {
        protected readonly IEventMaster _eventMaster;

        public EventMasterReadByEventIdHandler(IEventMaster eventMaster)
        {
            _eventMaster = eventMaster;
        }
        public async Task<EventMasterResponseDTO> Handle(EventMasterReadByEventIdCommand request, CancellationToken cancellationToken)
        {
            return await _eventMaster.ReadByEventId(request.reqDTO);
        }
    }
}
