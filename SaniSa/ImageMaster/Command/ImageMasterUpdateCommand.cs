using MediatR;
using ImageMaster.DTO;
using ImageMaster.Interface;

namespace ImageMaster.Command
{
    public class ImageMasterUpdateCommand : IRequest<ImageMasterDTO>
    {
        public ImageMasterUpdateRequestDTO reqDTO { get; set; }
    }
    internal class ItemMasterUpdateHandler : IRequestHandler<ImageMasterUpdateCommand, ImageMasterDTO>
    {
        protected readonly IImageMaster _imageMaster;

        public ItemMasterUpdateHandler(IImageMaster itemImages)
        {
            _imageMaster = itemImages;
        }
        public async Task<ImageMasterDTO> Handle(ImageMasterUpdateCommand request, CancellationToken cancellationToken)
        {
            return await _imageMaster.Update(request.reqDTO);
        }
    }
}
