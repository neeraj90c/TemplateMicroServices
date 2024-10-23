using CategoryDetail.DTO;
using CategoryDetail.Interface;
using MediatR;

namespace CategoryDetail.Command
{
    public class CategoryDetailReadByItemIdCommand : IRequest<CategoryDetailList>
    {
        public CategoryDetailReadByItemIdRequestDTO reqDTO { get; set; }
    }
    internal class CategoryDetailReadByItemIdCommandHandler : IRequestHandler<CategoryDetailReadByItemIdCommand, CategoryDetailList>
    {
        protected readonly ICategoryDetail _CategoryDetail;
        public CategoryDetailReadByItemIdCommandHandler(ICategoryDetail CategoryDetail)
        {
            _CategoryDetail = CategoryDetail;
        }

        public async Task<CategoryDetailList> Handle(CategoryDetailReadByItemIdCommand request, CancellationToken cancellationToken)
        {
            return await _CategoryDetail.ReadByItemId(request.reqDTO);
        }
    }
}
