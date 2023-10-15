namespace Domain.Entities;
public class MovimientoMedicamento : BaseEntity
{
    public DateOnly Fecha { get; set; }
    public int IdUserFk {get; set;}
    public User User {get; set;}
    public int IdPropietarioFk {get; set;}
    public Propietario Propietario {get; set;}
    public int IdTipMovFk { get; set; }
    public TipoMovimiento TipoMovimiento { get; set; }
    public int Total { get; set; }
    public ICollection<DetalleMovimiento> DetallesMovimientos {get; set;}
}