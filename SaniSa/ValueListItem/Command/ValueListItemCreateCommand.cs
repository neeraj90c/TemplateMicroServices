using MediatR;
using ValueListItem.DTO;
using ValueListItem.Interface;

namespace ValueListItem.Command
{
    public class ValueListItemCreateCommand : IRequest<ValueListItemDTO>
    {
        public ValueListItemCreateRequestDTO reqDTO { get; set; }
    }
    internal class ValueListItemCreateHandler : IRequestHandler<ValueListItemCreateCommand, ValueListItemDTO>
    {
        protected readonly IValueListItem _valueListItem;

        public ValueListItemCreateHandler(IValueListItem valueListItem)
        {
            _valueListItem = valueListItem;
        }
        public async Task<ValueListItemDTO> Handle(ValueListItemCreateCommand request, CancellationToken cancellationToken)
        {
            return await _valueListItem.Create(request.reqDTO);
        }
    }
}
