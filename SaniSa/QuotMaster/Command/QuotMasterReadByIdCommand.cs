using MediatR;
using QuotMaster.DTO;
using QuotMaster.Interface;

namespace QuotMaster.Command
{
    public class QuotMasterReadByIdCommand : IRequest<QuotMasterDTO>
    {
        public QuotMasterReadByIdRequestDTO reqDTO { get; set; }
    }
    internal class QuotMasterReadByIdHandler : IRequestHandler<QuotMasterReadByIdCommand, QuotMasterDTO>
    {
        protected readonly IQuotMaster _quotMaster;

        public QuotMasterReadByIdHandler(IQuotMaster quotMaster)
        {
            _quotMaster = quotMaster;
        }
        public async Task<QuotMasterDTO> Handle(QuotMasterReadByIdCommand request, CancellationToken cancellationToken)
        {
            return await _quotMaster.ReadById(request.reqDTO);
        }
    }
}
