using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualDeanary.Data.Models;

namespace VirtualDeanary.Models
{
    public class IndexTeacherViewModel
    {
        public IEnumerable<Subject> Courses { get; set; }
    }
}
