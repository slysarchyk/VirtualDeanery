using System.Collections.Generic;
using VirtualDeanary.Data.Models;
using System.Linq;

namespace VirtualDeanary.Models
{
    public class IndexStudentViewModel
    {
        public IEnumerable<StudentList> StudentLists { get; set; }
    }
}
