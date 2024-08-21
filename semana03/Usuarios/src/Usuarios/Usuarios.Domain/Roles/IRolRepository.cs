namespace Usuarios.Domain.Roles;

public interface IRolRepository
{
    Task<Rol?> GetByNameAsync(string rolName, CancellationToken cancellationToken = default);

    Task<List<Rol>>? ListAsync(CancellationToken cancellationToken = default);
}