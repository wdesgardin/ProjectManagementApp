using System.Collections.Generic;
using System.Threading.Tasks;
using ProjectManagementApp.Core.Models;

namespace ProjectManagementApp.Core
{
    public interface IBoardRepository
    {
         void Add(Board board);
         Task<IEnumerable<Board>> GetBoards();
         Task<Board> GetById(int id);
    }
}