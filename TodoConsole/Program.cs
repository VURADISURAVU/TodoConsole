using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TodoConsole
{
    class Program
    {
        public static void Main()
        {
            TodoController todo = new TodoController();
            todo.CheckDate();
            bool alive = true;
            while(alive)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Добро пожаловать в список дел. Выберите что будете делать \n");
                Console.WriteLine("1. Создать \t 2. Посмотреть  \t 3. Удалить \t 4. Закрыть");
                Console.ResetColor();

                int selection = Convert.ToInt32(Console.ReadLine());

                switch (selection)
                {
                    case 1:
                        todo.CreateTodo();
                        break;
                    case 2:
                        todo.ShowTodo();
                        break;
                    case 3:
                        todo.DeleteTodo();
                        break;
                    case 4:
                        alive = false;
                        continue;
                }
            }
        }
    }
}
