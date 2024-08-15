namespace Usuarios.Domain.Usuarios;

public record Direccion
(
    string? Pais, 
    string? Ciudad ,
    string? Provincia ,
    string? Distrito ,
    string? Calle 
);