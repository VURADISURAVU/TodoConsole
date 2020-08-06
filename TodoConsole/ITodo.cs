using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TodoConsole
{
    interface ITodo
    {
        void CreateTodo();
        void DeleteTodo();
        void ShowTodo();
        void CheckDate();
    }
}
