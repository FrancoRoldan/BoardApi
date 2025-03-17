using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IBoardRepository : IRepository<Board>
    {
        Task<List<Board>> GetByIdUsuario(int idUsuario);
    }
}
