using MediatR;
using ValueList.DTO;
using ValueList.Interface;

namespace ValueList.Command
{
    public class ValueListUpdateCommand : IRequest<ValueListDTO>
    {
        public ValueListUpdateRequestDTO reqDTO { get; set; }
    }
    internal class ValueListUpdateHandler : IRequestHandler<ValueListUpdateCommand, ValueListDTO>
    {
        protected readonly IValueList _valueList;

        public ValueListUpdateHandler(IValueList valueList)
        {
            _valueList = valueList;
        }
        public async Task<ValueListDTO> Handle(ValueListUpdateCommand request, CancellationToken cancellationToken)
        {
            return await _valueList.Update(request.reqDTO);
        }
    }
}
