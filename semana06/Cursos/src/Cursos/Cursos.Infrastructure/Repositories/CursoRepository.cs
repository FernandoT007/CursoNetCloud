using Cursos.Domain.Cursos;
using MongoDB.Driver;

namespace Cursos.Infrastructure.Repositories;

public class CursoRepository : Repository<Curso>, ICursoRepository
{
    public CursoRepository(IMongoDatabase database) : base(database, "Cursos")
    {
    }

    public Task<List<Curso>> GetCursos(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}