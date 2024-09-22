using MediatR;
using ImageMaster.DTO;
using ImageMaster.Interface;

namespace ImageMaster.Command
{
    public class ImageMasterReadByIdCommand : IRequest<ImageMasterDTO>
    {
        public ImageMasterReadByIdRequestDTO reqDTO { get; set; }
    }
    internal class ItemMasterReadByIdHandler : IRequestHandler<ImageMasterReadByIdCommand, ImageMasterDTO>
    {
        protected readonly IImageMaster _imageMaster;

        public ItemMasterReadByIdHandler(IImageMaster itemImages)
        {
            _imageMaster = itemImages;
        }
        public async Task<ImageMasterDTO> Handle(ImageMasterReadByIdCommand request, CancellationToken cancellationToken)
        {
            return await _imageMaster.ReadById(request.reqDTO);
        }
    }
}
