using AzureAuth.DTO;
using AzureAuth.Interface;
using MediatR;

namespace AzureAuth.Command
{
    public class AzureAuthUpdateCommand : IRequest<AzureAuthDTO>
    {
        public AzureAuthUpdateRequestDTO reqDTO { get; set; }
    }
    internal class AzureAuthUpdateHandler : IRequestHandler<AzureAuthUpdateCommand, AzureAuthDTO>
    {
        protected readonly IAzureAuth _azureAuth;

        public AzureAuthUpdateHandler(IAzureAuth azureAuth)
        {
            _azureAuth = azureAuth;
        }
        public async Task<AzureAuthDTO> Handle(AzureAuthUpdateCommand request, CancellationToken cancellationToken)
        {
            return await _azureAuth.Update(request.reqDTO);
        }
    }
}
