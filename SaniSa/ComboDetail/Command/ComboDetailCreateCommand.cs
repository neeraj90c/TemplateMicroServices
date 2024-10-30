using MediatR;
using ComboDetail.DTO;
using ComboDetail.Interface;

namespace ComboDetail.Command
{
    public class ComboDetailCreateCommand : IRequest<ComboDetailDTO>
    {
        public ComboDetailCreateRequestDTO reqDTO { get; set; }
    }
    internal class ComboDetailCreateCommandHandler : IRequestHandler<ComboDetailCreateCommand, ComboDetailDTO>
    {
        protected readonly IComboDetail _comboDetail;
        public ComboDetailCreateCommandHandler(IComboDetail comboDetail)
        {
            _comboDetail = comboDetail;
        }
        public async Task<ComboDetailDTO> Handle(ComboDetailCreateCommand request, CancellationToken cancellationToken)
        {
            return await _comboDetail.Create(request.reqDTO);
        }
    }
}
