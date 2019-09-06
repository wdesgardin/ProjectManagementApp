using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectManagementApp.Core;
using ProjectManagementApp.Core.Models;

namespace ProjectManagementApp.Persistence
{
    public class ColumnRepository : IColumnRepository
    {
        private readonly AppDbContext _dbContext;

        public ColumnRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Add(Column column)
        {
            _dbContext.Columns.Add(column);
        }

        public async Task<IEnumerable<Column>> GetByBoardId(int boardId)
        {
            return await _dbContext.Columns.Where(c => c.BoardId == boardId).ToListAsync();
        }

        public async Task<Column> GetById(int id)
        {
            return await _dbContext.Columns.FirstOrDefaultAsync(c => c.Id == id);
        }

        public void Remove(Column column)
        {
            _dbContext.Remove(column);
        }
    }
}