using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectManagementApp.Core;
using ProjectManagementApp.Core.Models;

namespace ProjectManagementApp.Persistence
{
    public class CardRepository : ICardRepository
    {
        private readonly AppDbContext _dbContext;

        public CardRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Add(Card card)
        {
            _dbContext.Cards.Add(card);
        }

        public async Task<IEnumerable<Card>> GetCardsByColumnId(int columnId)
        {
            return await _dbContext.Cards.Where(c => c.ColumnId == columnId).ToListAsync();
        }
    }
}