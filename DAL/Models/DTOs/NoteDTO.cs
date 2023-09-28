using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.DAL.DTOs
{
    public class NoteDTO
    {
        public string EmployeeEmail { get; set; }
        public string Text { get; set; }
        public IList<string>? Images { get; set; }
    }
}
