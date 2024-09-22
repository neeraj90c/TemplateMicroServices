using AzureAuth.DTO;
using AzureAuth.Interface;
using MediatR;

namespace AzureAuth.Command
{
    public class AzureAuthCreateCommand : IRequest<AzureAuthDTO>
    {
        public AzureAuthCreateRequestDTO reqDTO { get; set; }
    }
    internal class AzureAuthCreateHandler : IRequestHandler<AzureAuthCreateCommand, AzureAuthDTO>
    {
        protected readonly IAzureAuth _azureAuth;

        public AzureAuthCreateHandler(IAzureAuth azureAuth)
        {
            _azureAuth = azureAuth;
        }
        public async Task<AzureAuthDTO> Handle(AzureAuthCreateCommand request, CancellationToken cancellationToken)
        {
            return await _azureAuth.Create(request.reqDTO);
        }
    }
}
