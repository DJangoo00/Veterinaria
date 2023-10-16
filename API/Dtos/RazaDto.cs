using Domain.Entities;
namespace API.Dtos;

public class RazaDto : BaseEntity
{
    public int IdEspecieFk { get; set; }
    public EspecieDto Especie { get; set; }
    public string Nombre { get; set; }
}
