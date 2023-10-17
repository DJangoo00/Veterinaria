namespace API.Helpers;

public class Authorization
{
    public enum Roles
    {
        Administrator,
        Empleado,

    }
    public const Roles role_default = Roles.Empleado;
}