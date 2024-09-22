using MediatR;
using ValueListItem.DTO;
using ValueListItem.Interface;

namespace ValueListItem.Command
{
    public class ValueListItemReadByVlNameCommand : IRequest<ValueListItemList>
    {
        public ValueListItemReadByVlNameRequestDTO reqDTO { get; set; }
    }
    internal class ValueListItemReadByVlNameHandler : IRequestHandler<ValueListItemReadByVlNameCommand, ValueListItemList>
    {
        protected readonly IValueListItem _valueListItem;

        public ValueListItemReadByVlNameHandler(IValueListItem valueListItem)
        {
            _valueListItem = valueListItem;
        }
        public async Task<ValueListItemList> Handle(ValueListItemReadByVlNameCommand request, CancellationToken cancellationToken)
        {
            return await _valueListItem.ReadByVlName(request.reqDTO);
        }
    }
}
