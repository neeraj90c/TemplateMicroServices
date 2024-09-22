using MediatR;
using CategoryDetail.DTO;
using CategoryDetail.Interface;

namespace CategoryDetail.Command
{
    public class CategoryDetailUpdateCommand : IRequest<CategoryDetailDTO>
    {
        public CategoryDetailUpdateRequestDTO reqDTO { get; set; }
    }
    internal class CategoryDetailUpdateHandler : IRequestHandler<CategoryDetailUpdateCommand, CategoryDetailDTO>
    {
        protected readonly ICategoryDetail _CategoryDetail;

        public CategoryDetailUpdateHandler(ICategoryDetail CategoryDetail)
        {
            _CategoryDetail = CategoryDetail;
        }
        public async Task<CategoryDetailDTO> Handle(CategoryDetailUpdateCommand request, CancellationToken cancellationToken)
        {
            return await _CategoryDetail.Update(request.reqDTO);
        }
    }
}
