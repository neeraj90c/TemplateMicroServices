using MediatR;
using ValueListItem.DTO;
using ValueListItem.Interface;

namespace ValueListItem.Command
{
    public class ValueListItemReadByIdCommand : IRequest<ValueListItemDTO>
    {
        public ValueListItemReadByIdRequestDTO reqDTO { get; set; }
    }
    internal class ValueListItemReadByIdHandler : IRequestHandler<ValueListItemReadByIdCommand, ValueListItemDTO>
    {
        protected readonly IValueListItem _valueListItem;

        public ValueListItemReadByIdHandler(IValueListItem valueListItem)
        {
            _valueListItem = valueListItem;
        }
        public async Task<ValueListItemDTO> Handle(ValueListItemReadByIdCommand request, CancellationToken cancellationToken)
        {
            return await _valueListItem.ReadById(request.reqDTO);
        }
    }
}
