using MediatR;
using CategoryDetail.DTO;
using CategoryDetail.Interface;

namespace CategoryDetail.Command
{
    public class CategoryDetailDeleteCommand : IRequest
    {
        public CategoryDetailDeleteRequestDTO reqDTO { get; set; }
    }
    internal class CategoryDetailDeleteHandler : IRequestHandler<CategoryDetailDeleteCommand>
    {
        protected readonly ICategoryDetail _CategoryDetail;

        public CategoryDetailDeleteHandler(ICategoryDetail CategoryDetail)
        {
            _CategoryDetail = CategoryDetail;
        }
        public async Task Handle(CategoryDetailDeleteCommand request, CancellationToken cancellationToken)
        {
            await _CategoryDetail.Delete(request.reqDTO);
        }
    }
}
