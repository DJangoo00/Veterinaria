namespace Domain.Entities;
public class Laboratorio : BaseEntity
{
    public string Nombre { get; set; }
    public int Direccion { get; set; }
    public string Telefono { get; set; }
    public ICollection<Medicamento> Medicamentos { get; set; }
};