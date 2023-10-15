using Aplicacion.Repository;
using App.Repository;
using Domain.Interfaces;
using Persistence;
namespace App.UnitOfWork;
public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly ApiContext _context;
    private ICitaRepository _citas;
    private IDetalleMovimientoRepository _detalleMovimiento;
    private IEspecieRepository _especies;
    private LaboratorioRepository _laboratorios;
    private MascotaRepository _mascotas;
    private MedicamentoRepository _medicamentos;
    private MovimientoMedicamentoRepository _movimientoMedicamentos;
    private PropietarioRepository _propietarios;
    private ProveedorRepository _proveedores;
    private RazaRepository _razas;
    private TipoMovimientoRepository _tiposMovimientos;
    private TratamientoMedicoRepository _tratamientosMedicos;
    private VeterinarioRepository _veterinarios;
    private RoleRepository _roles;
    private UserRepository _users;
    public UnitOfWork(ApiContext context)
    {
        _context = context;
    }

    //completar
    public ICitaRepository Citas
    {
        get
        {
            if (_citas == null)
            {
                _citas = new CitaRepository(_context);
            }
            return _citas;
        }
    }
    public IDetalleMovimientoRepository DetallesMovimientos
    {
        get
        {
            if (_detalleMovimiento == null)
            {
                _detalleMovimiento = new DetalleMovimientoRepository(_context);
            }
            return _detalleMovimiento;
        }
    }
    public IEspecieRepository Especies
    {
        get
        {
            if (_especies == null)
            {
                _especies = new EspecieRepository(_context);
            }
            return _especies;
        }
    }
    public ILaboratorioRepository Laboratorios
    {
        get
        {
            if (_laboratorios == null)
            {
                _laboratorios = new LaboratorioRepository(_context);
            }
            return _laboratorios;
        }
    }
    public IMascotaRepository Mascotas
    {
        get
        {
            if (_mascotas == null)
            {
                _mascotas = new MascotaRepository(_context);
            }
            return _mascotas;
        }
    }
    public IMedicamentoRepository Medicamentos
    {
        get
        {
            if (_medicamentos == null)
            {
                _medicamentos = new MedicamentoRepository(_context);
            }
            return _medicamentos;
        }
    }
    public IMovimientoMedicamentoRepository MovimientoMedicamentos
    {
        get
        {
            if (_movimientoMedicamentos == null)
            {
                _movimientoMedicamentos = new MovimientoMedicamentoRepository(_context);
            }
            return _movimientoMedicamentos;
        }
    }
    public IPropietarioRepository Propietarios
    {
        get
        {
            if (_propietarios == null)
            {
                _propietarios = new PropietarioRepository(_context);
            }
            return _propietarios;
        }
    }
    public IProveedorRepository Proveedores
    {
        get
        {
            if (_proveedores == null)
            {
                _proveedores = new ProveedorRepository(_context);
            }
            return _proveedores;
        }
    }
    public IRazaRepository Razas
    {
        get
        {
            if (_razas == null)
            {
                _razas = new RazaRepository(_context);
            }
            return _razas;
        }
    }
    public ITipoMovimientoRepository TiposMovimientos
    {
        get
        {
            if (_tiposMovimientos == null)
            {
                _tiposMovimientos = new TipoMovimientoRepository(_context);
            }
            return _tiposMovimientos;
        }
    }
    public ITratamientoMedicoRepository TratamientosMedicos
    {
        get
        {
            if (_tratamientosMedicos == null)
            {
                _tratamientosMedicos = new TratamientoMedicoRepository(_context);
            }
            return _tratamientosMedicos;
        }
    }
    public IVeterinarioRepository Veterinarios
    {
        get
        {
            if (_veterinarios == null)
            {
                _veterinarios = new VeterinarioRepository(_context);
            }
            return _veterinarios;
        }
    }
    
    //jwt
    public IRoleRepository Roles
    {
        get
        {
            if (_roles == null)
            {
                _roles = new RoleRepository(_context);
            }
            return _roles;
        }
    }

    public IUserRepository Users
    {
        get
        {
            if (_users == null)
            {
                _users = new UserRepository(_context);
            }
            return _users;
        }
    }

    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}