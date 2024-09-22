using MediatR;
using QuotMaster.DTO;
using QuotMaster.Interface;

namespace QuotMaster.Command
{
    public class QuotMasterUpdateCommand : IRequest<QuotMasterDTO>
    {
        public QuotMasterUpdateRequestDTO reqDTO { get; set; }
    }
    internal class QuotMasterUpdateHandler : IRequestHandler<QuotMasterUpdateCommand, QuotMasterDTO>
    {
        protected readonly IQuotMaster _quotMaster;

        public QuotMasterUpdateHandler(IQuotMaster quotMaster)
        {
            _quotMaster = quotMaster;
        }
        public async Task<QuotMasterDTO> Handle(QuotMasterUpdateCommand request, CancellationToken cancellationToken)
        {
            return await _quotMaster.Update(request.reqDTO);
        }
    }
}
