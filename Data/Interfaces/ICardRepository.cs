using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface ICardRepository : IRepository<Card>
    {
        Task<List<Card>> GetByIdColumna(int idColumna);
    }
}
