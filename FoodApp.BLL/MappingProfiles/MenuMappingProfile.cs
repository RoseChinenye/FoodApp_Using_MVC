using AutoMapper;
using FoodApp.BLL.Models;
using FoodApp.DAL.Entities;

namespace FoodApp.BLL.MappingProfiles
{
    public class MenuMappingProfile : Profile
    {
        public MenuMappingProfile()
        {
            CreateMap<AddOrUpdateFoodItemVM, Menu>();                                                                                                                                               
        }
    }
}
