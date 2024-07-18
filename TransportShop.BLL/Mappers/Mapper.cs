using AutoMapper;
using TransportShop.BLL.DTO.Request;
using TransportShop.DAL.Entities;

namespace TransportShop.BLL.Mappers
{
    public class Mapper: Profile
    {
        public Mapper()
        {
            CreateMap<SignUpRequest, User>();
            CreateMap<SignUpRequest, Account>();
        }
    }
}
