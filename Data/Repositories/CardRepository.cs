using Data.Context;
using Data.Interfaces;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class CardRepository: Repository<Card>, ICardRepository
    {
        public CardRepository(AppDbContext context) : base(context) { }
        public async Task<List<Card>> GetByIdColumna(int idColumna)
        {
            return await _dbSet.Where(x => x.IdColumn == idColumna).ToListAsync();
        }
    }
}
