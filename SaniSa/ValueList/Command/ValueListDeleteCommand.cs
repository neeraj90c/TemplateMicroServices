using MediatR;
using ValueList.DTO;
using ValueList.Interface;

namespace ValueList.Command
{
    public class ValueListDeleteCommand : IRequest
    {
        public ValueListDeleteRequestDTO reqDTO { get; set; }
    }
    internal class ValueListDeleteHandler : IRequestHandler<ValueListDeleteCommand>
    {
        protected readonly IValueList _valueList;

        public ValueListDeleteHandler(IValueList valueList)
        {
            _valueList = valueList;
        }
        public async Task Handle(ValueListDeleteCommand request, CancellationToken cancellationToken)
        {
            await _valueList.Delete(request.reqDTO);
        }
    }
}
