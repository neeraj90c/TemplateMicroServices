using MediatR;
using ComboDetail.DTO;
using ComboDetail.Interface;

namespace ComboDetail.Command
{
    public class ComboDetailReadByItemIdCommand : IRequest<ComboDetailDTO>
    {
        public ComboDetailReadByItemIdRequestDTO reqDTO { get; set; }
    }
    internal class ComboDetailReadByItemIdHandler : IRequestHandler<ComboDetailReadByItemIdCommand, ComboDetailDTO>
    {
        protected readonly IComboDetail _comboDetail;

        public ComboDetailReadByItemIdHandler(IComboDetail comboDetail)
        {
            _comboDetail = comboDetail;
        }
        public async Task<ComboDetailDTO> Handle(ComboDetailReadByItemIdCommand request, CancellationToken cancellationToken)
        {
            return await _comboDetail.ReadByItemId(request.reqDTO);
        }
    }
}
