using System.Data;
using WebApiDapper.Models;

namespace WebApiDapper.Repositories
{
    public abstract class TodoRepositoryAbstract : RepositoryAbstract<Todos>
    {
        protected TodoRepositoryAbstract(IDbConnection connection) 
            : base(connection)
        {
        }
    }
}
