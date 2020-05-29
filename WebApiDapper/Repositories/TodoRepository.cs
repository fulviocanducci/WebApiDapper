using System.Data;

namespace WebApiDapper.Repositories
{
    public class TodoRepository : TodoRepositoryAbstract
    {
        public TodoRepository(IDbConnection connection)
            : base(connection)
        {
        }
    }
}
