using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using QDryClean.Application.Absreactions;
using QDryClean.Application.Common.Interfaces.Services;
using QDryClean.Application.Dtos;
using QDryClean.Application.Common.Exceptions;
using QDryClean.Application.UseCases.Customers.Querries.GetAll;

namespace QDryClean.Application.UseCases.Customers.Handlers
{
    public class GetAllCustomersQuerryHandler : CommandHandlerBase, IRequestHandler<GetAllCustomersQuery, List<CustomerDto>>
    {
        public GetAllCustomersQuerryHandler(
            IApplicationDbContext applicationDbContext,
            ICurrentUserService currentUserService,
            IMapper mapper) : base(applicationDbContext, currentUserService, mapper) { }

        public async Task<List<CustomerDto>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var customers = await _applicationDbContext.Customers.Where(x => x.DeletedAt == null && x.DeletedBy == null).ToListAsync();

                var list_of_customerDtos = new List<CustomerDto>();
                foreach (var customer in customers)
                {
                    list_of_customerDtos.Add(_mapper.Map<CustomerDto>(customer));
                }

                return list_of_customerDtos;

            }
            catch (Exception ex)
            {
                throw new InternalServerExeption(ex.Message);
            }
        }
    }
}
