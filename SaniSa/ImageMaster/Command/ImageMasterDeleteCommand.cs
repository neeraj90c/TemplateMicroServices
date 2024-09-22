using MediatR;
using ImageMaster.DTO;
using ImageMaster.Interface;

namespace ImageMaster.Command
{
    public class ImageMasterDeleteCommand : IRequest
    {
        public ImageMasterDeleteRequestDTO reqDTO { get; set; }
    }
    internal class ImageMasterDeleteHandler : IRequestHandler<ImageMasterDeleteCommand>
    {
        protected readonly IImageMaster _imageMaster;

        public ImageMasterDeleteHandler(IImageMaster itemImages)
        {
            _imageMaster = itemImages;
        }
        public async Task Handle(ImageMasterDeleteCommand request, CancellationToken cancellationToken)
        {
            await _imageMaster.Delete(request.reqDTO);
        }
    }
}
