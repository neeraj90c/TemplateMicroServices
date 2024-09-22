using MediatR;
using CategoryDetail.DTO;
using CategoryDetail.Interface;

namespace CategoryDetail.Command
{
    public class CategoryDetailReadAllCommand : IRequest<CategoryDetailList>
    {
    }
    internal class CategoryDetailReadAllHandler : IRequestHandler<CategoryDetailReadAllCommand, CategoryDetailList>
    {
        protected readonly ICategoryDetail _CategoryDetail;

        public CategoryDetailReadAllHandler(ICategoryDetail CategoryDetail)
        {
            _CategoryDetail = CategoryDetail;
        }
        public async Task<CategoryDetailList> Handle(CategoryDetailReadAllCommand request, CancellationToken cancellationToken)
        {
            return await _CategoryDetail.ReadAll();
        }
    }
}
