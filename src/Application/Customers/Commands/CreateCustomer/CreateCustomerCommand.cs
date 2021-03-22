using ContactInterview.Application.Common.Interfaces;
using ContactInterview.Domain.Entities;
using ContactInterview.Domain.Events;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ContactInterview.Application.Customers.Commands.CreateCustomer
{
    public class CreateCustomerCommand : IRequest<int>
    {
        public string Prefix { get; set; }

        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public string LastName { get; set; }

        public string SecondLastName { get; set; }

        public string Suffix { get; set; }

        public int GenderId { get; set; }

        public int MaritalStatusId { get; set; }

        public int IdentificationTypeId { get; set; }

        public string IdNumber { get; set; }
    }

    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateCustomerCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var entity = new Customer
            {
                Prefix = request.Prefix,
                FirstName = request.FirstName,
                SecondName = request.SecondName,
                LastName = request.LastName,
                SecondLastName = request.SecondLastName,
                Gender = (Domain.Enums.Gender)request.GenderId,
                IdentificationType = (Domain.Enums.IdentificationType)request.IdentificationTypeId,
                IdNumber = request.IdNumber,
                MaritalStatus = (Domain.Enums.MaritalStatus)request.MaritalStatusId,
                Suffix = request.Suffix
            };

            _context.Customers.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
