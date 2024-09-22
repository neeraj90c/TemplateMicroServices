using EventMaster.DTO;
using EventMaster.Interface;
using MediatR;

namespace EventMaster.Command
{
    public class EventMasterUpdateCommand : IRequest<EventMasterResponseDTO>
    {
        public EventMasterUpdateRequestDTO reqDTO { get; set; }
    }
    internal class EventMasterUpdateHandler : IRequestHandler<EventMasterUpdateCommand, EventMasterResponseDTO>
    {
        protected readonly IEventMaster _eventMaster;

        public EventMasterUpdateHandler(IEventMaster eventMaster)
        {
            _eventMaster = eventMaster;
        }
        public async Task<EventMasterResponseDTO> Handle(EventMasterUpdateCommand request, CancellationToken cancellationToken)
        {
            return await _eventMaster.Update(request.reqDTO);
        }
    }
}
