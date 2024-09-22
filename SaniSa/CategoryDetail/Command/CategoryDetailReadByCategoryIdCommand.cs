using CategoryDetail.DTO;
using CategoryDetail.Interface;
using MediatR;

namespace CategoryDetail.Command
{
    public class CategoryDetailReadByCategoryIdCommand : IRequest<CategoryDetailDTO>
    {
        public CategoryDetailReadByCategoryIdRequestDTO reqDTO { get; set; }
    }
    internal class CategoryDetailReadByCategoryIdCommandHandler : IRequestHandler<CategoryDetailReadByCategoryIdCommand, CategoryDetailDTO> 
    {
        protected readonly ICategoryDetail _CategoryDetail;
        public CategoryDetailReadByCategoryIdCommandHandler(ICategoryDetail CategoryDetail)
        {
            _CategoryDetail = CategoryDetail;
        }

        public async Task<CategoryDetailDTO> Handle(CategoryDetailReadByCategoryIdCommand request, CancellationToken cancellationToken)
        {
            return await _CategoryDetail.ReadByCategoryId(request.reqDTO);
        }
    }
}
