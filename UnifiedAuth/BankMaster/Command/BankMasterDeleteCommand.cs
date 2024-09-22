using BankMaster.DTO;
using BankMaster.Interface;
using MediatR;

namespace BankMaster.Command
{
    public class BankMasterDeleteCommand : IRequest
    {
        public BankMasterDeleteRequestDTO reqDTO { get; set; }
    }
    internal class BankMasterDeleteHandler : IRequestHandler<BankMasterDeleteCommand>
    {
        protected readonly IBankMaster _bankMaster;

        public BankMasterDeleteHandler(IBankMaster bankMaster)
        {
            _bankMaster = bankMaster;
        }
        public async Task Handle(BankMasterDeleteCommand request, CancellationToken cancellationToken)
        {
            await _bankMaster.Delete(request.reqDTO);
        }
    }
}
