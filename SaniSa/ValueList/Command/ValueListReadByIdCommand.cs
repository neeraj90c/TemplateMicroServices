using MediatR;
using ValueList.DTO;
using ValueList.Interface;

namespace ValueList.Command
{
    public class ValueListReadByIdCommand : IRequest<ValueListDTO>
    {
        public ValueListReadByIdRequestDTO reqDTO { get; set; }
    }
    internal class ValueListReadByIdHandler : IRequestHandler<ValueListReadByIdCommand, ValueListDTO>
    {
        protected readonly IValueList _valueList;

        public ValueListReadByIdHandler(IValueList valueList)
        {
            _valueList = valueList;
        }
        public async Task<ValueListDTO> Handle(ValueListReadByIdCommand request, CancellationToken cancellationToken)
        {
            return await _valueList.ReadById(request.reqDTO);
        }
    }
}
