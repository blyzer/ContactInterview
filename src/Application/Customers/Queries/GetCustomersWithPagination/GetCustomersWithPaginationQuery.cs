using AutoMapper;
using AutoMapper.QueryableExtensions;
using ContactInterview.Application.Common.Interfaces;
using ContactInterview.Application.Common.Mappings;
using ContactInterview.Application.Common.Models;
using ContactInterview.Application.Customers.Queries;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ContactInterview.Application.Customers.Queries.GetCustomersWithPagination
{
    public class GetCustomersWithPaginationQuery : IRequest<PaginatedList<CustomerDto>>
    {
        public string FullName { get; set;}
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }

    public class GetCustomersWithPaginationQueryHandler : IRequestHandler<GetCustomersWithPaginationQuery, PaginatedList<CustomerDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetCustomersWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PaginatedList<CustomerDto>> Handle(GetCustomersWithPaginationQuery request, CancellationToken cancellationToken) => await _context.Customers
            .Where(x => x.FullName == request.FullName)
            .OrderBy(x => x.Id)
            .ProjectTo<CustomerDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize)
            .ConfigureAwait(false);
    }
}
