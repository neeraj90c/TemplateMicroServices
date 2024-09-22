using BankMaster.DTO;
using BankMaster.Interface;
using MediatR;

namespace BankMaster.Command
{
    public class BankMasterUpdateCommand : IRequest<BankMasterDTO>
    {
        public BankMasterUpdateRequestDTO reqDTO { get; set; }
    }
    internal class BankMasterUpdateHandler : IRequestHandler<BankMasterUpdateCommand, BankMasterDTO>
    {
        protected readonly IBankMaster _bankMaster;

        public BankMasterUpdateHandler(IBankMaster bankMaster)
        {
            _bankMaster = bankMaster;
        }
        public async Task<BankMasterDTO> Handle(BankMasterUpdateCommand request, CancellationToken cancellationToken)
        {
            return await _bankMaster.Update(request.reqDTO);
        }
    }
}
