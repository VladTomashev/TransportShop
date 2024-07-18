using AutoMapper;
using TransportShop.BLL.DTO.Request;
using TransportShop.BLL.DTO.Response;
using TransportShop.DAL.Entities;

namespace TransportShop.BLL.Mappers
{
    public class Mapper: Profile
    {
        public Mapper()
        {
            CreateMap<SignUpRequest, User>();
            CreateMap<SignUpRequest, Account>();
            CreateMap<User, UserProfileResponse>();
        }
    }
}
