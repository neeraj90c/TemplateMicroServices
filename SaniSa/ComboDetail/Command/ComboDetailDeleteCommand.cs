using MediatR;
using ComboDetail.DTO;
using ComboDetail.Interface;

namespace ComboDetail.Command
{
    public class ComboDetailDeleteCommand : IRequest
    {
        public ComboDetailDeleteRequestDTO reqDTO { get; set; }
    }
    internal class ComboDetailDeleteHandler : IRequestHandler<ComboDetailDeleteCommand>
    {
        protected readonly IComboDetail _comboDetail;

        public ComboDetailDeleteHandler(IComboDetail comboDetail)
        {
            _comboDetail = comboDetail;
        }
        public async Task Handle(ComboDetailDeleteCommand request, CancellationToken cancellationToken)
        {
            await _comboDetail.Delete(request.reqDTO);
        }
    }
}
