using AutoMapper;
using VirtualDeanary.Data.Models;
using VirtualDeanary.Models;

namespace VirtualDeanary.Infrastructure.MapperProfiles
{
    public class SemesterProfile : Profile
    {
        public SemesterProfile()
        {
            CreateMap<AddSemesterViewModel, Semester>().
                ForMember(x => x.Id, otp => otp.Ignore());
        }
    }
}
