using AutoMapper;
using ItemDataApi.Data.Dtos;
using ItemDataApi.Models;

namespace ItemDataApi.Profiles;

public class ItemProfile : Profile
{
    public ItemProfile()
    {
        CreateMap<CreateItemDto, Item>();
        CreateMap<UpdateItemDto, Item>().ReverseMap();
        CreateMap<Item, ReadItemDto>();
    }
}