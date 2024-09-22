using MediatR;
using ValueListItem.DTO;
using ValueListItem.Interface;

namespace ValueListItem.Command
{
    public class ValueListItemDeleteCommand : IRequest
    {
        public ValueListItemDeleteRequestDTO reqDTO { get; set; }
    }
    internal class ValueListItemDeleteHandler : IRequestHandler<ValueListItemDeleteCommand>
    {
        protected readonly IValueListItem _valueListItem;

        public ValueListItemDeleteHandler(IValueListItem valueListItem)
        {
            _valueListItem = valueListItem;
        }
        public async Task Handle(ValueListItemDeleteCommand request, CancellationToken cancellationToken)
        {
            await _valueListItem.Delete(request.reqDTO);
        }
    }
}
