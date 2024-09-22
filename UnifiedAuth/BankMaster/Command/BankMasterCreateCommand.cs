using BankMaster.DTO;
using BankMaster.Interface;
using MediatR;

namespace BankMaster.Command
{
    public class BankMasterCreateCommand : IRequest<BankMasterDTO>
    {
        public BankMasterCreateRequestDTO reqDTO { get; set; }
    }
    internal class BankMasterCreateHandler : IRequestHandler<BankMasterCreateCommand, BankMasterDTO>
    {
        protected readonly IBankMaster _bankMaster;

        public BankMasterCreateHandler(IBankMaster bankMaster)
        {
            _bankMaster = bankMaster;
        }
        public async Task<BankMasterDTO> Handle(BankMasterCreateCommand request, CancellationToken cancellationToken)
        {
            return await _bankMaster.Create(request.reqDTO);
        }
    }
}
