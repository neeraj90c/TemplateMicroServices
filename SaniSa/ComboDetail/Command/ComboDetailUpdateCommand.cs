using ComboDetail.DTO;
using ComboDetail.Interface;
using MediatR;

namespace ComboDetail.Command
{
    public class ComboDetailUpdateCommand : IRequest<ComboDetailDTO>
    {
        public ComboDetailUpdateRequestDTO reqDTO { get; set; }
    }
    internal class ComboDetailUpdateCommandHandler : IRequestHandler<ComboDetailUpdateCommand, ComboDetailDTO>
    {
        protected readonly IComboDetail _comboDetail;
        public ComboDetailUpdateCommandHandler(IComboDetail comboDetail)
        {
            _comboDetail = comboDetail;
        }


        public async Task<ComboDetailDTO> Handle(ComboDetailUpdateCommand request, CancellationToken cancellationToken)
        {
            return await _comboDetail.Update(request.reqDTO);
        }
    }
}
