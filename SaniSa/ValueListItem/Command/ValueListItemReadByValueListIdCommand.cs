using MediatR;
using ValueListItem.DTO;
using ValueListItem.Interface;

namespace ValueListItem.Command
{
    public class ValueListItemReadByValueListIdCommand : IRequest<ValueListItemList>
    {
        public ValueListItemReadByValueListIdRequestDTO reqDTO { get; set; }
    }
    internal class ValueListItemReadByValueListIdHandler : IRequestHandler<ValueListItemReadByValueListIdCommand, ValueListItemList>
    {
        protected readonly IValueListItem _valueListItem;

        public ValueListItemReadByValueListIdHandler(IValueListItem valueListItem)
        {
            _valueListItem = valueListItem;
        }
        public async Task<ValueListItemList> Handle(ValueListItemReadByValueListIdCommand request, CancellationToken cancellationToken)
        {
            return await _valueListItem.ReadByValueListId(request.reqDTO);
        }
    }
}
