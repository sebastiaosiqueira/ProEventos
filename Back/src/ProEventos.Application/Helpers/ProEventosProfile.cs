
using AutoMapper;
using ProEventos.Application.Dtos;
using ProEventos.Domain;

namespace ProEventos.Application.Helpers
{
    public class ProEventosProfile: Profile
    {
        public ProEventosProfile(){
            CreateMap<Evento, EventoDto>().ReverseMap();
            CreateMap<Lote, LoteDto>().ReverseMap();
            CreateMap<RedeSocial, RedeSocialDto>().ReverveMap();
            CreateMap<Palestrante, PalestranteDto>().ReverseMap();
        
            

        }
        
    }
}