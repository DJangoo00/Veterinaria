using Domain.Entities;
namespace API.Dtos;
public class MascotaDto : BaseEntity
{
    public int IdPropietarioFk { get; set; }
    public PropietarioDto Propietario { get; set; }
    public int IdEspecieFk { get; set; }
    public EspecieDto Especie { get; set; }
    public int IdRazaFk { get; set; }
    public RazaDto Raza { get; set; }
    public string Nombre { get; set; }
    public DateTime FechaNacimiento { get; set; }
}
