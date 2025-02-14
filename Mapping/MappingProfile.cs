using AutoMapper;
using blogfolio.Dto;
using blogfolio.Entities;

namespace blogfolio.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Blog, BlogResponseDto>()
                // Map the tags from the BlogTags collection to just a list of tag names.
                .ForMember(dest => dest.Tags,
                           opt => opt.MapFrom(src => src.BlogTags.Select(bt => bt.Tag.Name)));
        }
    }
}
