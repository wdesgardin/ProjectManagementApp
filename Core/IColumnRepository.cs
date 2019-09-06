using System.Collections.Generic;
using System.Threading.Tasks;
using ProjectManagementApp.Core.Models;

namespace ProjectManagementApp.Core
{
    public interface IColumnRepository
    {
         void Add(Column column);
         Task<IEnumerable<Column>> GetByBoardId(int boardId);
         Task<Column> GetById(int id);
         void Remove(Column column);
    }
}