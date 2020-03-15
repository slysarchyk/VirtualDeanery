using AutoMapper;
using VirtualDeanary.Data.Models;
using VirtualDeanary.Models;

namespace VirtualDeanary.Infrastructure.MapperProfiles
{
    public class CourseProfiles : Profile
    {
        public CourseProfiles()
        {
            CreateMap<AddCourseViewModel, Course>()
                .ForMember(x => x.Id, otp => otp.Ignore());
        }
    }
}
