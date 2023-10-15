using Domain.Entities;
namespace API.Dtos;
public class VeterinarioDto : BaseEntity
{
    public string Nombre { get; set; }
    public string CorreoElectronico { get; set; }
    public string Telefono { get; set; }
    public string Especialidad { get; set; }
}