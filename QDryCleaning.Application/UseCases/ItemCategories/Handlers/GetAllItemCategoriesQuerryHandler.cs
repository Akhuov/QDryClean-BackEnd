using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using QDryClean.Application.Absreactions;
using QDryClean.Application.Common.Interfaces.Services;
using QDryClean.Application.Common.Responses;
using QDryClean.Application.Dtos;
using QDryClean.Application.UseCases.ItemCategories.Querries;

namespace QDryClean.Application.UseCases.ItemCategories.Handlers
{
    public class GetAllItemCategoriesQuerryHandler : CommandHandlerBase, IRequestHandler<GetAllItemCategoriesQuerry, ApiResponse<List<ItemCategoryDto>>>
    {
        public GetAllItemCategoriesQuerryHandler(
            IApplicationDbContext applicationDbContext,
            ICurrentUserService currentUserService,
            IMapper mapper) : base(applicationDbContext, currentUserService, mapper) { }

        public async Task<ApiResponse<List<ItemCategoryDto>>> Handle(GetAllItemCategoriesQuerry request, CancellationToken cancellationToken)
        {

            var itemCategories = await _applicationDbContext.ItemCategories.ToListAsync();

            var listOfItemCategoryDtos = new List<ItemCategoryDto>();
            foreach (var itemCategory in itemCategories)
            {
                listOfItemCategoryDtos.Add(new ItemCategoryDto()
                {
                    Id = itemCategory.Id,
                    Name = itemCategory.Name
                });
            }

            return ApiResponseFactory.Ok(listOfItemCategoryDtos);
        }
    }
}
