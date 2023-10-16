using Domain.Entities;
namespace API.Dtos;
public class MovimientoMedicamentoDto : BaseEntity
{
    public DateOnly Fecha { get; set; }
    public int IdUserFk {get; set;}
    public UserDto Usuario { get; set; }
    public int IdPropietarioFk {get; set;}
    public PropietarioDto Propietario { get; set; }
    public int IdTipMovFk { get; set; }
    public TipoMovimiento TipoMovimiento     { get; set; }
    public int Total { get; set; }
}