using DapperNorthwind.Dtos.CategoryDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperNorthwind.Repositories.CategoryRepositories
{
    public  interface ICategoryRepository
    {
        Task<List<ResultCategoryDtos>> GetAllCategoryAsync();

        Task<GetByIdCategoryDto> GetByIdCategoryAsync(int id);  
        Task CreateCategoryAsync(CreateCategoryDto createCategoryDto);
        Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto);
        Task DeleteCategoryAsync(int id);

    }
}
