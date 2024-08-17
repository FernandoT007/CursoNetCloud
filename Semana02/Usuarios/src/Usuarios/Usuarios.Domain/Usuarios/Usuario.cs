using Usuarios.Domain.Abstractions;
using Usuarios.Domain.Usuarios.Events;

namespace Usuarios.Domain.Usuarios;

public class Usuario : Entity
{
    private Usuario(
         Guid id
        , NombreUsuario? nombreUsuario
        , ApellidoPaterno apellidoPaterno
        , ApellidoMaterno? apellidoMaterno
        , Password? password
        , DateTime fechaNacimiento
        , CorreoElectronico? correoElectronico
        , Direccion? direccion
        , UsuarioEstado estado
        , DateTime fechaUltimoCambio) : base(id)
    {
        NombreUsuario = nombreUsuario;
        ApellidoPaterno = apellidoPaterno;
        ApellidoMaterno = apellidoMaterno;
        Password = password;
        FechaNacimiento = fechaNacimiento;
        CorreoElectronico = correoElectronico;
        Direccion = direccion;
        Estado = estado;
        FechaUltimoCambio = fechaUltimoCambio;
    }

    public NombreUsuario? NombreUsuario { get; private set; }
    public NombresPersona? NombrePersona { get; set; }
    public ApellidoPaterno? ApellidoPaterno { get; private set; }
    public ApellidoMaterno? ApellidoMaterno { get; private set; }
    public Password? Password { get; private set; }
    public DateTime? FechaNacimiento { get; private set; }
    public CorreoElectronico? CorreoElectronico { get; private set; }
    public Direccion? Direccion {get; private set;}
    public UsuarioEstado Estado { get; private set; }
    public DateTime FechaUltimoCambio { get; private set; }


    public static Usuario Create(  
          ApellidoPaterno apellidoPaterno
        , ApellidoMaterno apellidoMaterno
        , NombresPersona nombresPersona
        , Password password
        , DateTime fechaNacimiento
        , CorreoElectronico? correoElectronico
        , Direccion? direccion
        , DateTime fechaUltimoCambio
        , NombreUsuarioService nombreUsuarioService
        ){

        var nombreUsuario = nombreUsuarioService.GenerarNombreUsuario(apellidoPaterno,nombresPersona);
        
        var usuario = new Usuario(
            Guid.NewGuid(),
            nombreUsuario,
            apellidoPaterno,
            apellidoMaterno,
            password,
            fechaNacimiento,
            correoElectronico,
            direccion,
            UsuarioEstado.Activo,
            fechaUltimoCambio
        );

        usuario.RaiseDomainEvent(new UserCreateDomainEvent(usuario.Id));

        return usuario;
    }

    public Result Activar(DateTime utcNow)
    {
        if (Estado == UsuarioEstado.Activo)
        {
            return Result.Failure(UsuarioErrores.YaSeEncuentraActivo);
        }
        Estado = UsuarioEstado.Activo;
        FechaUltimoCambio = utcNow;

        return Result.Success();
    }

    public Result Inactivar(DateTime utcNow)
    {
        if (Estado == UsuarioEstado.Inactivo)
        {
            return Result.Failure(UsuarioErrores.YaSeEncuentraInactivo);
        }
        Estado = UsuarioEstado.Inactivo;
        FechaUltimoCambio = utcNow;

        return Result.Success();
    }

}