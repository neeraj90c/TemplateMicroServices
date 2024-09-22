using MediatR;
using CategoryMaster.DTO;
using CategoryMaster.Interface;

namespace CategoryMaster.Command
{
    public class CategoryMasterCreateCommand : IRequest<CategoryMasterDTO>
    {
        public CategoryMasterCreateRequestDTO reqDTO { get; set; }
    }
    internal class CategoryMasterCreateHandler : IRequestHandler<CategoryMasterCreateCommand, CategoryMasterDTO>
    {
        protected readonly ICategoryMaster _CategoryMaster;

        public CategoryMasterCreateHandler(ICategoryMaster CategoryMaster)
        {
            _CategoryMaster = CategoryMaster;
        }
        public async Task<CategoryMasterDTO> Handle(CategoryMasterCreateCommand request, CancellationToken cancellationToken)
        {
            return await _CategoryMaster.Create(request.reqDTO);
        }
    }
}
