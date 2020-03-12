using AutoMapper;
using VirtualDeanary.Data.Models;
using VirtualDeanary.Models;

namespace VirtualDeanary.Infrastructure.MapperProfiles
{
    public class MarkProfiles : Profile
    {
        public MarkProfiles()
        {
            CreateMap<CreateMarkViewModel, Mark>().
                ForMember(x => x.Id, otp => otp.Ignore()); ;
        }
    }
}
