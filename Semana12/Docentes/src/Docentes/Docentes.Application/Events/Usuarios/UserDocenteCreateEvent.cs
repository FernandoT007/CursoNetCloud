using MediatR;

namespace Docentes.Application.Events.Usuarios;

public sealed record UserDocenteCreateEvent(
    Guid EspecialidadId
    ,string Rol
    ,string Nombres
    ,string ApellidoPaterno
    ,string ApellidoMaternoCrearDocenteCommandHandler
    ,DateTime FechaNacimiento
    ,string CorreoElectronico
) : INotification; 