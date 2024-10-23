﻿using CategoryDetail.DTO;

namespace CategoryDetail.Interface
{
    public interface ICategoryDetail
    {
        Task<CategoryDetailDTO> Create(CategoryDetailCreateRequestDTO reqDTO);
        Task<CategoryDetailDTO> Update(CategoryDetailUpdateRequestDTO reqDTO);
        Task Delete(CategoryDetailDeleteRequestDTO reqDTO);
        Task<CategoryDetailDTO> ReadById(CategoryDetailReadByIdRequestDTO reqDTO);
        Task<CategoryDetailList> ReadByCategoryId(CategoryDetailReadByCategoryIdRequestDTO reqDTO);
        Task<CategoryDetailList> ReadAll();
        Task<CategoryDetailList> ReadByItemId(CategoryDetailReadByItemIdRequestDTO reqDTO);
    }
}
