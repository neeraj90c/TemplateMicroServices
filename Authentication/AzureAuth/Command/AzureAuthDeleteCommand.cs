using AzureAuth.DTO;
using AzureAuth.Interface;
using MediatR;

namespace AzureAuth.Command
{
    public class AzureAuthDeleteCommand : IRequest
    {
        public AzureAuthDeleteRequestDTO reqDTO { get; set; }
    }
    internal class AzureAuthDeleteHandler : IRequestHandler<AzureAuthDeleteCommand>
    {
        protected readonly IAzureAuth _azureAuth;

        public AzureAuthDeleteHandler(IAzureAuth azureAuth)
        {
            _azureAuth = azureAuth;
        }
        public async Task Handle(AzureAuthDeleteCommand request, CancellationToken cancellationToken)
        {
            await _azureAuth.Delete(request.reqDTO);
        }
    }
}
