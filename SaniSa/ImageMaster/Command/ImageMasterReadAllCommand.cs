using MediatR;
using ImageMaster.DTO;
using ImageMaster.Interface;

namespace ImageMaster.Command
{
    public class ImageMasterReadAllCommand : IRequest<ImageMasterList>
    {
    }
    internal class ImageMasterReadAllHandler : IRequestHandler<ImageMasterReadAllCommand, ImageMasterList>
    {
        protected readonly IImageMaster _imageMaster;

        public ImageMasterReadAllHandler(IImageMaster itemImages)
        {
            _imageMaster = itemImages;
        }
        public async Task<ImageMasterList> Handle(ImageMasterReadAllCommand request, CancellationToken cancellationToken)
        {
            return await _imageMaster.ReadAll();
        }
    }
}
