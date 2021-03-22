using ContactInterview.Application.Common.Models;
using ContactInterview.Application.Customers.Commands.CreateCustomer;
using ContactInterview.Application.Customers.Commands.DeleteCustomer;
using ContactInterview.Application.Customers.Commands.UpdateCustomer;
using ContactInterview.Application.Customers.Queries;
using ContactInterview.Application.Customers.Queries.GetCustomersWithPagination;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ContactInterview.WebUI.Controllers
{
    [Authorize]
    public class CustomersController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<PaginatedList<CustomerDto>>> GetCustomersWithPagination([FromQuery] GetCustomersWithPaginationQuery query)
        {
            return await Mediator.Send(query);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateCustomerCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateCustomerCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteCustomerCommand { Id = id });

            return NoContent();
        }
    }
}
