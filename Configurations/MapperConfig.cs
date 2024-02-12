using AutoMapper;
using Final_Project.Models;

namespace Final_Project.Configurations
{
	public class MapperConfig : Profile
	{
		public MapperConfig() 
		{
			CreateMap<UserDto, User>().ReverseMap();
		}
	}
}
