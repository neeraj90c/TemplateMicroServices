using MediatR;
using ImageMaster.DTO;
using ImageMaster.Interface;

namespace ImageMaster.Command
{
    public class ImageMasterCreateCommand : IRequest<ImageMasterDTO>
    {
        public ImageMasterCreateRequestDTO reqDTO { get; set; }
    }
    internal class ImageMasterCreateHandler : IRequestHandler<ImageMasterCreateCommand, ImageMasterDTO>
    {
        protected readonly IImageMaster _imageMaster;

        public ImageMasterCreateHandler(IImageMaster itemImages)
        {
            _imageMaster = itemImages;
        }
        public async Task<ImageMasterDTO> Handle(ImageMasterCreateCommand request, CancellationToken cancellationToken)
        {
            return await _imageMaster.Create(request.reqDTO);
        }
    }
}
