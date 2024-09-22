using BankMaster.DTO;
using BankMaster.Interface;
using MediatR;

namespace BankMaster.Command
{
    public class BankMasterReadAllCommand : IRequest<BankMasterList>
    {
    }
    internal class BankMasterReadAllHandler : IRequestHandler<BankMasterReadAllCommand, BankMasterList>
    {
        protected readonly IBankMaster _bankMaster;

        public BankMasterReadAllHandler(IBankMaster bankMaster)
        {
            _bankMaster = bankMaster;
        }
        public async Task<BankMasterList> Handle(BankMasterReadAllCommand request, CancellationToken cancellationToken)
        {
            return await _bankMaster.ReadAll();
        }
    }
}
