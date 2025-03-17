using Data.Context;
using Data.Interfaces;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class BoardRepository : Repository<Board>, IBoardRepository
    {
        public BoardRepository(AppDbContext context) : base(context) { }
        public async Task<List<Board>> GetByIdUsuario(int idUsuario)
        {
            return await _dbSet.Where(x => x.IdUsuario == idUsuario).ToListAsync();
        }
    }
}
