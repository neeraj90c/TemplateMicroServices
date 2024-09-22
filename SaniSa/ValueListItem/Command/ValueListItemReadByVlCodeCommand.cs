using MediatR;
using ValueListItem.DTO;
using ValueListItem.Interface;

namespace ValueListItem.Command
{
    public class ValueListItemReadByVlCodeCommand : IRequest<ValueListItemList>
    {
        public ValueListItemReadByVlCodeRequestDTO reqDTO { get; set; }
    }
    internal class ValueListItemReadByVlCodeHandler : IRequestHandler<ValueListItemReadByVlCodeCommand, ValueListItemList>
    {
        protected readonly IValueListItem _valueListItem;

        public ValueListItemReadByVlCodeHandler(IValueListItem valueListItem)
        {
            _valueListItem = valueListItem;
        }
        public async Task<ValueListItemList> Handle(ValueListItemReadByVlCodeCommand request, CancellationToken cancellationToken)
        {
            return await _valueListItem.ReadByVlCode(request.reqDTO);
        }
    }
}
