using Domain.Entities;
namespace API.Dtos;
public class MovimientoMedicamentoDto : BaseEntity
{
    public DateOnly Fecha { get; set; }
    public int IdUserFk {get; set;}
    public int IdPropietarioFk {get; set;}
    public int IdTipMovFk { get; set; }
    public int Total { get; set; }
}