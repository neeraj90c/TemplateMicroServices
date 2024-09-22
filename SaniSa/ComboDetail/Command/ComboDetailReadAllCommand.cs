using MediatR;
using ComboDetail.DTO;
using ComboDetail.Interface;

namespace ComboDetail.Command
{
    public class ComboDetailReadAllCommand : IRequest<ComboDetailList>
    {
    }
    internal class ComboDetailReadAllHandler : IRequestHandler<ComboDetailReadAllCommand, ComboDetailList>
    {
        protected readonly IComboDetail _comboDetail;

        public ComboDetailReadAllHandler(IComboDetail comboDetail)
        {
            _comboDetail = comboDetail;
        }
        public async Task<ComboDetailList> Handle(ComboDetailReadAllCommand request, CancellationToken cancellationToken)
        {
            return await _comboDetail.ReadAll();
        }
    }
}
