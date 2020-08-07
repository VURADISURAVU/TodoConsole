using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;

namespace TodoConsole
{
    public class Todo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime Date { get; set; }
    }
}
