using BankMaster.DTO;
using BankMaster.Interface;
using MediatR;

namespace BankMaster.Command
{
    public class BankMasterReadByIdCommand : IRequest<BankMasterDTO>
    {
        public BankMasterReadByIdRequestDTO reqDTO { get; set; }
    }
    internal class BankMasterReadByIdHandler : IRequestHandler<BankMasterReadByIdCommand, BankMasterDTO>
    {
        protected readonly IBankMaster _bankMaster;

        public BankMasterReadByIdHandler(IBankMaster bankMaster)
        {
            _bankMaster = bankMaster;
        }
        public async Task<BankMasterDTO> Handle(BankMasterReadByIdCommand request, CancellationToken cancellationToken)
        {
            return await _bankMaster.ReadById(request.reqDTO);
        }
    }
}
