using AutoMapper;
using blogfolio.Dto.Blog;
using blogfolio.Dto.Comment;
using blogfolio.Dto.User;
using blogfolio.Entities;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;

namespace blogfolio.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Blog, BlogResponseDto>()
                // Map the tags from the BlogTags collection to just a list of tag names.
                .ForMember(dest => dest.Tags,
                           opt => opt.MapFrom(src => src.BlogTags.Select(bt => bt.Tag.Name)));

            CreateMap<Comment, ReadCommentDto>();
            CreateMap<User, UserDto>();
            CreateMap<UpdateUserDto, User>().ForMember(dest => dest.HashedPassword, opt => opt.MapFrom(src => HashPassword(src.Password)));
            CreateMap<CreateUserDto, User>().ForMember(dest => dest.HashedPassword, opt => opt.MapFrom(src => HashPassword(src.Password)));

        }
        /*
         Password from CreateUserDto is mapped to HashedPassword in User.
           The HashPassword function hashes the password before saving it to the database
         
         */
        private static string HashPassword(string password)
        {
            if (string.IsNullOrEmpty(password)) return null;

            byte[] salt = new byte[16];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 10000,
                numBytesRequested: 32
            ));

            return hashed;
        }
    }
}
