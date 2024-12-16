using AutoMapper;
using MudBlazor;
using OlympRentalSystem.Shared.Models;
using OlympRentalSystem.UI.Models;

namespace OlympRentalSystem.UI.Profiles;

public class OlympRentalSystemProfile : Profile
{
    public OlympRentalSystemProfile()
    {
        CreateMap<Car, CarDto>()
            .ForMember(dest => dest.CarId, opt => opt.MapFrom(src => src.CarId))
            .ForMember(dest => dest.Brand, opt => opt.MapFrom(src => src.Brand))
            .ForMember(dest => dest.Model, opt => opt.MapFrom(src => src.Model))
            .ForMember(dest => dest.PricePerDay, opt => opt.MapFrom(src => src.PricePerDay))
            .ForMember(dest => dest.PricePerWeek, opt => opt.MapFrom(src => src.PricePerWeek))
            .ForMember(dest => dest.PricePerMonth, opt => opt.MapFrom(src => src.PricePerMonth))
            .ForMember(dest => dest.Availability, opt => opt.MapFrom(src => src.Availability))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.Images, opt => opt.MapFrom(src => src.Images))
            .ReverseMap();
        
        CreateMap<TableState, FilterModel>()
            .ForMember(dest => dest.OrderBy, opt => opt.MapFrom(src => src.SortLabel ?? string.Empty))
            .ForMember(dest => dest.IsDescending, opt => opt.MapFrom(src => src.SortDirection == SortDirection.Descending))
            .ForMember(dest => dest.Skip, opt => opt.MapFrom(src => src.Page * src.PageSize))
            .ForMember(dest => dest.Take, opt => opt.MapFrom(src => src.PageSize));
    }
}