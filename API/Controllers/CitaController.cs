using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using API.Dtos;
using Domain.Interfaces;
using AutoMapper;
namespace API.Controllers;
[ApiVersion("1.0")]
[ApiVersion("1.1")]
public class CitaController : BaseApiController
{
    private readonly IUnitOfWork unitofwork;
    private readonly IMapper mapper;

    public CitaController(IUnitOfWork unitofwork, IMapper mapper)
    {
        this.unitofwork = unitofwork;
        this.mapper = mapper;
    }

    [HttpGet]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<CitaDto>>> Get()
    {
        var _citas = await unitofwork.Citas.GetAllAsync();
        return mapper.Map<List<CitaDto>>(_citas);
    }
}