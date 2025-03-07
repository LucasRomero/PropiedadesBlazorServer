using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PropiedadesBlazor.Data;
using PropiedadesBlazor.Model;
using PropiedadesBlazor.Model.DTO;
using PropiedadesBlazor.Repositorio.IRepositorio;

namespace PropiedadesBlazor.Repositorio;

public class PropiedadRepositorio : IPropiedadRepositorio
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IMapper _mapper;

    public PropiedadRepositorio(ApplicationDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<PropiedadDTO> ActualizarPropiedad(PropiedadDTO PropiedadDTO)
    {
        try
        {
            var cat = await _dbContext.Propiedades.FirstOrDefaultAsync(c =>
                c.Id == PropiedadDTO.Id
            );

            if (cat == null)
            {
                return new PropiedadDTO();
            }

            var Propiedad = _mapper.Map(PropiedadDTO, cat);
            Propiedad.FechaActualizacion = DateTime.Now;
            var PropiedadActualizada = _dbContext.Propiedades.Update(Propiedad);

            await _dbContext.SaveChangesAsync();

            return _mapper.Map<Propiedad, PropiedadDTO>(PropiedadActualizada.Entity);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<int> BorrarPropiedad(int PropiedadId)
    {
        try
        {
            var Propiedad = await _dbContext.Propiedades.FindAsync(PropiedadId);
            if (Propiedad is null)
            {
                return 0;
            }

            _dbContext.Propiedades.Remove(Propiedad);
            return await _dbContext.SaveChangesAsync();
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<PropiedadDTO> CrearPropiedad(PropiedadDTO PropiedadDTO)
    {
        var Propiedad = _mapper.Map<PropiedadDTO, Propiedad>(PropiedadDTO);
        Propiedad.FechaCreacion = DateTime.Now;
        var PropiedadCreada = await _dbContext.Propiedades.AddAsync(Propiedad);
        await _dbContext.SaveChangesAsync();
        return _mapper.Map<Propiedad, PropiedadDTO>(PropiedadCreada.Entity);
    }

    public async Task<PropiedadDTO> GetPropiedadById(int PropiedadId)
    {
        PropiedadDTO PropiedadDTO = _mapper.Map<Propiedad, PropiedadDTO>(
            await _dbContext.Propiedades.FirstOrDefaultAsync(c => c.Id == PropiedadId)
        );

        return PropiedadDTO;
    }

    public async Task<IEnumerable<PropiedadDTO>> GettAllPropiedades()
    {
        try
        {
            IEnumerable<PropiedadDTO> PropiedadDTO = _mapper.Map<
                IEnumerable<Propiedad>,
                IEnumerable<PropiedadDTO>
            >(_dbContext.Propiedades.ToList());
            return PropiedadDTO;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<PropiedadDTO> NombrePropiedadExiste(string Nombre)
    {
        try
        {
            PropiedadDTO PropiedadDTO = _mapper.Map<Propiedad, PropiedadDTO>(
                await _dbContext.Propiedades.FirstOrDefaultAsync(c =>
                    c.Nombre.ToLower().Trim() == Nombre.ToLower().Trim()
                )
            );

            return PropiedadDTO;
        }
        catch (Exception)
        {
            throw;
        }
    }
}
