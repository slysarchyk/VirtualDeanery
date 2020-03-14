using AutoMapper;
using VirtualDeanary.Data.Models;
using VirtualDeanary.Models;

namespace VirtualDeanary.Infrastructure.MapperProfiles
{
    public class FacultyProfile : Profile
    {
        public FacultyProfile()
        {
            CreateMap<AddFacultyViewModel, Faculty>().
                ForMember(x => x.Id, otp => otp.Ignore());
        }
    }
}
