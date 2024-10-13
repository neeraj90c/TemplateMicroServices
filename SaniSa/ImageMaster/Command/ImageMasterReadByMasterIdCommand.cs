using ImageMaster.DTO;
using ImageMaster.Interface;
using MediatR;

namespace ImageMaster.Command
{
    public class ImageMasterReadByMasterIdCommand : IRequest<ImageMasterList>
    {
        public ImageMasterReadByMasterIdRequestDTO reqDTO { get; set; }
    }

    internal class ImageMasterReadByItemIdCommandHandler : IRequestHandler<ImageMasterReadByMasterIdCommand, ImageMasterList>
    {
        protected readonly IImageMaster _imageMaster;
        public ImageMasterReadByItemIdCommandHandler(IImageMaster itemImages)
        {
            _imageMaster = itemImages;
        }

        public async Task<ImageMasterList> Handle(ImageMasterReadByMasterIdCommand request, CancellationToken cancellationToken)
        {
            return await _imageMaster.ReadByMasterId(request.reqDTO);
        }
    }
}
