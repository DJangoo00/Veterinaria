namespace Domain.Entities;
public class DetalleMovimiento : BaseEntity
{
    public int IdMedicamentoFk { get; set; }
    public Medicamento Medicamento { get; set; }
    public int Cantidad { get; set; }
    public int IdMovMedFk { get; set; }
    public MovimientoMedicamento MovimientoMedicamento {get; set;}
    public int Precio { get; set; }
}