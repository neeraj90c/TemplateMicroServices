using AzureAuth.DTO;
using AzureAuth.Interface;
using MediatR;

namespace AzureAuth.Command
{
    public class AzureAuthReadAllCommand : IRequest<AzureAuthList>
    {
    }
    internal class AzureAuthReadAllHandler : IRequestHandler<AzureAuthReadAllCommand, AzureAuthList>
    {
        protected readonly IAzureAuth _azureAuth;

        public AzureAuthReadAllHandler(IAzureAuth azureAuth)
        {
            _azureAuth = azureAuth;
        }
        public async Task<AzureAuthList> Handle(AzureAuthReadAllCommand request, CancellationToken cancellationToken)
        {
            return await _azureAuth.ReadAll();
        }
    }
}
