namespace Docentes.api.Controllers.Docentes;

public record CrearDocenteRequest 
(
    Guid EspecialidadId
    ,string Nombres
    ,string ApellidoPaterno
    ,string ApellidoMaterno
    ,DateTime FechaNacimiento
    ,string CorreoElectronico
);