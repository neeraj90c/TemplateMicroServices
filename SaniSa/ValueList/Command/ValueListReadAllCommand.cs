using MediatR;
using ValueList.DTO;
using ValueList.Interface;

namespace ValueList.Command
{
    public class ValueListReadAllCommand : IRequest<ValueListList>
    {
    }
    internal class ValueListReadAllHandler : IRequestHandler<ValueListReadAllCommand, ValueListList>
    {
        protected readonly IValueList _valueList;

        public ValueListReadAllHandler(IValueList valueList)
        {
            _valueList = valueList;
        }
        public async Task<ValueListList> Handle(ValueListReadAllCommand request, CancellationToken cancellationToken)
        {
            return await _valueList.ReadAll();
        }
    }
}
