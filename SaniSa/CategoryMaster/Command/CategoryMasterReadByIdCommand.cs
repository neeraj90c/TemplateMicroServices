using MediatR;
using CategoryMaster.DTO;
using CategoryMaster.Interface;

namespace CategoryMaster.Command
{
    public class CategoryMasterReadByIdCommand : IRequest<CategoryMasterDTO>
    {
        public CategoryMasterReadByIdRequestDTO reqDTO { get; set; }
    }
    internal class CategoryMasterReadByIdHandler : IRequestHandler<CategoryMasterReadByIdCommand, CategoryMasterDTO>
    {
        protected readonly ICategoryMaster _CategoryMaster;

        public CategoryMasterReadByIdHandler(ICategoryMaster CategoryMaster)
        {
            _CategoryMaster = CategoryMaster;
        }
        public async Task<CategoryMasterDTO> Handle(CategoryMasterReadByIdCommand request, CancellationToken cancellationToken)
        {
            return await _CategoryMaster.ReadById(request.reqDTO);
        }
    }
}
