using CategoryDetail.DTO;
using CategoryDetail.Interface;
using MediatR;

namespace CategoryDetail.Command
{
    public class CategoryDetailReadByCategoryIdCommand : IRequest<CategoryDetailList>
    {
        public CategoryDetailReadByCategoryIdRequestDTO reqDTO { get; set; }
    }
    internal class CategoryDetailReadByCategoryIdCommandHandler : IRequestHandler<CategoryDetailReadByCategoryIdCommand, CategoryDetailList> 
    {
        protected readonly ICategoryDetail _CategoryDetail;
        public CategoryDetailReadByCategoryIdCommandHandler(ICategoryDetail CategoryDetail)
        {
            _CategoryDetail = CategoryDetail;
        }

        public async Task<CategoryDetailList> Handle(CategoryDetailReadByCategoryIdCommand request, CancellationToken cancellationToken)
        {
            return await _CategoryDetail.ReadByCategoryId(request.reqDTO);
        }
    }
}
