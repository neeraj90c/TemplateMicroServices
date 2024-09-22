using EventMaster.DTO;
using EventMaster.Interface;
using MediatR;

namespace EventMaster.Command
{
    public class EventMasterCreateCommand :IRequest<EventMasterResponseDTO>
    {
        public EventMasterCreateRequestDTO reqDTO { get; set; }
    }
    internal class EventMasterCreateHandler : IRequestHandler<EventMasterCreateCommand, EventMasterResponseDTO>
    {
        protected readonly IEventMaster _eventMaster;

        public EventMasterCreateHandler(IEventMaster eventMaster)
        {
            _eventMaster = eventMaster;
        }
        public async Task<EventMasterResponseDTO> Handle(EventMasterCreateCommand request, CancellationToken cancellationToken)
        {
            return await _eventMaster.Create(request.reqDTO);
        }
    }
}
