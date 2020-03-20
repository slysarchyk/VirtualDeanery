using AutoMapper;
using VirtualDeanary.Data.Models;
using VirtualDeanary.Models;

namespace VirtualDeanary.Infrastructure.MapperProfiles
{
    public class SubjectProfiles : Profile
    {
        public SubjectProfiles()
        {
            CreateMap<AddSubjectViewModel, Subject>()
                .ForMember(x => x.Id, otp => otp.Ignore());
        }
    }
}
