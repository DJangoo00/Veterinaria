using Domain.Entities;

namespace API.Dtos;
public class DetalleMovimientoDto : BaseEntity
{
    public int IdMedicamentoFk { get; set; }
    public int Cantidad { get; set; }
    public int IdMovMedFk { get; set; }
    public int Precio { get; set; }
}