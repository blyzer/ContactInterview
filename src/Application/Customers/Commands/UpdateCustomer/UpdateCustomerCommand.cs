using System.Threading;
using System.Threading.Tasks;
using ContactInterview.Application.Common.Exceptions;
using ContactInterview.Application.Common.Interfaces;
using ContactInterview.Domain.Entities;
using MediatR;

namespace ContactInterview.Application.Customers.Commands.UpdateCustomer {
    public class UpdateCustomerCommand : IRequest {
        public int Id { get; set; }
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

    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand> {
        private readonly IApplicationDbContext _context;

        public UpdateCustomerCommandHandler(IApplicationDbContext context) => _context = context;

        public async Task<Unit> Handle (UpdateCustomerCommand request, CancellationToken cancellationToken) {
            var entity = await _context.Customers.FindAsync (request.Id);

            if (entity == null) {
                throw new NotFoundException (nameof (Customer), request.Id);
            }

            entity.Prefix = request.Prefix;
            entity.FirstName = request.FirstName;
            entity.SecondName = request.SecondName;
            entity.LastName = request.LastName;
            entity.SecondLastName = request.SecondLastName;
            entity.Gender = (Domain.Enums.Gender)request.GenderId;
            entity.IdentificationType = (Domain.Enums.IdentificationType)request.IdentificationTypeId;
            entity.IdNumber = request.IdNumber;
            entity.MaritalStatus = (Domain.Enums.MaritalStatus)request.MaritalStatusId;
            entity.Suffix = request.Suffix;

            await _context.SaveChangesAsync (cancellationToken);

            return Unit.Value;
        }
    }
}