using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TodoConsole
{
    public class TodoValidation
    {
        public bool IsDate(string tempDate)
        {
            DateTime fromDateValue;
            var formats = new[] { "dd/MM/yyyy", "yyyy-MM-dd", "dd.MM.yyyy" };
            if (DateTime.TryParseExact(tempDate,
                formats,
                System.Globalization.CultureInfo.InvariantCulture,
                System.Globalization.DateTimeStyles.None,
                out fromDateValue))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DbFilled()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                if (db.TodoList.Count() == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
    }
}
