using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace foca_project.Models
{
    public class ActivityModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date_init { get; set; }
        public DateTime Date_end { get; set; }
        public int Id_user { get; set; }
        public bool isConcluded { get; set; }
        public int Directory { get; set; }
        public bool IsReadOnly { get; set; }
    }
}
