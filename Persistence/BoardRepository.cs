using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectManagementApp.Core;
using ProjectManagementApp.Core.Models;

namespace ProjectManagementApp.Persistence
{
    public class BoardRepository : IBoardRepository
    {
        private readonly AppDbContext _dbContext;

        public BoardRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Add(Board board)
        {
            _dbContext.Boards.Add(board);
        }

        public async Task<IEnumerable<Board>> GetBoards()
        {
            return await _dbContext.Boards.ToListAsync();
        }

        public async Task<Board> GetById(int id)
        {
            return await _dbContext.Boards.FirstOrDefaultAsync(b => b.Id == id);
        }
    }
}