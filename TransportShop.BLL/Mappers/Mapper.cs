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
            CreateMap<User, UserResponse>();
            CreateMap<IEnumerable<User>, IEnumerable<UserResponse>>()
                .ConvertUsing(users => users.Select(u => new UserResponse
                {
                    Id = u.Id,
                    Name = u.Name,
                    Phone = u.Phone,
                    Address = u.Address
                }));
        }
    }
}
