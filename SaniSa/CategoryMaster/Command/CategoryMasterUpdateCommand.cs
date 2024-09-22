using MediatR;
using CategoryMaster.DTO;
using CategoryMaster.Interface;

namespace CategoryMaster.Command
{
    public class CategoryMasterUpdateCommand : IRequest<CategoryMasterDTO>
    {
        public CategoryMasterUpdateRequestDTO reqDTO { get; set; }
    }
    internal class CategoryMasterUpdateHandler : IRequestHandler<CategoryMasterUpdateCommand, CategoryMasterDTO>
    {
        protected readonly ICategoryMaster _CategoryMaster;

        public CategoryMasterUpdateHandler(ICategoryMaster CategoryMaster)
        {
            _CategoryMaster = CategoryMaster;
        }
        public async Task<CategoryMasterDTO> Handle(CategoryMasterUpdateCommand request, CancellationToken cancellationToken)
        {
            return await _CategoryMaster.Update(request.reqDTO);
        }
    }
}
