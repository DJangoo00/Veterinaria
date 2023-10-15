using Domain.Entities;
namespace API.Dtos;
public class MascotaDto : BaseEntity
{
    public int IdPropietarioFk { get; set; }
    public int IdEpecieFk { get; set; }
    public int IdRazaFk { get; set; }
    public string Nombre { get; set; }
    public DateTime FechaNacimiento { get; set; }
}
