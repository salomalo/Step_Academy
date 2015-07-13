using System.Data.Entity;

namespace Business.Managers.Abstract
{
    public class AbstractManager
    {
        private readonly string _connectionString;

        public AbstractManager(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected DbContext CreateDbContext()
        {
            return new DbContext(_connectionString);
        }
    }
}
