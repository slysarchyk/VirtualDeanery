using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using VirtualDeanary.Data.Models;

namespace VirtualDeanary.Models
{
    public class InfoStudentListViewModel
    {
        public IEnumerable<StudentList> StudentLists { get; set; }
        public int StudyYear { get; set; }
    }
}
