using ComboDetail.DTO;
using ComboDetail.Interface;
using MediatR;

namespace ComboDetail.Command
{
    public class ComboDetailReadByDetailIdCommand : IRequest<ComboDetailDTO>
    {
        public ComboDetailReadByDetailIdRequestDTO reqDTO { get; set; }
    }
    internal class ComboDetailReadByDetailIdCommandHandlet : IRequestHandler<ComboDetailReadByDetailIdCommand, ComboDetailDTO>
    {
        protected readonly IComboDetail _comboDetail;
        public ComboDetailReadByDetailIdCommandHandlet(IComboDetail comboDetail)
        {
            _comboDetail = comboDetail;
        }

        public async Task<ComboDetailDTO> Handle(ComboDetailReadByDetailIdCommand request, CancellationToken cancellationToken)
        {
            return await _comboDetail.ReadById(request.reqDTO);
        }
    }
}
