using ComboDetail.DTO;
using ComboDetail.Interface;
using MediatR;

namespace ComboDetail.Command
{
    public class ComboDetailReadByComboIdCommand : IRequest<ComboDetailDTO>
    {
        public ComboDetailReadByComboIdRequestDTO reqDTO { get; set; }
    }
    internal class ComboDetailReadByComboIdCommandHandler : IRequestHandler<ComboDetailReadByComboIdCommand, ComboDetailDTO> 
    {
        protected readonly IComboDetail _comboDetail;
        public ComboDetailReadByComboIdCommandHandler(IComboDetail comboDetail)
        {
            _comboDetail = comboDetail;
        }

        public async Task<ComboDetailDTO> Handle(ComboDetailReadByComboIdCommand request, CancellationToken cancellationToken)
        {
            return await _comboDetail.ReadByComboId(request.reqDTO);
        }
    }
}
