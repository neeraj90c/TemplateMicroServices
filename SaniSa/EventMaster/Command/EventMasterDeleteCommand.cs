using EventMaster.DTO;
using EventMaster.Interface;
using MediatR;

namespace EventMaster.Command
{
    public class EventMasterDeleteCommand : IRequest<EventMasterResponseDTO>
    {
        public EventMasterDeleteRequestDTO reqDTO { get; set; }
    }
    internal class EventMasterDeleteHandler : IRequestHandler<EventMasterDeleteCommand, EventMasterResponseDTO>
    {
        protected readonly IEventMaster _eventMaster;

        public EventMasterDeleteHandler(IEventMaster eventMaster)
        {
            _eventMaster = eventMaster;
        }
        public async Task<EventMasterResponseDTO> Handle(EventMasterDeleteCommand request, CancellationToken cancellationToken)
        {
            return await _eventMaster.Delete(request.reqDTO);
        }
    }
}
