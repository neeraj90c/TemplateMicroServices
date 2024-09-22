using MediatR;
using CategoryDetail.DTO;
using CategoryDetail.Interface;

namespace CategoryDetail.Command
{
    public class CategoryDetailReadByIdCommand : IRequest<CategoryDetailDTO>
    {
        public CategoryDetailReadByIdRequestDTO reqDTO { get; set; }
    }
    internal class CategoryDetailReadByIdHandler : IRequestHandler<CategoryDetailReadByIdCommand, CategoryDetailDTO>
    {
        protected readonly ICategoryDetail _CategoryDetail;

        public CategoryDetailReadByIdHandler(ICategoryDetail CategoryDetail)
        {
            _CategoryDetail = CategoryDetail;
        }
        public async Task<CategoryDetailDTO> Handle(CategoryDetailReadByIdCommand request, CancellationToken cancellationToken)
        {
            return await _CategoryDetail.ReadById(request.reqDTO);
        }
    }
}
