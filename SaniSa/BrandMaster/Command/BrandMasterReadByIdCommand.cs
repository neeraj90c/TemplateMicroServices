using MediatR;
using BrandMaster.DTO;
using BrandMaster.Interface;

namespace BrandMaster.Command
{
    public class BrandMasterReadByIdCommand : IRequest<BrandMasterDTO>
    {
        public BrandMasterReadByIdRequestDTO reqDTO { get; set; }
    }
    internal class BrandMasterReadByIdHandler : IRequestHandler<BrandMasterReadByIdCommand, BrandMasterDTO>
    {
        protected readonly IBrandMaster _projectMaster;

        public BrandMasterReadByIdHandler(IBrandMaster projectMaster)
        {
            _projectMaster = projectMaster;
        }
        public async Task<BrandMasterDTO> Handle(BrandMasterReadByIdCommand request, CancellationToken cancellationToken)
        {
            return await _projectMaster.ReadById(request.reqDTO);
        }
    }
}
