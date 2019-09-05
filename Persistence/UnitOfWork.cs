using System.Threading.Tasks;
using ProjectManagementApp.Core;

namespace ProjectManagementApp.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _dbContext;
        public UnitOfWork(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task CompleteAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}