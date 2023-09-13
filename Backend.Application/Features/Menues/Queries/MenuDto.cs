using AutoMapper;
using Backend.Domain.Entity.Delivery;

namespace Backend.Application.Features.Menues.Queries;

public class MenuDto
{
    public Guid Id { get; }
    public Guid RestaurantId { get; }
    public string Name { get; } = string.Empty;
    public string ImageUrl { get; private set; } = string.Empty;

    private class MenuDtoProfile : Profile
    {
        public MenuDtoProfile()
        {
            CreateMap<Menu, MenuDto>();
        }
    }
}