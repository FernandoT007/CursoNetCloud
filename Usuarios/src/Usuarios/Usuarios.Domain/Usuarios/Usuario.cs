using Usuarios.Domain.Abstractions;
using Usuarios.Domain.Usuarios.Events;

namespace Usuarios.Domain.Usuarios;

public class Usuario : Entity
{
    private Usuario(
         Guid id
        , string? nombreUsuario
        , ApellidoPaterno apellidoPaterno
        , DateTime fechaNacimiento
        , CorreoElectronico? correoElectronico
        , Direccion? direccion) : base(id)
    {
        NombreUsuario = nombreUsuario;
        ApellidoPaterno = apellidoPaterno;
        FechaNacimiento = fechaNacimiento;
        CorreoElectronico = correoElectronico;
        Direccion = direccion;
    }
    
    public string? NombreUsuario { get; private set; }
    public ApellidoPaterno? ApellidoPaterno { get; private set; }
    public DateTime FechaNacimiento { get; private set; }
    public CorreoElectronico? CorreoElectronico { get; private set; }
    public Direccion? Direccion {get; private set;}

    public static Usuario Create(  
          string? nombreUsuario
        , ApellidoPaterno apellidoPaterno
        , DateTime fechaNacimiento
        , CorreoElectronico? correoElectronico
        , Direccion? direccion){
        
        var usuario = new Usuario(
            Guid.NewGuid(),
            nombreUsuario,
            apellidoPaterno,
            fechaNacimiento,
            correoElectronico,
            direccion
        );

        usuario.RaiseDomainEvent(new UserCreateDomainEvent(usuario.Id));

        return usuario;

    }

}