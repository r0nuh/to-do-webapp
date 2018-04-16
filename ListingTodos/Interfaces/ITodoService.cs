using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ListingTodos.ViewModels;

namespace ListingTodos.Interfaces
{
    public interface ITodoService
    {
        TodoViewModel ListActive();
        TodoViewModel ListByUser();

    }
}
