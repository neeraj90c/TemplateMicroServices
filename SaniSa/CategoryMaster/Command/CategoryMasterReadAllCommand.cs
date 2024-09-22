using MediatR;
using CategoryMaster.DTO;
using CategoryMaster.Interface;

namespace CategoryMaster.Command
{
    public class CategoryMasterReadAllCommand : IRequest<CategoryMasterList>
    {
    }
    internal class CategoryMasterReadAllHandler : IRequestHandler<CategoryMasterReadAllCommand, CategoryMasterList>
    {
        protected readonly ICategoryMaster _CategoryMaster;

        public CategoryMasterReadAllHandler(ICategoryMaster CategoryMaster)
        {
            _CategoryMaster = CategoryMaster;
        }
        public async Task<CategoryMasterList> Handle(CategoryMasterReadAllCommand request, CancellationToken cancellationToken)
        {
            return await _CategoryMaster.ReadAll();
        }
    }
}
