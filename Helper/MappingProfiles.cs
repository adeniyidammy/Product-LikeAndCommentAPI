using AutoMapper;
using PostAndCommentAPI.Dto;
using PostAndCommentAPI.Models;

namespace PostAndCommentAPI.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Product, CreateGetProductDto>().ReverseMap();

            CreateMap<Comment, CommentDto>().ReverseMap();
            CreateMap<Comment, CreateGetCommentDto>().ReverseMap();

            CreateMap<Commenter, CommentersDto>().ReverseMap();

        }
    }
}
