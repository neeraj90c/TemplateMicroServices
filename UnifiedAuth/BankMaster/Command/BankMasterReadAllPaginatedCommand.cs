using BankMaster.DTO;
using BankMaster.Interface;
using Common.DTO;
using MediatR;

namespace BankMaster.Command
{
    public class BankMasterReadAllPaginatedCommand : IRequest<BankMasterList>
    {
        public PaginationDTO reqDTO { get; set; }
    }
    internal class BankMasterReadAllPaginatedHandler : IRequestHandler<BankMasterReadAllPaginatedCommand, BankMasterList>
    {
        protected readonly IBankMaster _bankMaster;

        public BankMasterReadAllPaginatedHandler(IBankMaster bankMaster)
        {
            _bankMaster = bankMaster;
        }
        public async Task<BankMasterList> Handle(BankMasterReadAllPaginatedCommand request, CancellationToken cancellationToken)
        {
            return await _bankMaster.ReadAllPaginated(request.reqDTO);
        }
    }
}
