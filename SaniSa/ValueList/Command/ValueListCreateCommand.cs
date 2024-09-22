using MediatR;
using ValueList.DTO;
using ValueList.Interface;

namespace ValueList.Command
{
    public class ValueListCreateCommand : IRequest<ValueListDTO>
    {
        public ValueListCreateRequestDTO reqDTO { get; set; }
    }
    internal class ValueListCreateHandler : IRequestHandler<ValueListCreateCommand, ValueListDTO>
    {
        protected readonly IValueList _valueList;

        public ValueListCreateHandler(IValueList valueList)
        {
            _valueList = valueList;
        }
        public async Task<ValueListDTO> Handle(ValueListCreateCommand request, CancellationToken cancellationToken)
        {
            return await _valueList.Create(request.reqDTO);
        }
    }
}
