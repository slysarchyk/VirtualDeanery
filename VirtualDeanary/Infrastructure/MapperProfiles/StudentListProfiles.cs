using AutoMapper;
using VirtualDeanary.Data.Models;
using VirtualDeanary.Models;

namespace VirtualDeanary.Infrastructure.MapperProfiles
{
    public class StudentListProfiles : Profile
    {
        public StudentListProfiles()
        {
            CreateMap<CreateStudentListViewModel, StudentList>().
                ForMember(x => x.Id, otp => otp.Ignore());
        }
    }
}
