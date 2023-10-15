using Domain.Entities;
namespace API.Dtos;
public class LaboratorioDto : BaseEntity
{
    public string Nombre { get; set; }
    public int Direccion { get; set; }
    public string Telefono { get; set; }
};