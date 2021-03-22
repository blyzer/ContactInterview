using ContactInterview.Application.Common.Mappings;
using ContactInterview.Domain.Entities;

namespace ContactInterview.Application.TodoLists.Queries.ExportTodos
{
    public class TodoItemRecord : IMapFrom<TodoItem>
    {
        public string Title { get; set; }

        public bool Done { get; set; }
    }
}
