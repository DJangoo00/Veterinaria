using System.Globalization;
using System.Reflection;
using CsvHelper;
using CsvHelper.Configuration;
using Domain.Entities;
using Microsoft.Extensions.Logging;

namespace Persistence;

public class ApiContextSeed
{
    public static async Task SeedAsync(ApiContext context, ILoggerFactory loggerFactory)
    {
        try
        {
            //inicio de las insersiones en la db
            var ruta = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            if (!context.Veterinarios.Any())
            {
                using (var reader = new StreamReader(ruta + @"/Data/Csv/Veterinario.csv"))
                {
                    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                    {
                        var list = csv.GetRecords<Veterinario>();
                        context.Veterinarios.AddRange(list);
                        await context.SaveChangesAsync();
                    }
                }
            }
            if (!context.Especies.Any())
            {
                using (var reader = new StreamReader(ruta + @"/Data/Csv/Especie.csv"))
                {
                    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                    {
                        var list = csv.GetRecords<Especie>();
                        context.Especies.AddRange(list);
                        await context.SaveChangesAsync();
                    }
                }
            }
            if (!context.Razas.Any())
            {
                using (var reader = new StreamReader(ruta + @"\Data\Csv\Raza.csv"))
                {
                    using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        HeaderValidated = null, // Esto deshabilita la validación de encabezados
                        MissingFieldFound = null
                    }))
                    {
                        // Resto de tu código para leer y procesar el archivo CSV
                        var list = csv.GetRecords<Raza>();
                        List<Raza> entidad = new List<Raza>();
                        foreach (var item in list)
                        {
                            entidad.Add(new Raza
                            {
                                Id = item.Id,
                                IdEspecieFk = item.IdEspecieFk,
                                Nombre = item.Nombre
                            });
                        }
                        context.Razas.AddRange(entidad);
                        await context.SaveChangesAsync();
                    }
                }
            }
            if (!context.Propietarios.Any())
            {
                using (var reader = new StreamReader(ruta + @"/Data/Csv/Propietario.csv"))
                {
                    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                    {
                        var list = csv.GetRecords<Propietario>();
                        context.Propietarios.AddRange(list);
                        await context.SaveChangesAsync();
                    }
                }
            }
            if (!context.Proveedores.Any())
            {
                using (var reader = new StreamReader(ruta + @"/Data/Csv/Proveedor.csv"))
                {
                    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                    {
                        var list = csv.GetRecords<Proveedor>();
                        context.Proveedores.AddRange(list);
                        await context.SaveChangesAsync();
                    }
                }
            }
            if (!context.Users.Any())
            {
                using (var reader = new StreamReader(ruta + @"/Data/Csv/User.csv"))
                {
                    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                    {
                        var list = csv.GetRecords<User>();
                        context.Users.AddRange(list);
                        await context.SaveChangesAsync();
                    }
                }
                
            }
            if (!context.Laboratorios.Any())
            {
                using (var reader = new StreamReader(ruta + @"/Data/Csv/Laboratorio.csv"))
                {
                    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                    {
                        var list = csv.GetRecords<Laboratorio>();
                        context.Laboratorios.AddRange(list);
                        await context.SaveChangesAsync();
                    }
                }
            }
            if (!context.TiposMovimientos.Any())
            {
                using (var reader = new StreamReader(ruta + @"/Data/Csv/TipoMovimiento.csv"))
                {
                    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                    {
                        var list = csv.GetRecords<TipoMovimiento>();
                        context.TiposMovimientos.AddRange(list);
                        await context.SaveChangesAsync();
                    }
                }
            }
            if (!context.TiposMovimientos.Any())
            {
                using (var reader = new StreamReader(ruta + @"/Data/Csv/TipoMovimiento.csv"))
                {
                    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                    {
                        var list = csv.GetRecords<TipoMovimiento>();
                        context.TiposMovimientos.AddRange(list);
                        await context.SaveChangesAsync();
                    }
                }
            }
            if (!context.Medicamentos.Any())
            {
                using (var reader = new StreamReader(ruta + @"\Data\Csv\Medicamento.csv"))
                {
                    using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        HeaderValidated = null, // Esto deshabilita la validación de encabezados
                        MissingFieldFound = null
                    }))
                    {
                        // Resto de tu código para leer y procesar el archivo CSV
                        var list = csv.GetRecords<Medicamento>();
                        List<Medicamento> entidad = new List<Medicamento>();
                        foreach (var item in list)
                        {
                            entidad.Add(new Medicamento
                            {
                                Id = item.Id,
                                Nombre = item.Nombre,
                                CantidadDisponible = item.CantidadDisponible,
                                Precio = item.Precio,
                                IdLaboratorioFk = item.IdLaboratorioFk
                            });
                        }
                        context.Medicamentos.AddRange(entidad);
                        await context.SaveChangesAsync();
                    }
                }
            }
            if (!context.Mascotas.Any())
            {
                using (var reader = new StreamReader(ruta + @"\Data\Csv\Mascota.csv"))
                {
                    using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        HeaderValidated = null, // Esto deshabilita la validación de encabezados
                        MissingFieldFound = null
                    }))
                    {
                        // Resto de tu código para leer y procesar el archivo CSV
                        var list = csv.GetRecords<Mascota>();
                        List<Mascota> entidad = new List<Mascota>();
                        foreach (var item in list)
                        {
                            entidad.Add(new Mascota
                            {
                                Id = item.Id,
                                IdPropietarioFk = item.IdPropietarioFk,
                                IdEspecieFk = item.IdEspecieFk,
                                IdRazaFk = item.IdRazaFk,
                                Nombre = item.Nombre,
                                FechaNacimiento = item.FechaNacimiento
                            });
                        }
                        context.Mascotas.AddRange(entidad);
                        await context.SaveChangesAsync();
                    }
                }
            }
            
            if (!context.Citas.Any())
            {
                using (var reader = new StreamReader(ruta + @"\Data\Csv\Cita.csv"))
                {
                    using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        HeaderValidated = null, // Esto deshabilita la validación de encabezados
                        MissingFieldFound = null
                    }))
                    {
                        // Resto de tu código para leer y procesar el archivo CSV
                        var list = csv.GetRecords<Cita>();
                        List<Cita> entidad = new List<Cita>();
                        foreach (var item in list)
                        {
                            entidad.Add(new Cita
                            {
                                Id = item.Id,
                                IdMascotaFk = item.IdMascotaFk,
                                Fecha = item.Fecha,
                                Hora = item.Hora,
                                Motivo = item.Motivo,
                                IdVeterinarioFk = item.IdVeterinarioFk
                            });
                        }
                        context.Citas.AddRange(entidad);
                        await context.SaveChangesAsync();
                    }
                }
            }
            if (!context.MedicamentosProveedores.Any())
            {
                using (var reader = new StreamReader(ruta + @"\Data\Csv\MedicamentoProveedor.csv"))
                {
                    using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        HeaderValidated = null, // Esto deshabilita la validación de encabezados
                        MissingFieldFound = null
                    }))
                    {
                        // Resto de tu código para leer y procesar el archivo CSV
                        var list = csv.GetRecords<MedicamentoProveedor>();
                        List<MedicamentoProveedor> entidad = new List<MedicamentoProveedor>();
                        foreach (var item in list)
                        {
                            entidad.Add(new MedicamentoProveedor
                            {
                                IdMedicamento = item.IdMedicamento,
                                IdProveedor = item.IdProveedor 
                            });
                        }
                        context.MedicamentosProveedores.AddRange(entidad);
                        await context.SaveChangesAsync();
                    }
                }
            }

            if (!context.MovimientosMedicamentos.Any())
            {
                using (var reader = new StreamReader(ruta + @"\Data\Csv\MovimientoMedicamento.csv"))
                {
                    using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        HeaderValidated = null, // Esto deshabilita la validación de encabezados
                        MissingFieldFound = null
                    }))
                    {
                        // Resto de tu código para leer y procesar el archivo CSV
                        var list = csv.GetRecords<MovimientoMedicamento>();
                        List<MovimientoMedicamento> entidad = new List<MovimientoMedicamento>();
                        foreach (var item in list)
                        {
                            entidad.Add(new MovimientoMedicamento
                            {
                                Id = item.Id,
                                Fecha = item.Fecha,
                                IdUserFk = item.IdUserFk,
                                IdPropietarioFk = item.IdPropietarioFk,
                                IdTipMovFk = item.IdTipMovFk,
                                Total = item.Total
                            });
                        }
                        context.MovimientosMedicamentos.AddRange(entidad);
                        await context.SaveChangesAsync();
                    }
                }
            }            
            if (!context.DetallesMovimientos.Any())
            {
                using (var reader = new StreamReader(ruta + @"\Data\Csv\DetalleMovimiento.csv"))
                {
                    using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        HeaderValidated = null, // Esto deshabilita la validación de encabezados
                        MissingFieldFound = null
                    }))
                    {
                        // Resto de tu código para leer y procesar el archivo CSV
                        var list = csv.GetRecords<DetalleMovimiento>();
                        List<DetalleMovimiento> entidad = new List<DetalleMovimiento>();
                        foreach (var item in list)
                        {
                            entidad.Add(new DetalleMovimiento
                            {
                                Id = item.Id,
                                IdMedicamentoFk = item.IdMedicamentoFk,
                                Cantidad = item.Cantidad,
                                IdMovMedFk = item.IdMovMedFk,
                                Precio = item.Precio
                            });
                        }
                        context.DetallesMovimientos.AddRange(entidad);
                        await context.SaveChangesAsync();
                    }
                }
            }
            if (!context.TratamientosMedicos.Any())
            {
                using (var reader = new StreamReader(ruta + @"\Data\Csv\TratamientoMedico.csv"))
                {
                    using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        HeaderValidated = null, // Esto deshabilita la validación de encabezados
                        MissingFieldFound = null
                    }))
                    {
                        // Resto de tu código para leer y procesar el archivo CSV
                        var list = csv.GetRecords<TratamientoMedico>();
                        List<TratamientoMedico> entidad = new List<TratamientoMedico>();
                        foreach (var item in list)
                        {
                            entidad.Add(new TratamientoMedico
                            {
                                Id = item.Id,
                                IdCitaFk = item.IdCitaFk,
                                IdMedicamentoFk = item.IdMedicamentoFk,
                                Dosis = item.Dosis,
                                FechaAdministracion = item.FechaAdministracion,
                                Observacion = item.Observacion,
                            });
                        }
                        context.TratamientosMedicos.AddRange(entidad);
                        await context.SaveChangesAsync();
                    }
                }
            }
            if (!context.RolesUsers.Any())
            {
                using (var reader = new StreamReader(ruta + @"\Data\Csv\RoleUser.csv"))
                {
                    using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        HeaderValidated = null, // Esto deshabilita la validación de encabezados
                        MissingFieldFound = null
                    }))
                    {
                        // Resto de tu código para leer y procesar el archivo CSV
                        var list = csv.GetRecords<RoleUser>();
                        List<RoleUser> entidad = new List<RoleUser>();
                        foreach (var item in list)
                        {
                            entidad.Add(new RoleUser
                            {
                                IdUserFk = item.IdUserFk,
                                IdRoleFk = item.IdRoleFk
                            });
                        }
                        context.RolesUsers.AddRange(entidad);
                        await context.SaveChangesAsync();
                    }
                }
            }
        //fin de las insersiones en la db
        }
        catch (Exception ex)
        {
            var logger = loggerFactory.CreateLogger<ApiContext>();
            logger.LogError(ex.Message);
        }
    }
    public static async Task SeedRolesAsync(ApiContext context, ILoggerFactory loggerFactory)
    {
        try
        {
            if (!context.Roles.Any())
            {
                var roles = new List<Role>()
                        {
                            new Role{Id=1, Nombre="Administrador"},
                            new Role{Id=2, Nombre="Empleado"},
                        };
                context.Roles.AddRange(roles);
                await context.SaveChangesAsync();
            }
        }
        catch (Exception ex)
        {
            var logger = loggerFactory.CreateLogger<ApiContext>();
            logger.LogError(ex.Message);
        }
    }
}

