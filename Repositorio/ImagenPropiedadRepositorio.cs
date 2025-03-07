using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PropiedadesBlazor.Data;
using PropiedadesBlazor.Model;
using PropiedadesBlazor.Model.DTO;
using PropiedadesBlazor.Repositorio.IRepositorio;

namespace PropiedadesBlazor.Repositorio;

public class ImagenPropiedadRepositorio : IImagenPropiedadRepositorio
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IMapper _mapper;

    public ImagenPropiedadRepositorio(ApplicationDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<int> BorrarPropiedadByIdImagen(int imagenId)
    {
        var imagen = await _dbContext.ImagenesPropiedad.FindAsync(imagenId);
        _dbContext.ImagenesPropiedad.Remove(imagen);
        return await _dbContext.SaveChangesAsync();
    }

    public async Task<int> BorrarPropiedadByIdPropiedad(int propieadadId)
    {
        var ListaImagenes = await _dbContext
            .ImagenesPropiedad.Where(x => x.PropiedadId == propieadadId)
            .ToListAsync();
        _dbContext.ImagenesPropiedad.RemoveRange(ListaImagenes);
        return await _dbContext.SaveChangesAsync();
    }

    public async Task<int> BorrarPropiedadByUrlImagen(string ImagenUrl)
    {
        var imagen = await _dbContext.ImagenesPropiedad.FirstOrDefaultAsync(x =>
            x.UrlImagenPropiedad.ToLower() == ImagenUrl.ToLower().Trim()
        );

        if (imagen == null)
        {
            return 0;
        }

        _dbContext.ImagenesPropiedad.Remove(imagen);
        return await _dbContext.SaveChangesAsync();
    }

    public async Task<int> CrearPropiedadImagen(ImagenPropiedadDTO imagenDto)
    {
        var imagen = _mapper.Map<ImagenPropiedadDTO, ImagenPropiedad>(imagenDto);
        await _dbContext.AddAsync(imagen);
        return await _dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<ImagenPropiedadDTO>> GetImagenesPropiedad(int propieadadId)
    {
        return _mapper.Map<IEnumerable<ImagenPropiedad>, IEnumerable<ImagenPropiedadDTO>>(
            await _dbContext.ImagenesPropiedad.Where(x => x.Id == propieadadId).ToListAsync()
        );
    }
}
