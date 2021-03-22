using ContactInterview.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace ContactInterview.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<TodoList> TodoLists { get; set; }

        DbSet<TodoItem> TodoItems { get; set; }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Address> addresses { get; set; }
        public DbSet<ContactType> ContactTypes { get; set; }

        public DbSet<ContactInformation> ContactInformations { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
