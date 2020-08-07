using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TodoConsole
{
    public class TodoController : ITodo
    {
        TodoValidation tv = new TodoValidation();
        public void CreateTodo()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Console.WriteLine("Что планируете делать?");
                string title = Console.ReadLine();
                Console.WriteLine("Дату дедлайна");
                string date = Console.ReadLine();

                if (tv.IsDate(date))
                {
                    Todo newTodo = new Todo { Title = title, Date = Convert.ToDateTime(date) };

                    db.TodoList.Add(newTodo);
                    db.SaveChanges();

                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("Объекты успешно сохранены");
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine("Введите корректную дату");
                }
            }
        }

        public void DeleteTodo()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                if (!tv.DbFilled())
                {
                    Console.WriteLine("Ваш спиок дел пуст, вам нечего удалять \n");
                }
                else
                {
                    var todos = db.TodoList.ToList();
                    Console.WriteLine("Список всех запланированных дел.");
                    foreach (Todo t in todos)
                    {
                        Console.WriteLine($"{t.Id}.\t {t.Title} - {t.Date:d}");
                    }

                    Console.WriteLine("Введите ID который хотите удалить");
                    int id = Convert.ToInt32(Console.ReadLine());

                    Todo todo = db.TodoList.Find(id);
                    db.TodoList.Remove(todo);
                    db.SaveChanges();
                }

            }
        }

        public void ShowTodo()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var todos = db.TodoList.ToList();

                if (!tv.DbFilled())
                {
                    Console.WriteLine("Ваш список дел пуст \n");
                }
                else
                {
                    Console.WriteLine("Список дел:");
                    foreach (Todo t in todos)
                    {
                        Console.WriteLine($"{t.Title} - {t.Date:d}");
                    }
                }
            }
        }

        public void CheckDate()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var overdueTodo = (from todos in db.TodoList
                                   where todos.Date < DateTime.Now
                                   select todos).ToList();

                Console.WriteLine("У вас есть просроченные дела:");

                foreach (var t in overdueTodo)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{t.Title}. Надо было сделать до: {t.Date:d}");
                    Console.ResetColor();
                }
            }
        }
    }
}
