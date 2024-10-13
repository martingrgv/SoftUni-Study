using AutoMapper;
using GameZone.Data.Models;
using GameZone.Models;

namespace GameZone.Profiles
{
	public class GameProfile : Profile
	{
		public GameProfile()
		{
			CreateMap<GameCreateModel, Game>();
			CreateMap<Game, GameViewModel>()
				.ForMember(s => s.Publisher, opt =>
					opt.MapFrom(src => src.Publisher.UserName))
				.ForMember(s => s.Genre, opt => 
					opt.MapFrom(d => d.Genre.Name));
		}
	}
}
