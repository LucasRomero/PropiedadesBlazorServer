using AutoMapper;
using PropiedadesBlazor.Model;
using PropiedadesBlazor.Model.DTO;

namespace PropiedadesBlazor.Mapper;

public class PerfilMapa : Profile
{
    public PerfilMapa()
    {
        CreateMap<CategoriaDTO, Categoria>().ReverseMap();
        CreateMap<PropiedadDTO, Propiedad>().ReverseMap();
    }
}
