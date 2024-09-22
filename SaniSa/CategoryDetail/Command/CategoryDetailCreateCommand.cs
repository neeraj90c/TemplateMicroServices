using MediatR;
using CategoryDetail.DTO;
using CategoryDetail.Interface;

namespace CategoryDetail.Command
{
    public class CategoryDetailCreateCommand : IRequest<CategoryDetailDTO>
    {
        public CategoryDetailCreateRequestDTO reqDTO { get; set; }
    }
    internal class CategoryMasterCreateHandler : IRequestHandler<CategoryDetailCreateCommand, CategoryDetailDTO>
    {
        protected readonly ICategoryDetail _CategoryDetail;
        public CategoryMasterCreateHandler(ICategoryDetail CategoryDetail)
        {
            _CategoryDetail = CategoryDetail;
        }
        public async Task<CategoryDetailDTO> Handle(CategoryDetailCreateCommand request, CancellationToken cancellationToken)
        {
            return await _CategoryDetail.Create(request.reqDTO);
        }
    }
}
