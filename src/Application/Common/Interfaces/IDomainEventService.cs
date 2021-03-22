using ContactInterview.Domain.Common;
using System.Threading.Tasks;

namespace ContactInterview.Application.Common.Interfaces
{
    public interface IDomainEventService
    {
        Task Publish(DomainEvent domainEvent);
    }
}
