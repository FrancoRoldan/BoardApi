using Data.Context;
using Data.Interfaces;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class ColumnRepository: Repository<Column>, IColumnRepository
    {
        public ColumnRepository(AppDbContext context) : base(context) { }
        public async Task<List<Column>> GetByIdBoard(int idBoard)
        {
            return await _dbSet.Where(x => x.IdBoard == idBoard).ToListAsync();
        }
    }
}
