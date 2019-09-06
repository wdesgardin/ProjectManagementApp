using System.Collections.Generic;
using System.Threading.Tasks;
using ProjectManagementApp.Core.Models;

namespace ProjectManagementApp.Core
{
    public interface ICardRepository
    {
        void Add(Card card);
        Task<IEnumerable<Card>> GetCardsByColumnId(int columnId);
    }
}