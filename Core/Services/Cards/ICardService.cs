using Data.Dtos.Cards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Cards
{
    public interface ICardService
    {
        Task<GetCardResponse?> UpdateCard(UpdateCardRequest cardUpdate);
        Task<GetCardResponse> AddCard(AddCardRequest card);
    }
}
