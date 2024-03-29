﻿using ContactInterview.Application.TodoLists.Queries.ExportTodos;
using System.Collections.Generic;

namespace ContactInterview.Application.Common.Interfaces
{
    public interface ICsvFileBuilder
    {
        byte[] BuildTodoItemsFile(IEnumerable<TodoItemRecord> records);
    }
}
