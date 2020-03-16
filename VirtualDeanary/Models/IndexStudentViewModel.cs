using System.Collections.Generic;
using VirtualDeanary.Data.Models;

namespace VirtualDeanary.Models
{
    public class IndexStudentViewModel
    {
        public IEnumerable<StudentList> StudentLists { get; set; }
        public int StudyYear { get; internal set; }
    }
}
