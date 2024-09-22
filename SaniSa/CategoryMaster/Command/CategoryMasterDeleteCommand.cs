using MediatR;
using CategoryMaster.DTO;
using CategoryMaster.Interface;

namespace CategoryMaster.Command
{
    public class CategoryMasterDeleteCommand : IRequest
    {
        public CategoryMasterDeleteRequestDTO reqDTO { get; set; }
    }
    internal class CategoryMasterDeleteHandler : IRequestHandler<CategoryMasterDeleteCommand>
    {
        protected readonly ICategoryMaster _CategoryMaster;

        public CategoryMasterDeleteHandler(ICategoryMaster CategoryMaster)
        {
            _CategoryMaster = CategoryMaster;
        }
        public async Task Handle(CategoryMasterDeleteCommand request, CancellationToken cancellationToken)
        {
            await _CategoryMaster.Delete(request.reqDTO);
        }
    }
}
