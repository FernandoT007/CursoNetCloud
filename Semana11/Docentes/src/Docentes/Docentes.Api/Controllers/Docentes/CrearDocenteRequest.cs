namespace Docentes.api.Controllers.Docentes;

public record CrearDocenteRequest 
(
    Guid UsuarioId,
    Guid EspecialidadId,
    string datoTemporal,
    int datoTemporaInt
);