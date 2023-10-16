using Domain.Entities;

namespace API.Dtos;
public class CitaDto : BaseEntity
{
    public int IdMascotaFk { get; set; }
    public MascotaDto Mascota { get; set; }
    public DateOnly Fecha { get; set; }
    public TimeSpan Hora { get; set; }
    public string Motivo { get; set; }
    public int IdVeterinarioFk { get; set; }
    public VeterinarioDto Veterinario { get; set; }
}