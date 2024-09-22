using AzureAuth.DTO;
using AzureAuth.Interface;
using MediatR;

namespace AzureAuth.Command
{
    public class AzureAuthReadByIdCommand : IRequest<AzureAuthDTO>
    {
        public AzureAuthReadByIdRequestDTO reqDTO { get; set; }
    }
    internal class AzureAuthReadByIdHandler : IRequestHandler<AzureAuthReadByIdCommand, AzureAuthDTO>
    {
        protected readonly IAzureAuth _azureAuth;

        public AzureAuthReadByIdHandler(IAzureAuth azureAuth)
        {
            _azureAuth = azureAuth;
        }
        public async Task<AzureAuthDTO> Handle(AzureAuthReadByIdCommand request, CancellationToken cancellationToken)
        {
            return await _azureAuth.ReadById(request.reqDTO);
        }
    }
}
