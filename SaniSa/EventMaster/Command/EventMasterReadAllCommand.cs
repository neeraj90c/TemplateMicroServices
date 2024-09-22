using EventMaster.DTO;
using EventMaster.Interface;
using MediatR;

namespace EventMaster.Command
{  
    public class EventMasterReadAllCommand : IRequest<EventList>
    {
    }
    internal class EventMasterReadAllHandler : IRequestHandler<EventMasterReadAllCommand, EventList>
    {
        protected readonly IEventMaster _eventMaster;

        public EventMasterReadAllHandler(IEventMaster eventMaster)
        {
            _eventMaster = eventMaster;
        }
        public async Task<EventList> Handle(EventMasterReadAllCommand request, CancellationToken cancellationToken)
        {
            return await _eventMaster.ReadAll();
        }
    }
}
