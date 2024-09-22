using AzureAuth.DTO;
using AzureAuth.Interface;
using MediatR;

namespace AzureAuth.Command
{
    public class AzureAuthReadByAzureUUIdCommand : IRequest<AzureAuthDTO>
    {
        public AzureAuthReadByAzureUUIdRequestDTO reqDTO { get; set; }
    }
    internal class AzureAuthReadByAzureUUIdHandler : IRequestHandler<AzureAuthReadByAzureUUIdCommand, AzureAuthDTO>
    {
        protected readonly IAzureAuth _azureAuth;

        public AzureAuthReadByAzureUUIdHandler(IAzureAuth azureAuth)
        {
            _azureAuth = azureAuth;
        }
        public async Task<AzureAuthDTO> Handle(AzureAuthReadByAzureUUIdCommand request, CancellationToken cancellationToken)
        {
            return await _azureAuth.ReadByAzureUUId(request.reqDTO);
        }
    }
}
