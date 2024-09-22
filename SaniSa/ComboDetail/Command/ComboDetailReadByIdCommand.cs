using MediatR;
using ComboDetail.DTO;
using ComboDetail.Interface;

namespace ComboDetail.Command
{
    public class ComboDetailReadByIdCommand : IRequest<ComboDetailDTO>
    {
        public ComboDetailReadByIdRequestDTO reqDTO { get; set; }
    }
    internal class ComboDetailReadByIdHandler : IRequestHandler<ComboDetailReadByIdCommand, ComboDetailDTO>
    {
        protected readonly IComboDetail _comboDetail;

        public ComboDetailReadByIdHandler(IComboDetail comboDetail)
        {
            _comboDetail = comboDetail;
        }
        public async Task<ComboDetailDTO> Handle(ComboDetailReadByIdCommand request, CancellationToken cancellationToken)
        {
            return await _comboDetail.ReadById(request.reqDTO);
        }
    }
}
