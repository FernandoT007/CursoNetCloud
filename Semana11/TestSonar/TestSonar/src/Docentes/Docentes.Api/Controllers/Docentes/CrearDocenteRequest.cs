using System.Text.Json.Serialization;

namespace Docentes.api.Controllers.Docentes;

public record CrearDocenteRequest 
{
    [JsonRequired] public Guid UsuarioId {get; init; }
    [JsonRequired] public Guid EspecialidadId {get; init; }
}