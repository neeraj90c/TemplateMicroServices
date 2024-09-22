using MediatR;
using QuotMaster.DTO;
using QuotMaster.Interface;

namespace QuotMaster.Command
{
    public class QuotMasterCreateCommand : IRequest<QuotMasterDTO>
    {
        public QuotMasterCreateRequestDTO reqDTO { get; set; }
    }
    internal class QuotMasterCreateHandler : IRequestHandler<QuotMasterCreateCommand, QuotMasterDTO>
    {
        protected readonly IQuotMaster _quotMaster;
        public QuotMasterCreateHandler(IQuotMaster quotMaster)
        {
            _quotMaster = quotMaster;
        }
        public async Task<QuotMasterDTO> Handle(QuotMasterCreateCommand request, CancellationToken cancellationToken)
        {
            return await _quotMaster.Create(request.reqDTO);
        }
    }
}
