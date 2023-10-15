using Domain.Entities;
namespace API.Dtos;
public class PropietarioDto : BaseEntity
{
    public string Nombre { get; set; }
    public string CorreoElectronico { get; set; }
    public string Telefono { get; set; }
}