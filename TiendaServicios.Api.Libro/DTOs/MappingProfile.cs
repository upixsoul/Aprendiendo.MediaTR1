using AutoMapper;
using TiendaServicios.Api.Libro.Modelo;

namespace TiendaServicios.Api.Libro.DTOs
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<LibreriaMaterial, LibroMaterialDTO>().ReverseMap();
        }
    }
}
