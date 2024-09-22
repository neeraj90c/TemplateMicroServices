using MediatR;
using ValueListItem.DTO;
using ValueListItem.Interface;

namespace ValueListItem.Command
{
    public class ValueListItemUpdateCommand : IRequest<ValueListItemDTO>
    {
        public ValueListItemUpdateRequestDTO reqDTO { get; set; }
    }
    internal class ValueListItemUpdateHandler : IRequestHandler<ValueListItemUpdateCommand, ValueListItemDTO>
    {
        protected readonly IValueListItem _valueListItem;

        public ValueListItemUpdateHandler(IValueListItem valueListItem)
        {
            _valueListItem = valueListItem;
        }
        public async Task<ValueListItemDTO> Handle(ValueListItemUpdateCommand request, CancellationToken cancellationToken)
        {
            return await _valueListItem.Update(request.reqDTO);
        }
    }
}
